using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entidades;

namespace IO
{
    public class PuntoJson<T> : Archivo, IArchivo<T>
            where T : class
    {
        protected override string Extension
        {
            get
            {
                return ".json";
            }
        }

        /// <summary>
        /// Si ya existe un archivo en la ruta existente y su extension es .json, se serializa el contenido al archivo existente.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        public void Guardar(string ruta, T contenido)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }
      
        /// <summary>
        /// Valida que la extension sea .json, si es asi, serializa el contenido al archivo que eligio el usuario.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        /// <summary>
        /// Serializa el contenido al archivo especificada.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }

        /// <summary>
        /// Valida que exista el archivo y su extension sea .json, si es asi, deserializa el contenido y lo retorna.
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>null si el archivo no cumple las condiciones o sino, el contenido deserializado.</returns>
        public T Leer(string ruta)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string json = streamReader.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
            }

            return null;
        }
    }
}
