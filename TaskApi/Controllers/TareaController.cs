using System;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskApi.DTOs;
using TaskApi.Interfaces;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TareaController : ControllerBase
{
	//private readonly DbPrueba _context;
	private readonly IUnitOfWork _unitOfWork;

   /* public TareaController(DbPrueba context)
	{
		_context = context;
	}*/

	public TareaController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
    }

    [HttpGet]
	public async Task<ActionResult<IEnumerable<TareaResponseDto>>> GetTareas()
	{
		//var tareas = await _context.Tareas.ToListAsync();
		var tareas = await _unitOfWork.Tareas.GetAllAsync();

      var response = tareas.Select(t => new TareaResponseDto
		{
			Id = t.Id,
			Title = t.Title,
			Description = t.Description,
			IsCompleted = t.IsCompleted,
			Duedate = t.Duedate
		}).ToList();
		return Ok(response);
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

       /* _context.Tareas.Add(tarea);
		await _context.SaveChangesAsync();*/

		await _unitOfWork.Tareas.AddAsync(tarea);
		await _unitOfWork.CompleteAsync();
		

        var response = new TareaResponseDto
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
		//var tarea = await _context.Tareas.FindAsync(id);
		var tarea = await _unitOfWork.Tareas.GetByIdAsync(id);
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
		//var tarea = await _context.Tareas.FindAsync(id);
		var tarea = await _unitOfWork.Tareas.GetByIdAsync(id);
        if (tarea == null) return NotFound();

		tarea.Title = tareaDto.Title;
		tarea.Description = tareaDto.Description;
		tarea.IsCompleted = tareaDto.IsCompleted;
		tarea.Duedate = tareaDto.Duedate;

		
        try
		{
            //await _context.SaveChangesAsync();
            _unitOfWork.Tareas.Update(tarea);
            await _unitOfWork.CompleteAsync();

        }
        catch (DbUpdateConcurrencyException)
		{
			//if (!_context.Tareas.Any(e => e.Id == id)) return NotFound();
			//else throw;
			throw;
        }
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTarea(int id)
	{
		//var tarea = await _context.Tareas.FindAsync(id);
		var tarea = await _unitOfWork.Tareas.GetByIdAsync(id);
        if (tarea == null) return NotFound();
	  //_context.Tareas.Remove(tarea);
		//await _context.SaveChangesAsync();
		_unitOfWork.Tareas.Delete(tarea);
		await _unitOfWork.CompleteAsync();
        return NoContent();
	}
}