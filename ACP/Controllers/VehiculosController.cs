using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACP.Data;
using ACP.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using ACP.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACP.Services.Interfaces;

[Authorize(Roles = "Administrador,Operario")]
public class VehiculosController : Controller
{
    private readonly IServicioVehiculo _servicioVehiculo;
    private readonly IServicioCliente _servicioCliente;
    private readonly IServicioFabricante _servicioFabricante;
    private readonly IServicioColor _servicioColor;
    private readonly IServicioReferencia _servicioReferencia;

    public VehiculosController(
        IServicioVehiculo servicioVehiculo,
        IServicioFabricante servicioFabricante,
        IServicioColor servicioColor,
        IServicioReferencia servicioReferencia,
        IServicioCliente servicioCliente)
    {
        _servicioVehiculo = servicioVehiculo;
        _servicioFabricante = servicioFabricante;
        _servicioColor = servicioColor;
        _servicioReferencia = servicioReferencia;
        _servicioCliente = servicioCliente;
    }

    // GET: Vehiculos
    public async Task<IActionResult> Index()
    {
        var vehiculos = await _servicioVehiculo.ObtenerTodosConRelaciones();

        return View(vehiculos);
    }

    // GET: Vehiculos/Create
    public async Task<IActionResult> Create(string placa = "")
    {
        var viewModel = new CrearVehiculoViewModel
        {
            Placa = placa,
            Fabricantes = GetSelectListWithDefaultOption(
                await _servicioFabricante.Mapear(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Nombre
                })),
            Colores = GetSelectListWithDefaultOption(
                 await _servicioColor.Mapear(c => new SelectListItem
                 {
                     Value = c.Id.ToString(),
                     Text = c.Nombre
                 })),
            Referencias = GetSelectListWithDefaultOption(
                 await _servicioReferencia.Mapear(r => new SelectListItem
                 {
                     Value = r.Id.ToString(),
                     Text = r.Nombre
                 })),
            Modelos = GetAnios()
        };

        return View(viewModel);
    }

    // POST: Vehiculos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Placa,Modelo,FabricanteId,ColorId,ClientesSeleccionados,ReferenciaId")] CrearVehiculoViewModel vehiculoViewModel
        )
    {
        if (ModelState.IsValid)
        {
            var vehiculoExistente = await _servicioVehiculo.ExisteVehiculo(v => v.Placa == vehiculoViewModel.Placa);

            if (vehiculoExistente)
            {
                ModelState.AddModelError("Placa", "La placa ingresada ya esta registrada.");
                return View(vehiculoViewModel);
            }

            var vehiculo = new Vehiculo()
            {
                Id = Guid.NewGuid(),
                Placa = vehiculoViewModel.Placa,
                Modelo = vehiculoViewModel.Modelo,
                FabricanteId = vehiculoViewModel.FabricanteId,
                ColorId = vehiculoViewModel.ColorId,
                ReferenciaId = vehiculoViewModel.ReferenciaId
            };

            if (vehiculoViewModel.ClientesSeleccionados != null)
            {
                var clientes = await _servicioCliente.ClientesFiltrados(c => vehiculoViewModel.ClientesSeleccionados.Contains(c.Documento));

                foreach (var cliente in clientes)
                {
                    if (!vehiculo.Clientes.Any(c => c.Documento == cliente.Documento))
                    {
                        vehiculo.Clientes.Add(cliente);

                        if (!cliente.Vehiculos.Any(v => v.Placa == vehiculo.Placa))
                        {
                            cliente.Vehiculos.Add(vehiculo);
                        }
                    }
                }
            }

            await _servicioVehiculo.CrearVehiculo(vehiculo); // Hace guardado del context
            TempData["SuccessMessage"] = "El vehiculo se creó correctamente.";

            return RedirectToAction(nameof(Index));
        }

        vehiculoViewModel.Fabricantes = GetSelectListWithDefaultOption(
            await _servicioFabricante.Mapear(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Nombre
            }));
        vehiculoViewModel.Colores = GetSelectListWithDefaultOption(
            await _servicioColor.Mapear(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre
            }));
        vehiculoViewModel.Referencias = GetSelectListWithDefaultOption(
            await _servicioReferencia.Mapear(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Nombre
            }));
        vehiculoViewModel.Modelos = GetAnios();

        return View(vehiculoViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetVehiculoPlacas(string term)
    {
        var placas = await _servicioVehiculo.FiltrarYMapear<string>(
            v => v.Placa.Contains(term),
            v => v.Placa
            );

        return Json(placas);
    }

    [HttpGet]
    public async Task<IActionResult> GetReferenciasByFabricante(Guid fabricanteId)
    {
        var referencias = await _servicioReferencia.FiltrarYMapear<object>(
            r => r.FabricanteId == fabricanteId,
            r => new { r.Id, r.Nombre }
            );

        return Json(referencias);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultado = await _servicioVehiculo.Eliminar(id);

        if (resultado)
        {
            return Json(new { success = true, message = "Registro eliminado correctamente." });
        }
        
        return Json(new { success = false, message = "No se pudo eliminar el registro." });
        
    }

    // Métodos de ayuda

    private SelectList GetAnios()
    {
        int startYear = 1980; // Puedes cambiar este año inicial según tus necesidades
        int endYear = DateTime.Now.Year + 1; 
        var years = new List<SelectListItem>(); 
        
        for (int year = endYear; year >= startYear; year--) 
        { 
            years.Add(
                new SelectListItem { Value = year.ToString(), Text = year.ToString() }
                ); 
        }

        return new SelectList(years, "Value", "Text");
    }

    private static SelectList GetSelectListWithDefaultOption(
        IEnumerable<SelectListItem> items, 
        string defaultText = "-- selecciona --") 
    { 
        var selectList = new List<SelectListItem> 
        { 
            new SelectListItem { Value = "", Text = defaultText } 
        }; 
        
        selectList.AddRange(items); 
        
        return new SelectList(selectList, "Value", "Text"); 
    }

}

