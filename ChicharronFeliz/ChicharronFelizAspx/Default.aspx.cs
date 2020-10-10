using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChicharronFeliz.Entidades;
using ChicharronFeliz.Negocios;

namespace ChicharronFelizAspx
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocios _bl = new Negocios();
            datagrid1.DataSource = _bl.ObtenerPedidosActivos();
            datagrid1.DataBind();
        }
    }
}