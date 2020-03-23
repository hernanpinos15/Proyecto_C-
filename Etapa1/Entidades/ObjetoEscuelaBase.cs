using System;

namespace CoreEscuela.Entidades
{
    //abstract que no pueden crear instancias pero si exite la herencia
    public class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}