using System;
using System.Collections;

namespace reparar
{
    public class CControladora
    {
        public static void Main()
        {

            CListas Lista = new CListas();
            char opcion;
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                switch (opcion)
                {
                    case 'A':
                        try 
                        {
                            float monRef = float.Parse(CInterfaz.PedirDato("Monto de Referencia"));
                            CEmpleado.setMonto(monRef);
                            float canon = float.Parse(CInterfaz.PedirDato("Canon"));
                            CProfesional.setCanon(canon);
                            string datos = "Haber mensual: $" + CEmpleado.getMonto().ToString() + " Canon : $" + CProfesional.getCanon().ToString(); 
                            CInterfaz.MostrarInfo(datos);
                            CInterfaz.MostrarInfo("Sueldos establecidos exitosamente");
                        }
                        catch 
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        

                        break;

                    case 'B':
                        string tipo = CInterfaz.PedirDato(" Presione [A] para añadir un obrero o [B] para añadir un profesional.");
                        try
                        {
                            if (tipo.ToUpper() == "A")
                            {
                                string nom = CInterfaz.PedirDato("Nombre del obrero");
                                string ape = CInterfaz.PedirDato("Apellido del obrero");
                                uint leg = uint.Parse(CInterfaz.PedirDato("Legajo del obrero"));
                                string ofi = CInterfaz.PedirDato("Oficio del obrero");
                                string cat = CInterfaz.PedirDato("Presione [A] para Oficial, [B] Medio-Oficial o [C] para Aprendiz.");
                                if (cat.ToUpper() == "A")
                                {
                                    cat = "Oficial";
                                }
                                else if (cat.ToUpper() == "B")
                                {
                                    cat = "Medio-Oficial";
                                }
                                else if (cat.ToUpper() == "C")
                                {
                                    cat = "Aprendiz";
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo("Opcion Invalida");
                                    break;
                                }
                                if(Lista.agregarObrero(nom, ape, leg, ofi, cat))
                                {
                                    CInterfaz.MostrarInfo("Agregado exitosamente");
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo("El legajo ingresado ya existe");
                                }

                            }
                            else if (tipo.ToUpper() == "B")
                            {
                                string nom = CInterfaz.PedirDato("Nombre del profesional");
                                string ape = CInterfaz.PedirDato("Apellido del profesional");
                                uint leg = uint.Parse(CInterfaz.PedirDato("Legajo del profesional"));
                                string tit = CInterfaz.PedirDato("Titulo del profesional");
                                ulong mat = ulong.Parse(CInterfaz.PedirDato("Matricula del profesional"));
                                string con = CInterfaz.PedirDato("Consejo del profesional");
                                ushort ext = ushort.Parse(CInterfaz.PedirDato("Extra del profesional [%]"));
                                if(Lista.agregarProfesional(nom, ape, leg, tit, mat, con,ext))
                                {
                                    CInterfaz.MostrarInfo("Agregado exitosamente");
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo("El legajo ingresado ya existe");
                                }
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("Opcion invalida");
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incaorrectamente");
                        }
                        
                        break;

                    case 'C':
                        if (Lista.mostrarEmpleado() == "")
                        {
                            CInterfaz.MostrarInfo("No hay ningun empleado registrado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo(Lista.mostrarEmpleado());
                        }
                        break;

                    case 'D':
                        try
                        {
                            string cod = CInterfaz.PedirDato("Codigo de Obra");
                            string dir = CInterfaz.PedirDato("Direccion de la obra");
                            uint lega = uint.Parse(CInterfaz.PedirDato(" Legajo del Encargado de la obra"));
                            if (Lista.agregarObra(cod, dir, lega))
                            {
                                CInterfaz.MostrarInfo("Agregado exitosamente");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("El codigo ingresado ya existe");
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        break;

                    case 'E':
                        try
                        {
                            uint leg2 = uint.Parse(CInterfaz.PedirDato("Legajo del nuevo encargado"));
                            string obr = CInterfaz.PedirDato("Codigo de la Obra");
                            if(Lista.cambiarEncargado(leg2, obr))
                            {
                                CInterfaz.MostrarInfo("Encargado cambiado exitosamente");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("Intente nuevamente");
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        
                        break;

                    case 'F':
                        try
                        {
                            string num = CInterfaz.PedirDato("Codigo de obra"); 
                            if (Lista.buscarObra(num)==null)
                            {
                                CInterfaz.MostrarInfo("No existe ninguna obra con el codigo ingresado");
                                
                            }
                            else
                            {
                                CInterfaz.MostrarInfo(Lista.mostrarObra(num));
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        break;

                    case 'G':
                        try
                        {
                            string numero = CInterfaz.PedirDato("Codigo de Obra");
                            uint legajo = uint.Parse(CInterfaz.PedirDato("Legajo del Obrero"));
                            if (Lista.agregarObreroAObra(numero, legajo))
                            {
                                CInterfaz.MostrarInfo("Obrero agregado exitosamente");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("El obrero ya se encuentra trabajando en esta obra");
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        break;

                    case 'H':
                        try
                        {
                            uint legaj = uint.Parse(CInterfaz.PedirDato("Legajo del Profesional"));
                            if (Lista.borrarProfesional(legaj))
                            {
                                CInterfaz.MostrarInfo("Profesional eliminado exitosamente");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("Profesional no encontrado o es ecargado de obra");
                            }
                        }
                        catch
                        {
                            CInterfaz.MostrarInfo("Datos ingresados incorrectamente");
                        }
                        
                        break;

                    case 'S':
                        break;
                }
            } while (opcion != 'S');
        }
    }

}



