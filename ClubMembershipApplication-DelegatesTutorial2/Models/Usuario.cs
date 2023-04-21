using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication_DelegatesTutorial2.Models
{
    public class Usuario
    {
        //decoraremos el id con un atributo de generacion de base de datos
        //pasamos (DatabaseGeneratedOption.Identity)] como argumento al atributo de databasegenerated

        //ahora crearemos una carpeta modelo y luego a traves de la CLA crearemos la base de datos
        //queremos que sea primary Key en la database

        //instalaremos el paquete entityframeowkrcore.sqlite
        //tambien instalaremos el paquete entittyframeworkcore tools
        //ahora ya podremos hacer las migraciones a la base de datos una vez creemos nuestra clase dbcontext

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string AddressFirstLine { get; set; }

        public string AddressSecondLine { get; set; }

        public string AddressCity { get; set; }

        public string PostCode { get; set; }




    }
}
