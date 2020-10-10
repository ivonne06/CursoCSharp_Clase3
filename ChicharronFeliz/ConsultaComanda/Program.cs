/*
 * Created by SharpDevelop.
 * User: EPADILLA
 * Date: 3/10/2020
 * Time: 14:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using ChicharronFeliz.Entidades;
using ChicharronFeliz.Negocios;

namespace ConsultaComanda
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Aqui viene el detalle de pedidos pendientes");
			Negocios _bl = new Negocios();
			// TODO: Implement Functionality Here
			List<Pedidos> _lista = _bl.ObtenerPedidosActivos();
			foreach(Pedidos _p in _lista)
			{
				Console.WriteLine(String.Format("{0, -5}{1, -25}{2, 8}{3, 8}{4, 10}", _p.NumeroPedido, 
				                                _p.NombreProducto, _p.PrecioUnit,
				                                _p.PrecioTotal, _p.TiempoTranscurrido));
			}
			Console.Write("Presione Cualquier Tecla. . . ");
			Console.ReadKey(true);
		}
	}
}