﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaBotones.Controles.Boton;
using LibreriaBotones.Controles.Exepciones;

namespace LibreriaBotones.Controles
{
    public class Controles
    {
        List<Botones> _Botones; //Me salta este error, como los soluciono?

        public Controles()
        {
           _Botones = new List<Botones>();
        }

        public void AgregarBotonEnLista()  //Agrego los botones por medio del menu
        {
            bool flag = false;
            int IngresoBoton = 0;
            string DescripcionBoton="";

            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton");
                    IngresoBoton = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ForEx)
                {
                    Console.WriteLine("Ingrese un Numero " + ForEx.Message);
                    flag = false;

                }
                catch (RepetidoExepcion Rex) 
                {
                    Console.WriteLine("Valor Repetido, Ingrese otro "+Rex.Message);
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag!=true);

            do //BUCLE PARA EL INGRESO DE LA DESCRIPCION
            {
                try
                {
                    Console.WriteLine("Ingrese la Descripcion del Boton");
                    DescripcionBoton = Console.ReadLine();
                    flag = true;
                }
                catch (ArgumentNullException ArEx)
                {
                    Console.WriteLine("No debe ser Nula la descripcion "+ArEx.Message);
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);

            AgregarBoton(IngresoBoton,DescripcionBoton);
            //ACA CARGO LOS DATOS LUEGO DE VALIDARLOS

        }

        private void AgregarBoton(int cod, string descripcion)  //Agrego el boton a la lista 
        {
            Botones AB = new Botones(cod, descripcion); //Utilizo el construtor con parametros

            _Botones.Add(AB);
        }

        public void MostrarBotonesControlador() //Bucle, cargo los datos en un string y lo muestro
        {
            string CartelMostrar = "";
            Botones MBC = new Botones();

            foreach (Botones i in _Botones )
            {
                CartelMostrar += MBC.MostrarCodigo(i.Codigo)+"\n";
            }

            if (CartelMostrar == "")
            {
                Console.WriteLine("\nNo hay botones Cargados\n");
            }
            else 
            {
                Console.WriteLine(CartelMostrar);
            }
        }

        public void BorrarBotonesControlador() 
        {
            int Ingreso = 0;
            bool flag = true;
            string CartelBorrar = "";
            int BorrarCodigo = -1;
            string BorrarDescrip ="" ;

            Botones BBC = new Botones();


            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton que desea BORRAR ");
                    Ingreso = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ForEx)
                {
                    Console.WriteLine("Ingrese un Numero " + ForEx.Message);
                    flag = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);




            foreach (Botones i in _Botones)
            {
                if (i.Codigo == Ingreso)
                {
                    CartelBorrar += BBC.MostrarBoton(i.Codigo, i.Descripcion);
                    BorrarCodigo = i.Codigo;
                    BorrarDescrip =i.Descripcion;
                }
            }

            if (CartelBorrar == "")
            {
                Console.WriteLine("\nCodigo De Boton Inexistete");
            }
            else 
            {
                Console.WriteLine("Usted Borro \n"+CartelBorrar);
                BorrarBoton(BorrarCodigo,BorrarDescrip);
            }

            
        }

        private void BorrarBoton(int cod, string descripcion)  //Elimino Boton de la lista 
        {
            Botones BB = new Botones();

            _Botones.Remove(BB);
        }

        //ERROR , CUANDO EJECUTO BORRAR BOTON, NO LO SACA DE LA LISTA, AL SACARLO, Y EJECUTO MOSTRAR LISTA, APARECE EL QUE DEBERIA
        //SER ELIMINADO

        public void MostrarDescripcionBotonesControlador()
        {
            int Ingreso = 0;
            bool flag = true;
            string CartelDesc = "";

            Botones MDBC = new Botones();


            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton que desea ver la Descripcion ");
                    Ingreso = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ForEx)
                {
                    Console.WriteLine("Ingrese un Numero " + ForEx.Message);
                    flag = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);




            foreach (Botones i in _Botones)
            {
                if (i.Codigo == Ingreso)
                {
                    CartelDesc = MDBC.MostrarBoton(i.Codigo, i.Descripcion);
                }
            }

            if (CartelDesc == "")
            {
                Console.WriteLine("\nCodigo De Boton Inexistete");
            }
            else
            {
                Console.WriteLine(CartelDesc);
            }


        }
    }
}
