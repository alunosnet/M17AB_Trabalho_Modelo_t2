using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class detalhesLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] == null)
                Response.Redirect("index.aspx");
            try
            {
                int id = int.Parse(Request["id"].ToString());
                DataTable dados = BaseDados.Instance.devolveDadosLivro(id);
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbAno.Text = dados.Rows[0]["ano"].ToString();
                lbPreco.Text = String.Format("{0:C}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
                string ficheiro = @"~\Imagens\" + dados.Rows[0]["nlivro"].ToString() + ".jpg";
                imgCapa.ImageUrl = ficheiro;
                imgCapa.Width = 200;

                //criar um cookie com o id do livro
                HttpCookie cookie = new HttpCookie("ultimaEscolha", id.ToString());
                //definir prazo de 1 hora
                cookie.Expires = DateTime.Now.AddHours(1);
                //enviar cookie
                Response.Cookies.Add(cookie);
            }
            catch
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}