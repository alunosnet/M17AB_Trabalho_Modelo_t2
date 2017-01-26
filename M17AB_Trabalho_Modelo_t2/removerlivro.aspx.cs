using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class removerlivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null || Session["perfil"].Equals("1"))
                Response.Redirect("index.aspx");
            //mostrar informações do livro
            if (!IsPostBack)
            {
                try
                {
                    int id = int.Parse(Request["id"].ToString());
                    DataTable dados = BaseDados.Instance.devolveDadosLivro(id);
                    if (dados == null || dados.Rows.Count == 0)
                        throw new Exception("Não existe nenhum livro com o id indicado");
                    //mostrar dados
                    lbNome.Text = dados.Rows[0][1].ToString();
                    lbAno.Text = dados.Rows[0][2].ToString();
                    lbData.Text =DateTime.Parse( dados.Rows[0][3].ToString()).ToShortDateString();
                    lbPreco.Text = dados.Rows[0][4].ToString();
                    lbEstado.Text = dados.Rows[0][5].ToString();
                    //capa
                    string ficheiro = @"~\Imagens\" + dados.Rows[0][0].ToString() + ".jpg";
                    imgCapa.ImageUrl = ficheiro;
                    imgCapa.Width = 100;
                }catch(Exception erro)
                {
                    Response.Redirect("areaadmin.aspx?divVisivel=1");
                }
            }
        }
        //remover
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                BaseDados.Instance.removerLivro(id);
                //apagar capa
                string ficheiro = Server.MapPath(@"~\Imagens\" + id + ".jpg");
                if (File.Exists(ficheiro))
                    File.Delete(ficheiro);
            }
            catch(Exception erro)
            {

            }
            Response.Redirect("areaadmin.aspx?divVisivel=1");
        }
        //cancelar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("areaadmin.aspx?divVisivel=1");
        }
    }
}