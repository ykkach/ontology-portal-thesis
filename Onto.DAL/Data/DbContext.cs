using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Onto.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace Onto.DAL.Data
{
    public class OntologyContext : DbContext
    {
        public DbSet<OntologyConcept> OntologyConcepts { get; set; }
        public DbSet<OntologyProperty> OntologyProperties { get; set; }
        public DbSet<OntologyPropertyDomain> OntologyConceptProperties { get; set; }


        public OntologyContext(DbContextOptions<OntologyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<OntologyConcept>()
                        .HasKey(c => c.Uri);

            modelBuilder.Entity<OntologyConcept>()
                .HasMany(t => t.Children)
                .WithOne(t => t.Parent)
                .HasForeignKey(t => t.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OntologyConcept>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OntologyIndividual>()
                .HasKey(c => c.Uri);

            modelBuilder.Entity<OntologyIndividual>()
                .HasMany(c => c.DomainProperties)
                .WithOne(cp => cp.Concept)
                .HasForeignKey(cp => cp.ConceptDomainUri);

            modelBuilder.Entity<OntologyIndividual>()
                .HasMany(c => c.RangeProperties)
                .WithOne(cp => cp.Concept)
                .HasForeignKey(cp => cp.ConceptRangeUri);

            modelBuilder.Entity<OntologyProperty>()
                .HasKey(p => p.Uri);

            modelBuilder.Entity<OntologyProperty>()
                .HasMany(p => p.DomainConcepts)
                .WithOne(cp => cp.Property)
                .HasForeignKey(cp => cp.PropertyUri);

            modelBuilder.Entity<OntologyProperty>()
                .HasMany(p => p.RangeConcepts)
                .WithOne(cp => cp.Property)
                .HasForeignKey(cp => cp.PropertyUri);

            modelBuilder.Entity<OntologyPropertyDomain>()
                .HasKey(cp => new { cp.ConceptDomainUri, cp.PropertyUri });

            modelBuilder.Entity<OntologyPropertyRange>()
                .HasKey(cp => new { cp.ConceptRangeUri, cp.PropertyUri });

            modelBuilder.Entity<OntologyPropertyDomain>()
                .HasOne(cp => cp.Concept)
                .WithMany(c => c.DomainProperties)
                .HasForeignKey(cp => cp.ConceptDomainUri);

            modelBuilder.Entity<OntologyPropertyDomain>()
                .HasOne(cp => cp.Property)
                .WithMany(p => p.DomainConcepts)
                .HasForeignKey(cp => cp.PropertyUri);

            modelBuilder.Entity<OntologyPropertyRange>()
                .HasOne(cp => cp.Concept)
                .WithMany(c => c.RangeProperties)
                .HasForeignKey(cp => cp.ConceptRangeUri);

            modelBuilder.Entity<OntologyPropertyRange>()
                .HasOne(cp => cp.Property)
                .WithMany(p => p.RangeConcepts)
                .HasForeignKey(cp => cp.PropertyUri);
        }
    }
}
