using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se tem login vai para index
            if (Session["perfil"] != null) Response.Redirect("index.aspx");
        }

        protected void btRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string nome = tbNome.Text;
                string morada = tbMorada.Text;
                string nif = tbNIF.Text;
                string password = tbPassword.Text;
                //validar o recaptcha
                var encodedResponse = Request.Form["g-Recaptcha-Response"];
                var isCaptchaValid = ReCaptcha.Validate(encodedResponse);

                if (!isCaptchaValid)
                {
                    throw new Exception("Tem de provar que não é um robot....");
                }
                //registar
                BaseDados.Instance.registarUtilizador(email, nome, morada, nif, password);
                Response.Redirect("index.aspx");

            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}