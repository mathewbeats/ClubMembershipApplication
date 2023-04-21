using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication_DelegatesTutorial2.FieldValidators
{

    //este Enum sera usado para indexar un array que contienen
    //campos de validacion para el formulario de registro del usuario.
    public class FieldConstants
    {
        public enum UserRegistrationField
        {
            EmailAddress,
            FirstName,
            LastName,
            Password,
            PasswordCompare,
            DateOfBirth,
            PhoneNumber,
            AddressFirstLine,
            AddressSecondLine,
            AddressCity,
            PostCode
        }
    }
}
