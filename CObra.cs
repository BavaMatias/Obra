using System;
using System.Collections;

namespace reparar
{
    public class CObra
    {
        private string codigo;
        private string direccion;
        private CProfesional encargado;
        private ArrayList obreros = new ArrayList(0);


        public CObra(string cod, string dir, CProfesional enc)
        {
            this.codigo = cod;
            this.direccion = dir;
            this.encargado = enc;
            
        }

        public void setEncargado(CProfesional enc)
        {
            this.encargado = enc;
        }

        public CProfesional getEncargado()
        {
            return this.encargado;
        }

        public string getCodigo()
        {
            return this.codigo;
        }

        public void agregarObrero(CObrero obr) 
        {
            this.obreros.Add(obr);
        }

        public bool repetido(uint leg)
        {
            foreach(CObrero aux in this.obreros)
            {
                if (aux.getLegajo() == leg)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string datos = "";
            datos += " Obra: " + this.codigo + "\n";
            datos += "Encargado: " + this.encargado.ToString() + "\n";
            foreach (CObrero aux in obreros)
            {
                datos += aux.ToString();
                datos += "\n";
            }

            return datos;
        }
    }
}
