using System;

namespace TaskApi.Interfaces;

public interface ITarearepository
{
		Task<IEnumerable<Tarea>> GetAllsAsync();
		Task<Tarea> GetByIdAsync(int id);
		Task Addasync(Tarea tarea);
		Task UpdateAsync(Tarea tarea);
		Task DeleteAsync(int id);
}
