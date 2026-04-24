using System;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskApi.DTOs;

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
	public async Task<ActionResult<IEnumerable<TareaResponseDto>>> GetTareas()
	{
		var tareas = await _context.Tareas.ToListAsync();

        return tareas.Select(t => new TareaResponseDto
		{
			Id = t.Id,
			Title = t.Title,
			Description = t.Description,
			IsCompleted = t.IsCompleted,
			Duedate = t.Duedate
		}).ToList();
    }

	[HttpPost]
	public async Task<ActionResult<TareaResponseDto>> PostTarea(TareaCreateDto tareaDto)
	{
		var tarea = new Tarea
		{
			Title = tareaDto.Title,
			Description = tareaDto.Description,
			IsCompleted = tareaDto.IsCompleted,
			Duedate = tareaDto.Duedate
		};

        _context.Tareas.Add(tarea);
		await _context.SaveChangesAsync();

		var tareaResponse = new TareaResponseDto
		{
			Id = tarea.Id,
			Title = tarea.Title,
			Description = tarea.Description,
			IsCompleted = tarea.IsCompleted,
			Duedate = tarea.Duedate
		};


        return CreatedAtAction(nameof(GetTarea), new { id = response.Id }, response);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<TareaResponseDto>> GetTarea(int id)
	{
		var tarea = await _context.Tareas.FindAsync(id);
		if (tarea == null) return NotFound();
		return new TareaResponseDto
		{
			Id = tarea.Id,
			Title = tarea.Title,
			Description = tarea.Description,
			IsCompleted = tarea.IsCompleted,
			Duedate = tarea.Duedate
		};
    }

	[HttpPut("{id}")]
	public async Task<IActionResult> PutTarea(int id, TareaCreateDto tareaDto)
	{
		var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return NotFound();

		tarea.Title = tareaDto.Title;
		tarea.Description = tareaDto.Description;
		tarea.IsCompleted = tareaDto.IsCompleted;
		tarea.Duedate = tareaDto.Duedate;

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