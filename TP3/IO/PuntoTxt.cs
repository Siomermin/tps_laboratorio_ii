using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class PuntoTxt : Archivo, IArchivo<string>
    {
        protected override string Extension
        {
            get
            {
                return ".txt";
            }
        }

        /// <summary>
        /// Valida que la extension sea .txt, si es asi, escribe el contenido al archivo que eligio el usuario.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        public void GuardarComo(string ruta, string contenido)
        {
            if (ValidarExtension(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }

        /// <summary>
        /// Escribe el contenido a al archivo especificado.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        private void GuardarArchivo(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.WriteLine(contenido);
            }
        }
       
        public string Leer(string ruta)
        {
            throw new NotImplementedException();
        }

        public void Guardar(string ruta, string contenido)
        {
            throw new NotImplementedException();
        }
    }
}
