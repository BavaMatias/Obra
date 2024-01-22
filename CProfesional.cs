using System;
using System.Collections;

namespace reparar
{
    public class CProfesional : CEmpleado
    {
        private string titulo;
        private ulong matricula;
        private string consejo;
        private static float canon;
        private ushort extra;
        private bool encargado;
        

        public CProfesional(string nom,string ape, uint leg,string tit, ulong mat, string con, ushort ext) : base(nom,ape,leg)
        {
            this.titulo = tit;
            this.matricula = mat;
            this.consejo = con;
            this.extra = ext;
            setSueldo(getMonto()+ (getMonto()*ext)/100);
            this.encargado = false;
        }

        public static void setCanon(float can)
        {
            CProfesional.canon = can;
        }

        public static float getCanon() 
        {
            return CProfesional.canon; 
        }
        public void encargarObra()
        {
            this.encargado = true;
        }
        public bool esEncargado()
        {
            if (this.encargado) { return true; }
            return false;
        }

        public override string ToString()
        {
            string datos=base.ToString();
            datos += " Titulo: " + this.titulo + " Matricula: " + this.matricula + " Consejo: " + this.consejo;
            return datos;
        }


    }
}
