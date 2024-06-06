using System.ComponentModel.DataAnnotations;

namespace Filtro.Models;

public class Enrollment
{
    public int Id { get; set; }

    [Required]
    public required DateOnly Date { get; set; }

    [Required]
    public required int StudentId { get; set; }

    public Student? Student { get; set; }

    [Required]
    public required int CourseId { get; set; }

    public Course? Course { get; set; }

    [Required]
    public required string Status { get; set; }
}