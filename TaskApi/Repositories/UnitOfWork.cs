using System;
using TaskApi.Interfaces;
using TaskApi.Models;
using TaskApi.Data;

namespace TaskApi.Repositories;

public class UnitOfWork: IUnitOfWork
{
	private readonly DbPrueba _context;

	public ITareaRepository Tareas { get; private set; }

	public UnitOfWork(DbPrueba context)
	{
		_context = context;
		Tareas = new TareaRepository(_context);
    }

	public async Task<int> CompleteAsync() =>  await _context.SaveChangesAsync();

	public void Dispose()
	{
		_context.Dispose();
    }
}
