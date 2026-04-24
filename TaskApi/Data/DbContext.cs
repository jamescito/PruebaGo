using System;
using Microsoft.EntityFrameworkCore;



public class DbContext:Microsoft.EntityFrameworkCore.DbContext
{
	public DbContext(DbContextOptions <DbContext> options: base(options))
    {

	}
}
