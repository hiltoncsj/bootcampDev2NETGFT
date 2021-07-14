using APICatalogoJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.ViewModel
{
    public class Context : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = APICatalogoJogos; Integrated Security = True");
        }
    }
}
