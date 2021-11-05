using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelToTxt
{
    class GuardarDatos
    {

        public String Carpeta { get; set; }
        public void Guardar(Persona p)
        {
            string archivo = "C:\\datos.txt";
            string contenido = LeerContenido(archivo);
            contenido += p.DatosConFormato();
            GuardarContenido(archivo, contenido);
        }

        public String LeerContenido(string archivo)
        {
            if (!File.Exists(archivo)) return "";
            return File.ReadAllText(archivo);
        }

        public void GuardarContenido(String archivo, String contenido)
        {
            if (!File.Exists(archivo)) File.Create(archivo);
            File.WriteAllText(archivo, contenido);
        }


    }


}

