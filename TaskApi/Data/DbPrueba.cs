using System;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

    public class DbPrueba: DbContext
{
	public DbPrueba(DbContextOptions <DbPrueba> options): base(options) {	}

	public DbSet<Tarea> Tareas { get; set; }
}
