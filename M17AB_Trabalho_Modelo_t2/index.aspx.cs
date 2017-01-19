using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //esconder div login
            //listar livros disponíveis para emprestimo
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            DataTable utilizador = BaseDados.Instance.verificarLogin(email, password);
            if (utilizador == null)
            {
                lbErro.Text = "Login falhou.";
                lbErro.CssClass = "alert alert-danger";
                return;
            }
            Session["nome"] = utilizador.Rows[0]["nome"].ToString();
            Session["perfil"] = utilizador.Rows[0]["perfil"].ToString();
            Session["id"] = utilizador.Rows[0]["id"].ToString();
            div_login.Visible = false;
            if (Session["perfil"].Equals("0"))
                Response.Redirect("areaadmin.aspx");
            else
                Response.Redirect("areacliente.aspx");
        }
    }
}