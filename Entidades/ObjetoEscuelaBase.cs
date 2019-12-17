using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string uniqueId { get ; private set; }
        public string nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            uniqueId = Guid.NewGuid().ToString();
        }
    }
}