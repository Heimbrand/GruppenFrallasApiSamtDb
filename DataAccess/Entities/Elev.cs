using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Elev
{
    public int Id { get; set; }
    [Required]
    public string Namn { get; set; }

    public ICollection<Kurs> Kurser { get; set; }
}