using System;

namespace CorEscuela
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public int añoFundacion;
        public string ceo;

        public void Timbrar()
        {
            //Funcion para timbrar
            Console.Beep(2000, 3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela();
            miEscuela.nombre = "Hernan Academy";
            miEscuela.direccion = "Cr 9 calle 72";
            miEscuela.añoFundacion = 2012;
            Console.WriteLine("Timbre");
            miEscuela.Timbrar();
            //Console.WriteLine("Hello World!");
        }
    }
}
