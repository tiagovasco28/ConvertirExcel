using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelToTxt
{
    class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public string DatosConFormato()
        {
            return $"{Id.PadRight(5, ' ')}{Nombre.PadRight(100, ' ')}{Nombre2.PadRight(100, ' ')}{Apellido.PadRight(100, ' ')}{Email.PadRight(100, ' ')}";
        }


        public static Persona StringFromFile(String str)
        {
            Persona p = new Persona();
            p.Id = (str.Substring(0, 5).Trim());
            p.Nombre = (str.Substring(5, 100).Trim());
            p.Nombre2 = (str.Substring(105, 100).Trim());
            p.Apellido = (str.Substring(205, 100).Trim());
            p.Email = (str.Substring(305, 100).Trim());

            return p;
        }

        public string FormatDatos()
        {
            return 
                $"{"================================================"}\n{Id.PadRight(1, ' ')}{Nombre.PadRight(10, ' ')}{Nombre2.PadRight(10, ' ')}{Apellido.PadRight(10, ' ')}\n{Email.PadRight(10, ' ')}\n";
        }

    }
}
