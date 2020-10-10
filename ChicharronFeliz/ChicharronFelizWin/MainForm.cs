/*
 * Created by SharpDevelop.
 * User: EPADILLA
 * Date: 3/10/2020
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChicharronFeliz.Entidades;
using ChicharronFeliz.Negocios;

using System.Linq;

namespace ChicharronFelizWin
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        Negocios _bl = new Negocios();
        List<Pedidos> _pedidos = new List<Pedidos>();
        List<Productos> _productos = new List<Productos>();
        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
            _productos = _bl.ObtenerProductos();
            ActualizarGrid();
            cmbProducto.DisplayMember = "Descripcion";
            cmbProducto.ValueMember = "Codigo";
            cmbProducto.DataSource = _productos;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        private void ActualizarGrid()
        {
            _pedidos = _bl.ObtenerPedidosActivos();
            dataGrid1.DataSource = _pedidos;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedidos _pedido = new Pedidos();
            _pedido.NumeroPedido = Convert.ToInt32(txtPedido.Text);
            _pedido.CodigoInventario = cmbProducto.SelectedValue.ToString();
            _pedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
            _pedido.PrecioUnit = Convert.ToDecimal(txtPrecioUnitario.Text);
            _pedido.PrecioTotal = Convert.ToDecimal(_pedido.PrecioUnit * _pedido.Cantidad);
            DateTime _f = DateTime.Now;
            _pedido.Año = _f.Year;
            _pedido.Mes = _f.Month;
            _pedido.Dia = _f.Day;
            _pedido.Hora = _f.Hour;
            _pedido.Minuto = _f.Minute;
            _pedido.Segundo = _f.Second;
            _pedido.Activo = 1;
            _pedidos.Add(_pedido);
            
            _bl.GuardarPedidos(_pedidos);
            ActualizarGrid();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioUnitario.Text =
                _productos.Where(p => p.Codigo == cmbProducto.SelectedValue.ToString()).First().Precio.ToString();

            txtCantidad.Text = "1";
        }

        private void txtCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPrecioTotal.Text =
                (Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text)).ToString();
        }
    }
}
