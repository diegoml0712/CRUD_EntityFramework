using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EntityFramework
{
    class Contexto : DbContext
    {
        public Contexto() : base("conexao")
        {

        }
        public DbSet<Agenda> ObjetoAgenda { get; set; }
    }
}
