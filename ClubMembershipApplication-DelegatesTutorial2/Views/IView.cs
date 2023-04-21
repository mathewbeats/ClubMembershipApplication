using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication_DelegatesTutorial2.FieldValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Views
{
    public interface IView
    {
        void RunView();
        IFieldValidatorI FieldValidator { get; }
    }
}