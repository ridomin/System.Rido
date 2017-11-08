using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Nif
{
    public class NifGenerator
    {
        static Random rnd = new Random();

        public static string GenerateNif(Int32 i)
        {
            const string LETRA_NIF = "TRWAGMYFPDXBNJZSQVHLCKE";
            return i.ToString().PadLeft(8, '0') + LETRA_NIF[i % 23];
        }
        
        public static string GenerateRandomNif()
        {            
            return GenerateNif(rnd.Next(0, 99999999));
        }
        
        public static List<string> GenerateRandomNif(int numResults)
        {
            List<string> nifs = new List<string>(numResults);
            for (int i = 0; i < numResults; i++)
            {
                string nif = GenerateRandomNif();
                if (nifs.Contains(nif))
                {
                    throw new ArgumentOutOfRangeException("numResults", "Se han generado nifs repetidos: " + nif);
                }
                nifs.Add(nif);
            }
            return nifs;
        }
    }
}
