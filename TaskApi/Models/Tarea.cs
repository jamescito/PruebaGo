using System;
using System.ComponentModel.DataAnnotations;	

namespace TaskApi.Models;

    public class Tarea
{

	public int Id { get; set; }
	[Required]
    public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsCompleted { get; set; } = false;
    public DateTime? Duedate { get; set; }
    
}	