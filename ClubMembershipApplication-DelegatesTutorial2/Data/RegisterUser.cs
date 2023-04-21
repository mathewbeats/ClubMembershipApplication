using ClubMembershipApplication.Data;
using ClubMembershipApplication_DelegatesTutorial2.FieldValidators;
using ClubMembershipApplication_DelegatesTutorial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication_DelegatesTutorial2.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMemebershipDbContext())
            {
                emailExists = dbContext.Usuarios.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMemebershipDbContext())
            {
                Usuario usuario = new Usuario()    
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode]

                };

                //salvamos la informacion en la base de datos del usuario (Usuario usuario = new Usuario)

                dbContext.Usuarios.Add(usuario);

                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
