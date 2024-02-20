using DataAccess.Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GruppenFrallasApiSamtDb.Extensions;

public static class ElevEndpointExtensions
{
    public static IEndpointRouteBuilder MapElevEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/elever");

        group.MapGet("/", GetAllaElever);

        group.MapPost("/", AddElev);

        group.MapDelete("/{id}", RemoveElev);

        group.MapPut("/{id}", ReplaceElev);

        return app;
    }
    private static void AddElev(Elev elev, ElevDbContext elevDbContext)
    {
        elevDbContext.Elever.Add(elev);
        elevDbContext.SaveChanges();

    }
    private static DbSet<Elev> GetAllaElever(ElevDbContext elevDbContext)
    {
        return elevDbContext.Elever;
    }
    private static void RemoveElev(ElevDbContext elevDbContext, int id)
    {
        var elev = elevDbContext.Elever.FirstOrDefault(e => e.Id == id);
        elevDbContext.Elever.Remove(elev);
        elevDbContext.SaveChanges();
    }
    private static void ReplaceElev(ElevDbContext elevDbContext, [FromBody] Elev elev) // Varför är detta inte ens patch? Och hur skickar man in hela objekt?
    {
        var elevToUpdate = elevDbContext.Elever.FirstOrDefault(e => e.Id == elev.Id);
        elevToUpdate.Kurser = elev.Kurser;
        elevToUpdate.Namn = elev.Namn;
        elevDbContext.SaveChanges();
    }
}