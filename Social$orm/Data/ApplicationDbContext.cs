using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_orm.Models;

namespace Social_orm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

      
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
       public DbSet<Beneficiar> Beneficiars { get; set; }

       public DbSet<Wife> Wives { get; set; }

        public DbSet<Child> children { get; set; }

        public DbSet<Address> addresses {  get; set; }

        public DbSet<Aid> aids { get; set; }

        public DbSet<Belongings> belongings { get; set; }

        public DbSet<Disease> diseases { get; set; }

        public DbSet<Loans> loans { get; set; }

        public DbSet<SocialHelp> socialHelps { get; set; }

        public DbSet<Work> works { get; set; }


        
        
    }
}
