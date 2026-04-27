using System;
using TaskApi.Models;

namespace TaskApi.Interfaces;

public interface ITareaRepository
{
		Task<IEnumerable<Tarea>> GetAllAsync();
		Task<Tarea?> GetByIdAsync(int id);
		Task AddAsync(Tarea tarea);
		void Update(Tarea tarea);
		void Delete(Tarea tarea);
}
