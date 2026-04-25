using System;
using TaskApi.Interfaces;
using TaskApi.Models;
using TaskApi.Data;
namespace TaskApi.Repositories;


 public class TareaRepository : ITarearepository
{
	private readonly DbPrueba _context;

    public TareaRepository(DbPrueba Context)
	{
		_context = Context;
    }

	public async Task<IEnumerable<Tarea>> GetAllasync()
	{ 
		return await _context.Tareas.ToListAsync();
    }
	public async Task<Tarea> GetByIdAsync(int id)
	{
		return await _context.Tareas.FindAsync(id);
    }
	public async Task Addasync(Tarea tarea)
	{
		 await _context.Tareas.AddAsync(tarea);
		
    }
	public void Update(Tarea tarea)
	{
		_context.Tareas.Update(tarea);
    }
	public void Delete(Tarea tarea)
	{
		_context.Tareas.Remove(tarea);
	}
