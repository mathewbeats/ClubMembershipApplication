using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;

using ClubMembershipApplication_DelegatesTutorial2.Data;
using ClubMembershipApplication_DelegatesTutorial2.FieldValidators;
using ClubMembershipApplication_DelegatesTutorial2.Models;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;
        public IFieldValidatorI FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password");

            string password = Console.ReadLine();

            Usuario usuario = _loginUser.Loguin(emailAddress, password);

            if (usuario != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(usuario);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match any of our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }

        }
    }
}