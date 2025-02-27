﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaFacultad
{
    public class Alumno : Persona
    {
        private int _codigo;

        public int Codigo { get => this._codigo; set => this._codigo = value; }

        public Alumno(int CodigoIngreso,string NombreIngreso,string ApellidoIngreso) 
        {
            this.Codigo = CodigoIngreso;
            this.Nombre = NombreIngreso;
            this.Apellido = ApellidoIngreso;
        }
        public override string GetCredencial()
        {
            return $"Código {Codigo}) {Apellido}, {Nombre}";
        }

        public override string ToString() 
        {
            return GetCredencial();
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;

            if (!(obj is Alumno)) //El objeto No es un Empleado
                return false;

            Alumno alumno = (Alumno)obj;

            if (alumno.Codigo != this.Codigo) //Si es dintinto a un codigo ya registrado = falso, no son equal o iguales
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
