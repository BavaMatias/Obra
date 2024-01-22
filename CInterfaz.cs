using System;
using System.Collections;

namespace reparar
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("**********************************************************");
            Console.WriteLine("*                Sistema de Gestión de Obra              *");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("\n[A]     Establecer sueldo");
            Console.WriteLine("\n[B]     Agregar empleado");
            Console.WriteLine("\n[C]     Mostrar empleados");
            Console.WriteLine("\n[D]     Agregar obra");
            Console.WriteLine("\n[E]     Cambiar encargado de obra");
            Console.WriteLine("\n[F]     Mostrar obra");
            Console.WriteLine("\n[G]     Agregar obrero a obra");
            Console.WriteLine("\n[H]     Borrar profesional");
            Console.WriteLine("\n[S]     Salir");
            Console.WriteLine("\n********************************************************");
            return CInterfaz.PedirDato("Opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
        }

        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
