using ACP.Models;
using ACP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize(Roles = "Administrador")]
public class UsuariosController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsuariosController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();

        var nonAdminUsers = new List<ApplicationUser>();

        foreach(var user in users)
        {
            if (!await _userManager.IsInRoleAsync(user, "Administrador"))
            {
                nonAdminUsers.Add(user);
            }
        }

        return View(nonAdminUsers);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null) return NotFound();

        var model = new EditarUsuarioViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber!,
            Email = user.Email!
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditarUsuarioViewModel model)
    {
        if (ModelState.IsValid) { 
            
            var user = await _userManager.FindByIdAsync(model.Id); 
            
            if (user == null) return NotFound(); 
            
            user.Email = model.Email; 
            user.FirstName = model.FirstName; 
            user.LastName = model.LastName; 
            user.PhoneNumber = model.PhoneNumber; 

            var result = await _userManager.UpdateAsync(user); 

            if (result.Succeeded) 
            { 
                return RedirectToAction(nameof(Index)); 
            }
            
            foreach (var error in result.Errors) 
            { 
                ModelState.AddModelError(string.Empty, error.Description); 
            } 
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id); 
        
        if (user == null) return NotFound();
        
        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded) 
        {
            return Json(new {success = true, message = "Usuario eliminado exitosamente."});
        } 

        return Json(new { success = false, message = "No se pudo el eliminar el Usuario indicado." });
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _userManager.FindByIdAsync(id);

        if (usuario == null) return NotFound();

        var viewModel = new DetalleUsuarioViewModel
        {
            Id = usuario.Id,
            FirstName = usuario.FirstName,
            LastName = usuario.LastName,
            PhoneNumber = usuario.PhoneNumber,
            Email = usuario.Email
        };


        return View(viewModel);
    }

}

