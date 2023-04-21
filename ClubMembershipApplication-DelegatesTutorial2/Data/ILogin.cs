using ClubMembershipApplication_DelegatesTutorial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication_DelegatesTutorial2.Data
{
    public interface ILogin
    {
        Usuario Loguin(string emailAddress, string passwods);
    }
}
