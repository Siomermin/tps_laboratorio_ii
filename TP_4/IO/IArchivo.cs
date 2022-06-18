namespace IO
{
    public interface IArchivo<T>
    {
        public void Guardar(string ruta, T contenido);
        void GuardarComo(string ruta, T contenido);
        T Leer(string ruta);
    }
}