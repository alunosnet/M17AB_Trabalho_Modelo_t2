using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class editarlivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    tbNomeLivro.Text = dados.Rows[0][1].ToString();
                    tbAno.Text = dados.Rows[0][2].ToString();
                    tbData.Text = DateTime.Parse(dados.Rows[0][3].ToString()).ToShortDateString();
                    tbPreco.Text = dados.Rows[0][4].ToString();
                    //capa
                    string ficheiro = @"~\Imagens\" + dados.Rows[0][0].ToString() + ".jpg";
                    imgCapa.ImageUrl = ficheiro;
                    imgCapa.Width = 100;
                }
                catch (Exception erro)
                {
                    Response.Redirect("areaadmin.aspx");
                }
            }
        }
        //editar
        protected void btEditarLivro_Click(object sender, EventArgs e)
        {
            //validar form
            try
            {
                string nome = tbNomeLivro.Text;
                if (nome.Length < 3) throw new Exception("O nome do livro é muito pequeno");
                int ano = int.Parse(tbAno.Text);
                if (ano < 0 || ano > DateTime.Now.Year)
                    throw new Exception("O ano não pode ser negativo nem superior ao ano atual");
                DateTime data = DateTime.Parse(tbData.Text);
                if(data.Date>DateTime.Now.Date)
                    throw new Exception("A data não pode ser superior à data atual");
                decimal preco = decimal.Parse(tbPreco.Text);
                if(preco<0)
                    throw new Exception("O preço não pode ser negativo");
                //editar
                int id = int.Parse(Request["id"].ToString());
                BaseDados.Instance.atualizaLivro(id, nome, ano, data, preco);
                //capa
                if (fuCapa.HasFile)
                {
                    if(fuCapa.PostedFile.ContentType=="image/jpeg"
                        && fuCapa.PostedFile.ContentLength > 0)
                    {
                        string ficheiro = Server.MapPath(@"~\Imagens\");
                        ficheiro += id.ToString() + ".jpg";
                        fuCapa.SaveAs(ficheiro);
                    }
                }
                Response.Redirect("areaadmin.aspx");
            }
            catch(Exception erro)
            {
                lbErroLivro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErroLivro.CssClass = "alert alert-danger";
                return;
            }
        }
        //cancelar
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("areaadmin.aspx");
        }
    }
}