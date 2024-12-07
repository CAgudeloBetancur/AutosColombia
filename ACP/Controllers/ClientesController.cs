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
public class ClientesController : Controller
{
    private readonly IServicioCliente _servicioCliente;
    private readonly IServicioVehiculo _servicioVehiculo;

    public ClientesController(
        IServicioCliente servicioCliente, 
        IServicioVehiculo servicioVehiculo
        )
    {
        _servicioCliente = servicioCliente;
        _servicioVehiculo = servicioVehiculo;
    }

    // GET: Clientes
    [HttpGet]
    public async Task<IActionResult> Index() 
    { 
        return View( await _servicioCliente.ObtenerTodosLosClientes() );
    } 
    
    // GET: Clientes/Create
    public IActionResult Create() 
    {
        return View();
    } 
    
    // POST: Clientes/Create
    [HttpPost] 
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Create(
        [Bind("Id,Nombre,Apellido,Documento,Telefono,Correo,VehiculosSeleccionados")] CrearClienteViewModel clienteViewModel
        ) 
    {

        if (ModelState.IsValid) 
        {
            var clienteExistente = await _servicioCliente.ExisteCliente(v => v.Documento == clienteViewModel.Documento);


            if (clienteExistente)
            {
                ModelState.AddModelError("Documento", "El documento ingresado ya esta registrado.");

                TempData["ErrorMessage"] = "Documento registrado previamente.";

                return View(clienteViewModel);
            }

            var cliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nombre = clienteViewModel.Nombre,
                Apellido = clienteViewModel.Apellido,
                Documento = clienteViewModel.Documento,
                Telefono = clienteViewModel.Telefono,
                Correo = clienteViewModel.Correo
            };

            if(clienteViewModel.VehiculosSeleccionados != null)
            {
                var vehiculos = await _servicioVehiculo
                    .VehiculosFiltrados(v => clienteViewModel.VehiculosSeleccionados.Contains(v.Placa)
                    );

                foreach (var vehiculo in vehiculos)
                {
                    if(!cliente.Vehiculos.Any(v => v.Placa == vehiculo.Placa))
                    {
                        cliente.Vehiculos.Add(vehiculo);

                        if(!vehiculo.Clientes.Any(c => c.Documento == cliente.Documento))
                        {
                            vehiculo.Clientes.Add(cliente);
                        }
                    }
                }
            }

            await _servicioCliente.CrearCliente(cliente); // Guarda cambios

            TempData["SuccessMessage"] = "El cliente se creó correctamente.";

            return RedirectToAction(nameof(Index)); 
        }

        TempData["ErrorMessage"] = "Hubo un error al intentar crear el registro.";

        return View(clienteViewModel); 
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _servicioCliente.ObtenerPorIdConRelaciones(id);
        
        if (cliente == null) return NotFound();

        var viewModel = new DetailsClienteViewModel
        {
            Id = cliente.Id,
            Nombre = $"{cliente.Nombre} {cliente.Apellido}",
            Email = cliente.Correo,
            Telefono = cliente.Telefono,
            Vehiculos = cliente
                .Vehiculos
                .Select(v => new DetailsClienteViewModel.VehiculoInfo
                {
                    Placa = v.Placa,
                    Color = v.Color.Nombre,
                    Referencia = v.Referencia.Nombre
                })
                .ToList()
        };


        return View(viewModel); 
    }

    [HttpGet]
    public async Task<IActionResult> GetClientesDocumentos(string term)
    {
        var documentos = await _servicioCliente.FiltrarYMapear<string>(
            v => v.Documento.Contains(term),
            v => v.Documento
            );

        return Json(documentos);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultado = await _servicioCliente.Eliminar(id);

        if (resultado)
        {
            return Json(new { success = true, message = "Registro eliminado correctamente." });
        }
        
        return Json(new { success = false, message = "No se pudo eliminar el registro." });
        
    }
}

