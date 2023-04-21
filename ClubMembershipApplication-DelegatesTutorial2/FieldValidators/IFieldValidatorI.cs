using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication_DelegatesTutorial2.FieldValidators
{
    // Definición del delegado FieldValidatorDel, es muy importante porque puede referenciar a un metodo que puede
    //validar los campos  de cualuier formulario. usaremos esta defininicion  de delegado para referenciarla a un metodo para validar campos
    //presentados al usuario en nuestra clase Registration View.
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);

    // Definición de la interfaz IFieldValidatorI
    public interface IFieldValidatorI
    {
        // Método que inicializa los delegados de validación
        void InitialiseValidationDelegates();

        // Propiedad que devuelve un array de cadenas con los valores de los campos del formulario
        string[] fieldArray { get; }

        // Propiedad que devuelve una instancia del delegado FieldValidatorDel que se utilizará para validar los campos del formulario
        FieldValidatorDel validatorDel { get; }
    }
}
