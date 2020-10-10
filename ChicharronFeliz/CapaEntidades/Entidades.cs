/*
 * Created by SharpDevelop.
 * User: EPADILLA
 * Date: 3/10/2020
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChicharronFeliz.Entidades
{
	/// <summary>
	/// Description of Entidades.
	/// Productos: Guardara detalle de productos en linea
	///      1;       Revuelta;       0.50;
	///  codigo   descripcion     precio unitario
	/// Pedidos Guardara Detalle de Pedidos
	/// 		1;			2;		3;		0.50;		1.50;	  2020; 10;     3;  14;  05;     20;     0;
	/// numero de pedido  codigo  cant	precio unit. precio total  año  mes   dia hora minuto  segundo  activo
	/// 
	/// </summary>
	public class Productos
	{
		
		public String Codigo { get; set; }
		public String Descripcion { get; set; }
		public Decimal Precio { get; set; }
		
		
		public Productos()
		{
		}
	}
	public class Pedidos
	{
		public Int32 NumeroPedido { get; set; }
		public String CodigoInventario { get; set; }
		public String NombreProducto { get; set; }
		public Int32 Cantidad { get; set; }
		public Decimal PrecioUnit { get; set; }
		public Decimal PrecioTotal { get; set; }
		public Int32 Año { get; set; }
		public Int32 Mes { get; set; }
		public Int32 Dia { get; set; }
		public Int32 Hora { get; set; }
		public Int32 Minuto { get; set; }
		public Int32 Segundo { get; set; }
		public Int32 Activo { get; set; }
		private DateTime _HoraPedido ;
		public DateTime HoraPedido
		{
			set  {
				_HoraPedido = value;
			}
			get {
				_HoraPedido = new DateTime(Año, Mes, Dia, Hora, Minuto, Segundo);
				
				return  _HoraPedido ;
			}
				
		}
		private Double _tn;
		public Double TiempoTranscurrido
		{
			set  {
				_tn = value;
			}
			
			get {
				_HoraPedido = new DateTime(Año, Mes, Dia, Hora, Minuto, Segundo);
				TimeSpan _tiempo =(DateTime.Now  - _HoraPedido );
				return  _tiempo.Minutes;
			}
			
		}
		
		
		public Pedidos(){}
	}
	
	
}
