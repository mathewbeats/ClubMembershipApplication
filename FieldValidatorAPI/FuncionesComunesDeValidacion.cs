using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



//funciones de validacion comunes


namespace FieldValidatorAPI
{
    //creacion de 5 delegados boolianos que reciben como parametro diferentes opciones de validacion.'
    //estos delegados serviran como parametros comunes para los campos de los usuarios del club de ciclismo.


    //delegado quereferencia a un metodo que tiene el proposito de asegurar que un campo de formulario no puede quedar vacio
    public delegate bool RequiredValidDel(string fieldVal);

    //este delgado referencia a un metodo que contrae el tamaño del texto entre un minimo y un maximo de caracteres
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);


    //este delegado referencia a un metodo que valida una fecha
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);

    //delegado que referencia a un metodo que valida un imput field valuenagainst a regular expresion pattern
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);

    //define un tipo de delegado que referencia a un metodo que valida un campo de texto contra otro campo de texto, 
    //usamos esto para guardar la referencia a un metodo que provide funcionalidad para saegurarse que el usuario
    //entry the correct chosen password so that it matches the original entry for the password field during the registration proceess
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    //
    public delegate bool MiDelegado(string text);
    

    public class FuncionesComunesDeValidacion
    {
        
        //2 paso: creamos 5 variables estaticas que apuntan a nuestros delegados

        //y luego creamos los metodos desde los que vamos a llamar a estos delegados abajo del todo

        public static RequiredValidDel _requiredValidDel = null;

        public static StringLengthValidDel _stringLengthValidDel = null;

        public static DateValidDel _dateValidDel = null;

        public static PatternMatchValidDel _patternMatchValidDel = null;

        public static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static MiDelegado _miDelegado = null;
        //para exponer nuestros objetos delegados, funciones void de abajo, para que puedan ser llamados por otro codigo vamnos a crear estas propiedades
        //creamos propiedades que apuntan a los delegados
        //con cada una de estas propiedades estamos creando un nuevo objeto delegado del tipo de delegado apropiado y le pasamos el metodo correspondiente
        //al constructor del tipo de delegado
        
        //4 paso.creacion de propiedades readonly, por eso solo llevan el get y no el set;para poner nuestros objetos delegados a calling code, vamos a crear una public static
        //readonly property para cada related delegado, con cada una de estas propiedades publicas creamos un nuevo objeto delegado del tipo de delegado apropioado
        //y le pasamos el nombre del metodo void apropiado al constructor del tipo de variable del delegado
        //usamos una instancia singleton para asegurarnos que solo puede ser creada una instancia de estos objetos delegados.
        public static MiDelegado Midelegado
        {
            get
            {
                if (_miDelegado == null)
                    _miDelegado = new MiDelegado(DelegadoValidable);
                return _miDelegado; 
            }
        }


        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequireFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);

                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }

        //3 paso: vamos a crear los metodos para implementar las variables que apuntan a nuestros delegados 

        public static bool DelegadoValidable(string text)
        {
            if (!string.IsNullOrEmpty(text))
                return true;
            else return false;
        }


        private static bool RequireFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max) 
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;    

            }
            else
            {
                return false;
            }
            
        }


        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if(DateTime.TryParse(dateTime, out validDateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }    


        private static bool FieldPatternValid(string fieldVal, string regularExpresionPattern)
        {
            Regex regex = new Regex(regularExpresionPattern);
                if (regex.IsMatch(fieldVal))
                return true;
            else
            {
                return false;
            }
        }

        private static bool FieldComparisonValid(string field1, string field2) 
        {
            if (field1.Equals(field2))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }

    }
}
