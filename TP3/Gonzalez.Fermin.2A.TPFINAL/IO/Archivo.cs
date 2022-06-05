using System;
using System.IO;

namespace IO
{
    public abstract class Archivo
    {
        protected abstract string Extension { get; }

        /// <summary>
        /// Valida si existe el archivo en la ruta especificada.
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>(bool)true si existe y si no existe, lanza una excepcion.</returns>
        public bool ValidarSiExisteElArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new ArchivoIncorrectoException("El archivo no se encontro");
            }

            return true;
        }

        /// <summary>
        /// Valida que la extension del archivo sea correcta.
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>(bool)true si es la correcta, y si no es, lanza una excepcion.</returns>
        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
            {
                throw new ArchivoIncorrectoException($"El archivo no tiene la extension {Extension}");
            }

            return true;
        }
    }
}
