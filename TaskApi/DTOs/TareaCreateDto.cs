using System;

namespace TaskApi.DTOs;

public class TareaCreateDto
{
	
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsCompleted { get; set; }
		public DateTime? Duedate { get; set; }

}
