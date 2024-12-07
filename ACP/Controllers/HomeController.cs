using ACP.Data;
using ACP.Models;
using ACP.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ACP.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ACPDbContext _context;
    private readonly IServicioVehiculo _servicioVehiculo;

    public HomeController(ILogger<HomeController> logger, ACPDbContext context, IServicioVehiculo servicioVehiculo)
    {
        _context = context;
        _logger = logger;
        _servicioVehiculo = servicioVehiculo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> Search(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa)) 
        {            
            ModelState.AddModelError("Placa", "Por favor, ingrese una placa."); 
            return View("Index"); 
        }

        var vehiculo = await _servicioVehiculo.ObtenerPorPlacaConRelaciones(
            placa,
            v => v.Clientes,
            v => v.Fabricante,
            v => v.Color
            );

        if (vehiculo != null) 
        { 
            ViewBag.VehiculoEncontrado = vehiculo;
            ViewBag.PlacaSugerida = placa;
        } 
        else 
        { 
            ViewBag.PlacaSugerida = placa; 
        } 
        
        return View("Index"); }
}
