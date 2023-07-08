using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infra.Data.Repository
{
    using AdaTech.Domain.Models;
    public class AppContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AdaTech");
        }

        public DbSet<Card> Cards { get; set; }    

    }
}
