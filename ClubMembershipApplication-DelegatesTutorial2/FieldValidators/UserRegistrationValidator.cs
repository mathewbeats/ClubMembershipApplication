using ClubMembershipApplication.Data; // Importa el namespace de ClubMembershipApplication.Data
using ClubMembershipApplication_DelegatesTutorial2.FieldValidators; // Importa el namespace de ClubMembershipApplication_DelegatesTutorial2.FieldValidators
using FieldValidatorAPI; // Importa el namespace de FieldValidatorAPI
using System; // Importa el namespace de System
using System.Collections.Generic; // Importa el namespace de System.Collections.Generic
using System.Text; // Importa el namespace de System.Text

namespace ClubMembershipApplication.FieldValidators // Namespace del archivo
{
    public class UserRegistrationValidator : IFieldValidatorI // Define la clase UserRegistrationValidator que implementa la interfaz IFieldValidatorI
    {
        const int FirstName_Min_Length = 2; // Define la longitud mínima permitida para el primer nombre
        const int FirstName_Max_Length = 100; // Define la longitud máxima permitida para el primer nombre
        const int LastName_Min_Length = 2; // Define la longitud mínima permitida para el apellido
        const int LastName_Max_Length = 100; // Define la longitud máxima permitida para el apellido

        // Define un delegado llamado EmailExistsDel que acepta una cadena (emailAddress) como entrada y devuelve un valor booleano
        delegate bool EmailExistsDel(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null; // Define un delegado FieldValidatorDel
        RequiredValidDel _requiredValidDel = null; // Define un delegado RequiredValidDel
        StringLengthValidDel _stringLenthValidDel = null; // Define un delegado StringLengthValidDel
        DateValidDel _dateValidDel = null; // Define un delegado DateValidDel
        PatternMatchValidDel _patternMatchValidDel = null; // Define un delegado PatternMatchValidDel
        CompareFieldsValidDel _compareFieldsValidDel = null; // Define un delegado CompareFieldsValidDel

        EmailExistsDel _emailExistsDel = null; // Define un delegado EmailExistsDel cuyo objetivo es ver si el email del usuario ya ha sido registrado en el sistema anteriormente

        string[] _fieldArray = null; // Define un arreglo de strings llamado _fieldArray
        IRegister _register = null; // Define un objeto IRegister llamado _register

        // Define una propiedad pública llamada FieldArray que devuelve un arreglo de strings, implementada desde la interface
        public string[] fieldArray
        {
            get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            }
        }

        // Define una propiedad pública llamada ValidatorDel que devuelve un delegado FieldValidatorDel, implementada desde la interface
        public FieldValidatorDel validatorDel => _fieldValidatorDel;

    
        // Define el constructor de UserRegistrationValidator que acepta un objeto IRegister como entrada
        public UserRegistrationValidator(IRegister register)
        {
            _register = register; // Asigna el objeto IRegister proporcionado a _register
        }

        // Define el método InitialiseValidatorDelegates que inicializa todos los delegados que se utilizarán para validar los campos
        //metodo que viene implementado por la interface, aqui lo desarrollamos

        public void InitialiseValidationDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);
            _emailExistsDel = new EmailExistsDel(_register.EmailExists);

            _requiredValidDel = FuncionesComunesDeValidacion.RequiredFieldValidDel;
            _stringLenthValidDel = FuncionesComunesDeValidacion.StringLengthFieldValidDel;
            _dateValidDel = FuncionesComunesDeValidacion.DateFieldValidDel;
            _patternMatchValidDel = FuncionesComunesDeValidacion.PatternMatchValidDel;
            _compareFieldsValidDel = FuncionesComunesDeValidacion.FieldsCompareValidDel;
        }

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {

            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistsDel(fieldValue)) ? $"This email address already exists. Please try again{Environment.NewLine}" : fieldInvalidMessage;

                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLenthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLenthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password])) ? $"Your entry did not match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Uk_PhoneNumber_RegEx_Pattern)) ? $"You did not enter a valid UK phone number{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Uk_Post_Code_RegEx_Pattern)) ? $"You did not enter a valid UK post code{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exists");

            }

            return (fieldInvalidMessage == "");

        }

      
    }
}