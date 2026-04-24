using System;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TareaController: ControllerBase
{
	private readonly DbPrueba _context;
	
	public TareaController(DbPrueba context)
	{
		_context = context;
    }

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
	{ 
		return await _context.Tareas.ToListAsync();
    }

     [HttpPost]
	public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
	{ 
		_context.Tareas.Add(tarea);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetTareas), new { id = tarea.Id }, tarea);
    }
}
