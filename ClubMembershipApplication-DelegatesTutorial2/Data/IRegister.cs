using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Data
{
    public interface IRegister
    {

        //el codigo que implemente este metodo hara que el usuario rellene un formulario
        //y los datos se guarden en la base de datos sqlite, retorna un valor bool
        bool Register(string[] fields);

        //metodo que sera referenciado por un delegado de validacion, chequeara si el email
        //que ha introducido el usuario esta ya integrado en la base de datos, retorna un valor bool

        bool EmailExists(string emailAddress);
    }
}