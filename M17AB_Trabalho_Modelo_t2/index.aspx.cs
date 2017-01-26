using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (Session["perfil"] != null)
                div_login.Visible = false;
            //listar livros disponíveis para emprestimo
            if (!IsPostBack)
            {
                DataTable dados = BaseDados.Instance.devolveConsulta("SELECT nlivro,nome,preco FROM Livros WHERE estado=1");
                atualizaDivLivros(dados);
            }
        }

        private void atualizaDivLivros(DataTable dados)
        {

            if (dados == null || dados.Rows.Count == 0)
            {
                div_livros.InnerHtml = "";
                return;
            }

            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";

            foreach(DataRow livro in dados.Rows)
            {
                grelha += "<div class='col-md-4 text-center'>";
                grelha += "<img src='/Imagens/" + livro[0].ToString() + ".jpg' class='img-responsive'/>";
                grelha += "<span class='stat-title'>" + livro[1].ToString() + "</span>";
                grelha += "<span class='stat-title'>" + String.Format(" | {0:C}",Decimal.Parse(livro[2].ToString())) + "</span>";
                grelha += "<br/><a href='detalhesLivro.aspx?id=" + livro[0].ToString() + "'>Detalhes</a>";
                grelha += "</div>";
            }

            grelha += "</div></div>";
            div_livros.InnerHtml = grelha;
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

        protected void btRecuperarPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEmail.Text == String.Empty)
                {
                    throw new Exception("Tem de indicar um email");
                }
                //verificar se o email existe
                string email = tbEmail.Text;
                DataTable dados = BaseDados.Instance.devolveDadosUtilizador(email);
                if(dados==null || dados.Rows.Count == 0)
                {
                    throw new Exception("O email indicado não existe");
                }
                //GUID
                Guid g = Guid.NewGuid();

                //guardar na bd
                BaseDados.Instance.recuperarPassword(email, g.ToString());
                //enviar email com link
                //dominio/recuperar_password.aspx?id=guid
                string assunto = "Clique no link para recuperar a sua password.\n";
                assunto += "<a href='http://" + Request.Url.Authority + "/recuperar_password.aspx?id=" + Server.UrlEncode(g.ToString())+"'>Clique aqui</a>";
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                Helper.enviarMail("alunosnet@gmail.com", senha, email,
                    "Recuperação de palavra passe", assunto);
                lbErro.Text = "Foi enviado um email de recuperação";
                lbErro.CssClass = "alert alert-sucess";
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }

        protected void btPesquisa_Click(object sender, EventArgs e)
        {
            string livro = tbPesquisa.Text;
            DataTable dados = BaseDados.Instance.pesquisaLivrosPeloNome(livro);
            atualizaDivLivros(dados);
        }
    }
}