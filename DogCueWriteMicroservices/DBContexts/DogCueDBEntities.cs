//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogCueWriteMicroservices.Models;
using Microsoft.EntityFrameworkCore;

namespace DogCueWriteMicroservices.DBContexts
{
    
    public partial class DogCueDBEntities : DbContext
    {
        public DogCueDBEntities(DbContextOptions<DogCueDBEntities> options) : base(options)
        {
        }

        public DogCueDBEntities() 
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
    }
}
