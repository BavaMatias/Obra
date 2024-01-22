using System;
using System.Collections;

namespace reparar
{
    public abstract class CEmpleado : IComparable
    {
        private string nombre;
        private string apellido;
        private uint legajo;
        private static float haberMensual;
        private float sueldo;

        public CEmpleado(string nom, string ape, uint leg)
        {
            this.nombre = nom;
            this.apellido = ape;
            this.legajo = leg;
        }

        public static void setMonto(float monto)
        {
            CEmpleado.haberMensual = monto;
        }
        public static float getMonto()
        {
            return CEmpleado.haberMensual;
        }
        public uint getLegajo()
        {
            return this.legajo;
        }

        public void setSueldo(float suel)
        {
            this.sueldo = suel;
        }
        public float getSueldo()
        {
            return this.sueldo;
        }
        public int CompareTo(object aux)
        {
            if (aux is CEmpleado)
            {
                return (int)(this.apellido.CompareTo(((CEmpleado)aux).apellido));
            }
            return int.MaxValue;
        }
        

        public virtual string ToString()
        {
            return "Apellido: " + this.apellido + " Nombre: " + this.nombre + " Legajo: " + this.legajo + " Sueldo: " + this.sueldo;
        }
    }
}
