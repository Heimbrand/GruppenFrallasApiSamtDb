using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Skola
{
    public int Id { get; set; }
    [Required]
    public string Namn { get; set; }
    public ICollection<Elev> Elever { get; set; }
    public ICollection<Kurs> Kurser { get; set; }
}