using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMaisDDD.Infra.Data;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Infra.Data.Map;


namespace FaleMaisDDD.Infra.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
            : base("FaleMaisConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Administrador> Administradores { get; set; }
        public IDbSet<Plano> Planos { get; set; }
        public IDbSet<Preco> Precos { get; set; }
        public IDbSet<DDD> DDDs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministradorMap());            
            modelBuilder.Configurations.Add(new PlanoMap());  
            modelBuilder.Configurations.Add(new PrecoMap());  
            modelBuilder.Configurations.Add(new DDDMap());  
        }
        
    }
}
