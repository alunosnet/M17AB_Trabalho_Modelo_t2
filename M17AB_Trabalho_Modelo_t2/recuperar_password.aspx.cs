using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class recuperar_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPassword_Click(object sender, EventArgs e)
        {
            try
            {
                //guid
                string guid = Server.UrlDecode(Request["id"].ToString());
                //nova password
                string novapassword = tbPassword.Text;
                if (novapassword == String.Empty)
                    throw new Exception("Password não pode ficar vazia");
                BaseDados.Instance.atualizarPassword(guid, novapassword);
                Response.Redirect("index.aspx");
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}