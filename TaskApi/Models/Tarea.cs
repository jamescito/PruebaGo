using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Text.Json.Serialization;

namespace TaskApi.Models;

    public class Tarea
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
	[Required]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsCompleted { get; set; } = false;
    public DateTime? Duedate { get; set; }
    
}	