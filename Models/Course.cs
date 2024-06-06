using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filtro.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required int TeacherId { get; set; }

    public Teacher? Teacher { get; set; }

    [Required]
    public required string Schedule { get; set; }

    [Required]
    public required string Duration { get; set; }

    [Required]
    public required int Capacity { get; set; }

    [JsonIgnore]
    public List<Enrollment>? Enrollments { get; set; }  
}