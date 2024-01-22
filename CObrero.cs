using System;
using System.Collections;

namespace reparar
{
    public class CObrero : CEmpleado
    {
        private string oficio;
        private string categoria;

        public CObrero(string nom, string ape, uint leg, string ofi, string cat) : base(nom, ape, leg)
        {
            this.oficio = ofi;
            this.categoria = cat;
            if (this.categoria == "Aprendiz")
            {
                setSueldo(getMonto() * 0.25f);
            }
            else if (this.categoria == "Oficial")
            {
                setSueldo(getMonto());
            }
            else
            {
                setSueldo(getMonto() * 0.65f);
            }
        }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += " Oficio: " + this.oficio + " Categoria: " + this.categoria;
            return datos;
        }



    }

            
} 
