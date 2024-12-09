using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_FullStack_EntityFramework.Entities;

public class RequestContext : DbContext
{
    public RequestContext(DbContextOptions<RequestContext> options) : base(options)
    { 

    }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<RequestItem> requestItem { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestItem>(eb =>
        {
            eb.Property(ri => ri.CreatedDate).HasPrecision(3);
            eb.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(c => c.UpdatedDate).ValueGeneratedOnUpdate();
            eb.HasMany(ri => ri.Comments)
            .WithOne(c => c.RequestItem)
            .HasForeignKey(c => c.RequestItemId);
            eb.HasMany(ri => ri.Tags)
            .WithMany(t => t.RequestItems)
            .UsingEntity<RequestItemTag>(
                r => r.HasOne(rit => rit.Tag)
                .WithMany()
                .HasForeignKey(rit => rit.TagId),

                w => w.HasOne(wit => wit.RequestItem)
                .WithMany()
                .HasForeignKey(rit => rit.RequestItemId),
            wit =>
            {
                wit.HasKey(x => new { x.TagId, x.RequestItemId });
                wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(c => c.UpdatedDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(u => u.Email).IsRequired();
                eb.Property(u => u.Nick).HasMaxLength(100);
                eb.HasMany(ri => ri.RequestItems)
                 .WithOne(c => c.Author)
                 .HasForeignKey(c => c.AuthorId);
            });

        });
    }
}
