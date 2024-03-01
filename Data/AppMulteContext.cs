using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppMulte.Models;
using Microsoft.EntityFrameworkCore;


public class AppMulteContext : DbContext
{
    public AppMulteContext(DbContextOptions<AppMulteContext> options) : base(options) { }

    public DbSet<Agente> Agenti { get; set; }
    public DbSet<Anagrafica> Anagrafica { get; set; }
    public DbSet<Multa> Multe { get; set; }
    public DbSet<Verbale> Verbali { get; set; }
    public DbSet<Violazione> Violazioni { get; set; }
}