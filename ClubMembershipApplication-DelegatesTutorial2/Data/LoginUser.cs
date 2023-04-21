using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using ClubMembershipApplication_DelegatesTutorial2.Data;
using ClubMembershipApplication_DelegatesTutorial2.Models;

namespace ClubMembershipApplication.Data
{
    public class LoginUser : ILogin
    {
        public Usuario Loguin(string emailAddress, string password)
        {
            Usuario usuario = null;

            using (var dbContext = new ClubMemebershipDbContext())
            {
                usuario = dbContext.Usuarios.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
            }
            return usuario;
        }

        
    }
}