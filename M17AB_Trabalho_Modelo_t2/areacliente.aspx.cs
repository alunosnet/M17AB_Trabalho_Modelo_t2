using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class areacliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null)
                Response.Redirect("index.aspx");
            if (!IsPostBack)
            {
                divDevolver.Visible = false;
                divEmprestimo.Visible = false;
                divHistorico.Visible = false;
            }
            gvLivrosEmprestar.RowCommand += new GridViewCommandEventHandler(this.gvLivrosEmprestar_RowCommand);
            gvLivrosEmprestados.RowCommand += new GridViewCommandEventHandler(this.gvLivrosEmprestados_RowCommand);
        }
        //devolução
        private void gvLivrosEmprestados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            throw new NotImplementedException();
        }
        //empréstimo
        private void gvLivrosEmprestar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btEmprestimo_Click(object sender, EventArgs e)
        {
            divEmprestimo.Visible = true;
            divDevolver.Visible = false;
            divHistorico.Visible = false;
            btEmprestimo.CssClass = "btn btn-info active";
            btDevolve.CssClass = "btn btn-info";
            btHistorico.CssClass = "btn btn-info";
            atualizaGrelhaLivrosEmprestar();
        }

        private void atualizaGrelhaLivrosEmprestar()
        {
            throw new NotImplementedException();
        }

        protected void btDevolve_Click(object sender, EventArgs e)
        {

        }

        protected void btHistorico_Click(object sender, EventArgs e)
        {

        }
    }
}