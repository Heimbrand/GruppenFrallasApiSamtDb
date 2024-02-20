using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Kurs
{
    public int Id { get; set; }
    [Required]
    public string Namn { get; set; }
    public ICollection<Elev> Elever { get; set; }  
    public ICollection<Skola> Skolor { get; set; }

}