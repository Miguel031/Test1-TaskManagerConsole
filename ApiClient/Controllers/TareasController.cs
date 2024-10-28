using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly TareasServices _tareasService;

    public TareasController(TareasServices tareasService)
    {
        _tareasService = tareasService;
    }

    [HttpPost]
    public IActionResult AñadirTarea([FromBody] Tareas nuevaTarea)
    {
        _tareasService.AgregarTarea(nuevaTarea.Descripcion);
        return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = nuevaTarea.Id }, nuevaTarea);
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarTarea(int id)
    {
        _tareasService.EliminarTarea(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult MarcarTareaCompleta(int id)
    {
        _tareasService.MarcarTareaCompleta(id);
        return NoContent();
    }

    [HttpGet("pendientes")]
    public IActionResult ListarTareasPendientes()
    {
        var pendientes = _tareasService.ObtenerTareasPendientes();
        return Ok(pendientes);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerTareaPorId(int id)
    {
        var tarea = _tareasService.ObtenerTareaPorId(id);
        return tarea == null ? NotFound() : Ok(tarea);
    }

    [HttpGet]
    public IActionResult ListarTareas()
    {
        var todas = _tareasService.ObtenerTodasLasTareas();
        return Ok(todas);
    }
}
