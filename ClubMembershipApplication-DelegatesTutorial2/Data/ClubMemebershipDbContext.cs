using ClubMembershipApplication_DelegatesTutorial2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication_DelegatesTutorial2.Data
{

    //esta clase hereda de DbContext, reside en microsoft.entityframeworkcore.
    
    public class ClubMemebershipDbContext: DbContext
    {
       //configuramos la cadena de conexion a sqlite dentro de un metodo override void llamado OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
            base.OnConfiguring(optionsBuilder); 

            //añadimos la cadena de conexion y luego llamamos desde base al metodo OnConfiguring y le pasamos las opciones
            //por parametro


        }
        //entitiyframework usara esta propiedad para manejar los datos en sqlite
        //sin el dbset no podriamos hacer migraciones ya que es una cadena con el orm
        //en este caso EntityFramework 

        //creamos la migracion con EntityFramewokr despues d instalar los paquetes
        // entityframeworkcore.sqlite y entityframeworkcore.tools

        //Add-Migration MigracionInicial... o cualquier nombre

        public DbSet<Usuario> Usuarios { get; set; }    
    }
}
