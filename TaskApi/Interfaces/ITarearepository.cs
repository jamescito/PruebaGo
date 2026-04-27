using System;
using TaskApi.Models;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
namespace TaskApi.Interfaces;

public interface ITareaRepository
{
		Task<IEnumerable<Tarea>> GetAllAsync();
<<<<<<< Updated upstream
		Task<Tarea?> GetByIdAsync(int id);
=======
		Task<Tarea> GetByIdAsync(int id);
>>>>>>> Stashed changes
		Task AddAsync(Tarea tarea);
		void Update(Tarea tarea);
		void Delete(Tarea tarea);
}
