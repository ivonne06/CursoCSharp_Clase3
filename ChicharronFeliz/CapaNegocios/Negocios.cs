/*
 * Created by SharpDevelop.
 * User: EPADILLA
 * Date: 3/10/2020
 * Time: 15:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ChicharronFeliz.Datos;
using ChicharronFeliz.Entidades;
using System.Linq;

namespace ChicharronFeliz.Negocios
{
	/// <summary>
	/// Description of Negocios.
	/// </summary>
	public class Negocios
	{
		AccesoaDatos _misdatos = new AccesoaDatos();
		public List<Pedidos> ObtenerPedidos()
		{
			return _misdatos.ObtenerPedidos();
		}
		public List<Productos> ObtenerProductos()
        {
            return _misdatos.ObtenerProductos();
        }
		public List<Pedidos> ObtenerPedidosActivos()
		{
			
			List<Productos> _prods = _misdatos.ObtenerProductos();
			List<Pedidos> _lista = _misdatos.ObtenerPedidos().Where(p=> p.Activo == 1).ToList();
			List<Pedidos> _ln = new List<Pedidos>();
			foreach(Pedidos _p in _lista)
			{
				try
				{
					_p.NombreProducto = _prods.Where(p=> p.Codigo == _p.CodigoInventario).First().Descripcion;
				}catch
				{
					_p.NombreProducto = "Sin Descripcion";
				}
				_ln.Add(_p);
			}
			
			return _ln;
			
			
			
		}
		
		
		
		
		
		public void GuardarPedidos(List<Pedidos> pPedidos)
		{
			_misdatos.GuardarPedido(pPedidos);
		}
		
	}
}
