using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filtro.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public required string Names { get; set; }

    [Required]
    public required DateOnly BirthDate { get; set; }

    [Required]
    public required string Address { get; set; }

    [Required]
    public required string Email { get; set; }

    [JsonIgnore]
    public List<Enrollment>? Enrollments { get; set; }
}