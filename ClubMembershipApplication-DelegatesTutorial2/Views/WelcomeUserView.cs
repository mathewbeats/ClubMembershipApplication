using ClubMembershipApplication.FieldValidators;

using ClubMembershipApplication_DelegatesTutorial2.FieldValidators;
using ClubMembershipApplication_DelegatesTutorial2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Views
{


    public class WelcomeUserView : IView
    {
        Usuario _usuario = null;

        public WelcomeUserView(Usuario usuario)
        {
            _usuario = usuario;
        }

        public IFieldValidatorI FieldValidator => null;

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();

            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_usuario.FirstName}!!{Environment.NewLine}Welcome to the Cycling Club!!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}