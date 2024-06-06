using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filtro.Models;

public class Teacher
{
    public int Id { get; set; }

    [Required]
    public required string Names { get; set; }

    [Required]
    public required string Specialty { get; set; }

    [Required]
    public required string Phone { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required int YearsExperience { get; set; }

    [JsonIgnore]
    public List<Course>? Courses { get; set; }
}