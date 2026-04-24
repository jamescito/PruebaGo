using System;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TareaController : ControllerBase
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

		return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Tarea>> GetTarea(int id)
	{
		var tarea = await _context.Tareas.FindAsync(id);
		if (tarea == null) return NotFound();
		return tarea;
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutTarea(int id, Tarea tarea)
	{
		if (id != tarea.Id) return BadRequest();
		_context.Entry(tarea).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!_context.Tareas.Any(e => e.Id == id)) return NotFound();
			else throw;
		}
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTarea(int id)
	{
		var tarea = await _context.Tareas.FindAsync(id);
		if (tarea == null) return NotFound();
		_context.Tareas.Remove(tarea);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}