using System;
using System.Collections;


namespace reparar
{
    class CListas
    {
        public CListas()
        { }

        ArrayList lista_empleados = new ArrayList(0);
        ArrayList lista_obras = new ArrayList(0);

        //metodo para agregar obrero
        public bool agregarObrero(string nom, string ape, uint leg,string ofi,string cat)
        {
            CEmpleado aux = this.buscaEmpleado(leg);
            if (aux == null)
            {
                lista_empleados.Add(new CObrero(nom, ape, leg, ofi, cat));
                return true;
            }
            return false;
        }

        //metodo para agregar profesional
        public bool agregarProfesional(string nom, string ape, uint leg, string tit,ulong mat, string con, ushort ext)
        {
            CEmpleado aux = this.buscaEmpleado(leg);
            if (aux == null)
            {
                lista_empleados.Add(new CProfesional(nom, ape, leg, tit, mat, con, ext));
                return true;
            }
            return false;
        }

        //metodo para buscar empleado
        public CEmpleado buscaEmpleado(uint leg)
        {
            foreach (CEmpleado aux in this.lista_empleados)
            {
                if (aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        //metodo para mostrar empleado
        public string mostrarEmpleado()
        {
            lista_empleados.Sort();
            string datos = "";
            foreach (CEmpleado aux in this.lista_empleados)
            {
                datos += aux.ToString();
                datos += "\n\n";
            }
            return datos;
        }

        //metodo para buscar una obra
        public CObra buscarObra(string cod)
        {
            foreach (CObra aux in this.lista_obras)
            {
                if (aux.getCodigo() == cod)
                {
                    return aux;
                }
            }
            return null;
        }

        //metodo para agregar una obra
        public bool agregarObra(string cod, string dir, uint leg)
        {
            CObra aux = this.buscarObra(cod);
            CEmpleado pro = buscaEmpleado(leg);
            int indice = lista_empleados.IndexOf(pro);
            if (!((CProfesional)pro).esEncargado())
            {
                ((CProfesional)pro).setSueldo(pro.getSueldo() + CProfesional.getCanon());
                ((CProfesional)pro).encargarObra();
            }
            if (aux == null && pro !=null && pro is CProfesional)
            {
                lista_obras.Add(new CObra(cod, dir, (CProfesional)pro));
                lista_empleados[indice] = pro;
                return true;
            }
            return false;
        }

        //metodo para cambiar el encargado de una obra(y su sueldo de acuerdo al canon)
        public bool cambiarEncargado(uint leg,string numObra)
        {
            //busco encargado nuevo y le seteo el sueldo con canon
            CEmpleado encargado = buscaEmpleado(leg);
            int ind1 = lista_empleados.IndexOf(encargado);
            float sueldoNuevo = encargado.getSueldo();
            encargado.setSueldo(sueldoNuevo + CProfesional.getCanon());
            
            //busco la obra por codigo
            CObra obraAux = buscarObra(numObra);
            int indice = lista_obras.IndexOf(obraAux);
            
            //busco el encargado viejo y le resto el canon
            CProfesional encargadoViejo = ((CObra)lista_obras[indice]).getEncargado();
            int ind2 = lista_empleados.IndexOf(encargadoViejo);
            float sueldoViejo = encargadoViejo.getSueldo();
            encargadoViejo.setSueldo(sueldoViejo-CProfesional.getCanon());

            obraAux.setEncargado((CProfesional)encargado);


            if (encargado != null && encargadoViejo != null && encargado is CProfesional && indice!=null)
            {
                this.lista_obras[indice] = obraAux;
                this.lista_empleados[ind1] = encargado;
                this.lista_empleados[ind2] = encargadoViejo;
                return true;
            }
            return false;

        }

        //metodo para mostrar una obra
        public string mostrarObra(string num)
        {
            CObra aux = buscarObra(num);
            return aux.ToString();
        }

        //metodo para agregar obreros a la obra
        public bool agregarObreroAObra(string cod, uint leg)
        {
            CObra aux = this.buscarObra(cod);
            CEmpleado pro = this.buscaEmpleado(leg);
            int ind = lista_obras.IndexOf(aux);
            if (!aux.repetido(pro.getLegajo()))
            {
                ((CObra)lista_obras[ind]).agregarObrero((CObrero)pro);
                return true;
            }
            return false;
            
        }

        //metodo para borrar un profesional no asignado a una obra
        public bool borrarProfesional(uint leg)
        {
            CEmpleado auxEmp = buscaEmpleado(leg);
            bool encontrado = false;
            foreach(CObra aux in lista_obras)
            {
                if (aux.getEncargado() == auxEmp) 
                {
                    encontrado = true;
                }
            }
            if (!encontrado && auxEmp!=null && auxEmp is CProfesional) 
            { 
                lista_empleados.Remove(auxEmp);
                return true;
            }
            else
            {
                return false;
            }
            
            
        }



        

    }
}