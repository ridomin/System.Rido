using System;
using System.Collections.Generic;
using System.Text;

namespace TestRep2
{
    public enum CifNif
    {
        Incorrect,	// El Nif o el Cif es incorrecto
        Nif,		// Es un Nif
        Cif,		// Es un Cif
    }

    public class NifCifValidator
    {


        /// <summary>
        /// Determina si es o no un número
        /// </summary>
        /// <param name="numero">Cadena numérica</param>
        /// <returns>Verdadero si es un entero</returns>
        static bool IsNumber(string numero)
        {            
            bool isNumber = true;
            try
            {
                int.Parse(numero);
            }
            catch
            {
                isNumber = false;
            }
            return isNumber;
        }


        public static  CifNif IsNifCif(string nif)
        {
            // Miramos si es NIF
            string numero;
            int aux;
            string cadena = nif.ToUpper();
            string LETRA_NIF = "TRWAGMYFPDXBNJZSQVHLCKE";
            string LETRA_CIF = "ABCDEFGHIJ";
            if (cadena.Length != 9)
            {
                return CifNif.Incorrect;
            }
            if (cadena[0] >= '0' && cadena[0] <= '9')
            {
                // Es un NIF de persona física
                numero = cadena.Substring(0, 8);
                if (IsNumber(numero))
                {
                    aux = (int.Parse(numero) % 23);
                    if (cadena[8] == LETRA_NIF[aux])
                    {
                        return CifNif.Nif;
                    }
                }
                return CifNif.Incorrect;
            }
            if (cadena[0] == 'K' || cadena[0] == 'L' || cadena[0] == 'X' || cadena[0] == 'M')
            {
                // Personas fisicas NIF especial
                numero = cadena.Substring(1, 7);
                if (IsNumber(numero))
                {
                    aux = (int.Parse(numero) % 23);
                    if (cadena[8] == LETRA_NIF[aux])
                    {
                        return CifNif.Nif;
                    }
                }
                return CifNif.Incorrect;
            }

            // Miramos si es CIF
            if (cadena[0] == 'P' || cadena[0] == 'Q' || cadena[0] == 'S' || cadena[0] == 'N')
            {
                // Entidad pública
                numero = cadena.Substring(1, 7);
                if (IsNumber(numero))
                {
                    aux = NifDigitoControl(numero, 0);
                    if (cadena[8] == LETRA_CIF[aux - 1])
                    {
                        return CifNif.Cif;
                    }
                }
                return CifNif.Incorrect;
            }
            // A partir de aqui pasan el resto de CIF
            numero = cadena.Substring(1, 7);
            if (IsNumber(numero))
            {
                aux = NifDigitoControl(numero, 1);
                if (int.Parse(cadena[8].ToString()) == aux)
                {
                    return CifNif.Cif;
                }
            }

            // Si no hemos detectado que es un NIF o un CIF correcto, es incorrecto
            return CifNif.Incorrect;
        }

        /// <summary>
        /// Determinar el dígito de control del NIF
        /// </summary>
        /// <param name="cadena">Cadena de NIF / CIF</param>
        /// <param name="truncar">Número de Control</param>
        /// <returns>Dígito de control</returns>
        static internal int NifDigitoControl(string cadena, int truncar)
        {
            int suma = 0;
            int aux = 0;
            string auxStr;
            for (int i = 1; i <= cadena.Length; i++)
            {
                if ((i % 2) == 0) // Es par, se multiplica por 1 y se suma
                {
                    suma = suma + int.Parse(cadena.Substring(i - 1, 1));
                }
                else // Es impar, se multiplica por 2 y se suma
                {
                    aux = int.Parse(cadena.Substring(i - 1, 1)) * 2;
                    auxStr = aux.ToString();
                    if (auxStr.Length == 2)
                    {
                        aux = int.Parse(auxStr.Substring(0, 1)) + int.Parse(auxStr.Substring(1));
                    }
                    suma = suma + aux;
                }
            }
            aux = 10 - (suma % 10);
            if ((aux == 10) && (truncar == 1))
            {
                aux = 0;
            }
            return aux;
        }
    }
}
