using System;
using TaskApi.Models;
using TaskApi.Data;
using TaskApi.Interfaces;
using TaskApi.Repositories;


namespace TaskApi.Interfaces;

public interface IUnitOfWork: IDisposable
{
	ITarearepository Tareas { get; }
	Task<int> CompleteAsync();
}
