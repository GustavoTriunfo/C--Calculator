using System;
using Microsoft.EntityFrameworkCore;

namespace calculadora.Models
{
    public class ContextModels : DbContext
    {
        public ContextModels(DbContextOptions<ContextModels> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OperationModels> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationModels>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private static OperationModels[] GetProducts()
        {
            return new OperationModels[]
            {
            new OperationModels
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                Text = "((1+2)x(3+2)"
            },


            new OperationModels
            {
                Id = Guid.NewGuid(),
                Text = "((6/2)+1)",
                CreationTime = DateTime.Now,
            }

            };
        }
    }
}

