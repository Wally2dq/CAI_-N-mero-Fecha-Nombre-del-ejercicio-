﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseEntidades;
using NUnit.Framework;

namespace CapaDatos
{
    public class ClienteMapper
    {
        public List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("cliente"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        private List<Cliente> MapList(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return lst;
        }

        public TransactionResult Insertar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);

            string json = WebHelper.Post("cliente", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", cliente.id.ToString());
            n.Add("nombre", cliente.Nombre);
            n.Add("apellido", cliente.Ape);
            n.Add("direccion", cliente.Direccion);
            n.Add("DNI", cliente.DNI);
            n.Add("fechaNacimiento", cliente.fechaNacimiento.ToString());//Ya viene con el formato de fecha del form
            n.Add("usuario", cliente.usuario);
            return n;
        }


    }
}
