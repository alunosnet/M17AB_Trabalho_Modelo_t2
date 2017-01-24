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
            int linha = int.Parse(e.CommandArgument as string);
            int nemprestimo = int.Parse(gvLivrosEmprestados.Rows[linha].Cells[1].Text);
            if (e.CommandName == "devolve")
            {
                BaseDados.Instance.concluirEmprestimo(nemprestimo);
                atualizaGrelhaLivrosEmprestados();
            }
        }
        //empréstimo
        private void gvLivrosEmprestar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument as string);
            int id = int.Parse(gvLivrosEmprestar.Rows[linha].Cells[1].Text);
            int idUtilizador = int.Parse(Session["id"].ToString());
            if(e.CommandName== "empréstimo")
            {
                DateTime dataDevolve = DateTime.Now.AddDays(7);
                BaseDados.Instance.adicionarEmprestimo(id, idUtilizador, dataDevolve);
                atualizaGrelhaLivrosEmprestar();
            }
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
            gvLivrosEmprestar.Columns.Clear();
            gvLivrosEmprestar.DataSource = null;
            gvLivrosEmprestar.DataBind();

            gvLivrosEmprestar.DataSource = BaseDados.Instance.listaLivrosDisponiveis();

            //botão emprestar
            ButtonField btEmprestar = new ButtonField();
            btEmprestar.HeaderText = "Fazer empréstimo";
            btEmprestar.Text = "Empréstimo";
            btEmprestar.ButtonType = ButtonType.Button;
            btEmprestar.CommandName = "empréstimo";
            gvLivrosEmprestar.Columns.Add(btEmprestar);

            gvLivrosEmprestar.DataBind();
        }

        protected void btDevolve_Click(object sender, EventArgs e)
        {
            divEmprestimo.Visible = false;
            divDevolver.Visible = true;
            divHistorico.Visible = false;
            btEmprestimo.CssClass = "btn btn-info";
            btDevolve.CssClass = "btn btn-info active";
            btHistorico.CssClass = "btn btn-info";
            atualizaGrelhaLivrosEmprestados();
        }

        private void atualizaGrelhaLivrosEmprestados()
        {
            gvLivrosEmprestados.Columns.Clear();
            int idUtilizador = int.Parse(Session["id"].ToString());
            gvLivrosEmprestados.DataSource = BaseDados.Instance.listaTodosEmprestimosPorConcluirComNomes(idUtilizador);

            //botão devolver
            ButtonField btDevolver = new ButtonField();
            btDevolver.HeaderText = "Devolver";
            btDevolver.Text = "Devolver";
            btDevolver.ButtonType = ButtonType.Button;
            btDevolver.CommandName = "devolve";
            gvLivrosEmprestados.Columns.Add(btDevolver);

            gvLivrosEmprestados.DataBind();
        }

        protected void btHistorico_Click(object sender, EventArgs e)
        {
            divEmprestimo.Visible = false;
            divDevolver.Visible = false;
            divHistorico.Visible = true;
            btEmprestimo.CssClass = "btn btn-info";
            btDevolve.CssClass = "btn btn-info";
            btHistorico.CssClass = "btn btn-info active";
            atualizaGrelhaHistorico();
        }

        private void atualizaGrelhaHistorico()
        {
            gvHistorico.Columns.Clear();

            int idutilizador = int.Parse(Session["id"].ToString());
            gvHistorico.DataSource = BaseDados.Instance.listaTodosEmprestimosComNomes(idutilizador);
            gvHistorico.DataBind();
        }
    }
}