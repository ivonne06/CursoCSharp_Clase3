/*
 * Created by SharpDevelop.
 * User: EPADILLA
 * Date: 3/10/2020
 * Time: 14:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using ChicharronFeliz.Entidades;

namespace ChicharronFeliz.Datos
{
	/// <summary>
	/// Description of AccesoaDatos.
	/// </summary>
	public class AccesoaDatos
	{
		String TipoDb;
		String RutaConexion;
		public AccesoaDatos()
		{
			if (File.Exists("configuracion.inf") == false)
			{
				// Este servira para crear el archivo
				using (StreamWriter _rw = File.CreateText(@"C:\cursocharp\sabados\configuracion.inf"))
				{
					_rw.WriteLine("Db=Texto");
					_rw.WriteLine(@"C:\cursocharp\sabados\ChicharronFeliz\Datos\");
				}
				// Este servira para leerlo
				
			}
			using (StreamReader _reader = File.OpenText(@"C:\cursocharp\sabados\configuracion.inf"))
				{	
					TipoDb = _reader.ReadLine().Split('=')[1];
					RutaConexion= _reader.ReadLine();
						
				}
			
		}
		
		public List<Productos> ObtenerProductos()
		{
			List<Productos> _lista = new List<Productos>();
			if (TipoDb == "Texto")
			{
				using (StreamReader _reader = File.OpenText(RutaConexion + @"Productos.txt"))
				{
					while (_reader.EndOfStream == false)
					{
						Productos _producto = new Productos();
						//1;Revuelta;0.50;
						
						String[] _linea = _reader.ReadLine().Split(';');
						if (_linea.Length >1)
						{
						_producto.Codigo = _linea[0];
						_producto.Descripcion = _linea[1];
						_producto.Precio = Convert.ToDecimal(_linea[2]);
						_lista.Add(_producto);
						}
					}
				}
			}
			return _lista;
		}
		public List<Pedidos> ObtenerPedidos()
		{
			List<Pedidos> _lista = new List<Pedidos>();
			if (TipoDb == "Texto")
			{
				using (StreamReader _reader = File.OpenText(RutaConexion + @"Pedidos.txt"))
				{
					//		1;			2;		3;		0.50;		1.50;	  2020; 10;     3;  14;  05;     20;     0;
					// numero de pedido  codigo  cant	precio unit. precio total  año  mes   dia hora minuto  segundo  activo
					
					
					while (_reader.EndOfStream == false)
					{
						String[] _linea = _reader.ReadLine().Split(';');
						Pedidos _pedido = new Pedidos();
						_pedido.NumeroPedido = Convert.ToInt32(_linea[0]);
						_pedido.CodigoInventario = _linea[1];
						_pedido.Cantidad = Convert.ToInt32(_linea[2]);
						_pedido.PrecioUnit = Convert.ToDecimal(_linea[3]);
						_pedido.PrecioTotal = Convert.ToDecimal(_linea[4]);
						_pedido.Año = Convert.ToInt32(_linea[5]);
						_pedido.Mes = Convert.ToInt32(_linea[6]);
						_pedido.Dia= Convert.ToInt32(_linea[7]);
						_pedido.Hora = Convert.ToInt32(_linea[8]);
						_pedido.Minuto = Convert.ToInt32(_linea[9]);
						_pedido.Segundo = Convert.ToInt32(_linea[10]);
						_pedido.Activo = Convert.ToInt32(_linea[11]);
						
						_lista.Add(_pedido);
					}
				}
			    	
			}
			return _lista;
		}
		
		public String ConcatenerDatos(string[] args)
		{
			String _dato = "";
			// Ponemos concatenado los argumentos y si no son texto, los convierte a texto
			
			foreach(string _argumento in args)
				_dato += _argumento.ToString() + ";";
			
			return _dato;
		}
		public void GuardarPedido(List<Pedidos> pPedido)
		{
			if (TipoDb == "Texto")
			{
				if (File.Exists(RutaConexion + @"Pedidos.txt"))
					File.Delete(RutaConexion + @"Pedidos.txt");
				using (StreamWriter _lapiz = File.CreateText(RutaConexion + @"Pedidos.txt"))
				{
					//		1;			2;		3;		0.50;		1.50;	  2020; 10;     3;  14;  05;     20;     0;
					// numero de pedido  codigo  cant	precio unit. precio total  año  mes   dia hora minuto  segundo  activo
					foreach(Pedidos _pedido in pPedido)
					{
						string _pedidodetalle =  _pedido.NumeroPedido.ToString() +";"+
							                	_pedido.CodigoInventario.ToString()+";";
						_pedidodetalle += _pedido.Cantidad.ToString()+";"+ 
											_pedido.PrecioUnit.ToString()+";"+
											_pedido.PrecioTotal.ToString()+";"+
											_pedido.Año.ToString()+";"+ 
											_pedido.Mes.ToString()+";"+ 
											_pedido.Dia.ToString()+";"+
											_pedido.Hora.ToString()+";"+
											_pedido.Minuto.ToString()+";"+
											_pedido.Segundo.ToString()+";"+
											_pedido.Activo.ToString();
							
						_lapiz.WriteLine(_pedidodetalle);
					}
					
					
					
				}
			    	
			}
		}
		
		
		
	}
}
