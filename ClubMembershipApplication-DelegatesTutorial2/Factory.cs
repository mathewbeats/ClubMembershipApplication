using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.Views;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication_DelegatesTutorial2.Data;
using ClubMembershipApplication_DelegatesTutorial2.FieldValidators;


namespace ClubMembershipApplication
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidatorI userRegistrationValidator = new UserRegistrationValidator(register);
            userRegistrationValidator.InitialiseValidationDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationValidator);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView);

            return mainView;

        }
    }
}