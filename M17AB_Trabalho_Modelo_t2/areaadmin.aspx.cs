﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Trabalho_Modelo_t2
{
    public partial class areaadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null || Session["perfil"].Equals("1"))
                Response.Redirect("index.aspx");
            //esconder as divs
            if (!IsPostBack)
            {
                divLivros.Visible = false;
                divUtilizadores.Visible = false;
                divEmprestimos.Visible = false;
            }
            //grelha livros
            //paginação
            gvLivros.PageSize = 5;
            gvLivros.PageIndexChanging += new GridViewPageEventHandler(this.gvLivros_PageChanging);

            //gvutilizadores eventos
            gvUtilizadores.RowDeleting += new GridViewDeleteEventHandler(this.gvUtilizadores_RowDeleting);
            gvUtilizadores.RowEditing += new GridViewEditEventHandler(this.gvUtilizadores_RowEditing);
            gvUtilizadores.RowCancelingEdit += new GridViewCancelEditEventHandler(this.gvUtilizadores_RowCancelingEdit);
            gvUtilizadores.RowUpdating += new GridViewUpdateEventHandler(this.gvUtilizadores_RowUpdating);
            gvUtilizadores.RowCreated += new GridViewRowEventHandler(this.gvUtilizadores_RowCreated);

            //para manter formatação
            if (divLivros.Visible)
                atualizaGrelhaLivros();
        }

        private void gvUtilizadores_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //torna readonly a coluna do id
            foreach(TableCell coluna in e.Row.Cells)
            {
                if(coluna.Text!="" && coluna.Text!="&nbsp;" && coluna.Text!="Ativar/Desativar"
                    && coluna.Text != "Histórico")
                {
                    BoundField campo = (BoundField)((DataControlFieldCell)coluna).ContainingField;
                    if (campo.DataField == "id" || campo.DataField == "estado" || campo.DataField == "perfil")
                        campo.ReadOnly = true;
                }
            }
        }

        private void gvUtilizadores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int linha = e.RowIndex;
            int id = int.Parse(gvUtilizadores.Rows[linha].Cells[3].Text);
            string nome = ((TextBox)gvUtilizadores.Rows[linha].Cells[4].Controls[0]).Text;
            string email= ((TextBox)gvUtilizadores.Rows[linha].Cells[3].Controls[0]).Text;
            string morada= ((TextBox)gvUtilizadores.Rows[linha].Cells[5].Controls[0]).Text;
            string nif= ((TextBox)gvUtilizadores.Rows[linha].Cells[6].Controls[0]).Text;
            BaseDados.Instance.atualizarUtilizador(id, nome, email, morada, nif);
            gvUtilizadores.EditIndex = -1;
            atualizaGrelhaUtilizadores();
            
        }

        private void gvUtilizadores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUtilizadores.EditIndex = -1;
            atualizaGrelhaUtilizadores();
        }

        private void gvUtilizadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int linha = e.NewEditIndex;
            gvUtilizadores.EditIndex = linha;
            atualizaGrelhaUtilizadores();
        }

        private void gvUtilizadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int linha = e.RowIndex;
            string id = gvUtilizadores.Rows[linha].Cells[3].Text;
            BaseDados.Instance.removerUtilizador(int.Parse(id));
            //atualizar grelha
            atualizaGrelhaUtilizadores();
        }

        private void gvLivros_PageChanging(object sender, GridViewPageEventArgs e)
        {
            gvLivros.PageIndex = e.NewPageIndex;
            atualizaGrelhaLivros();
        }
        #region livros
        protected void btLivros_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divLivros.Visible = true;
            divUtilizadores.Visible = false;
            divEmprestimos.Visible = false;
            btLivros.CssClass = "btn btn-info active";
            btUtilizadores.CssClass = "btn btn-info";
            btEmprestimos.CssClass = "btn btn-info";
            atualizaGrelhaLivros();
        }

        private void atualizaGrelhaLivros()
        {
            //limpar grid
            gvLivros.Columns.Clear();

            //consulta a bd
            DataTable dados = BaseDados.Instance.listaLivros();
            if (dados == null || dados.Rows.Count == 0) return;

            //adicionar colunas remover/editar
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            //configurar os campos da grid
            gvLivros.DataSource = dados;
            gvLivros.AutoGenerateColumns = false;
            //coluna remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover";
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removerlivro.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] { "nlivro" };
            gvLivros.Columns.Add(lnkRemover);
            //coluna editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarlivro.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "nlivro" };
            gvLivros.Columns.Add(lnkEditar);
            //coluna nome
            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            gvLivros.Columns.Add(bfNome);
            //coluna ano
            BoundField bfAno = new BoundField();
            bfAno.DataField = "ano";
            bfAno.HeaderText = "Ano";
            gvLivros.Columns.Add(bfAno);
            //coluna data
            BoundField bfData = new BoundField();
            bfData.DataField = "data_aquisicao";
            bfData.HeaderText = "Data Aquisição";
            bfData.DataFormatString = "{0:dd/MM/yyyy}";
            gvLivros.Columns.Add(bfData);
            //coluna preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            bfPreco.DataFormatString = "{0:c}";
            gvLivros.Columns.Add(bfPreco);
            //coluna estado
            BoundField bfEstado = new BoundField();
            bfEstado.DataField = "estado";
            bfEstado.HeaderText = "Estado";
            gvLivros.Columns.Add(bfEstado);
            //capa
            ImageField ifCapa = new ImageField();
            ifCapa.HeaderText = "Capa";
            ifCapa.DataImageUrlFormatString = "~/Imagens/{0}.jpg";
            ifCapa.DataImageUrlField = "nlivro";
            ifCapa.ControlStyle.Width = 100;
            gvLivros.Columns.Add(ifCapa);
            //refresh
            gvLivros.DataBind();
        }
        protected void btAdicionarLivro_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNomeLivro.Text;
                if (nome.Length < 3) throw new Exception("Nome do livro é muito pequeno");
                int ano = int.Parse(tbAno.Text);
                if (ano < 0 || ano > DateTime.Now.Year) throw new Exception("O ano não é válido");
                DateTime data = DateTime.Parse(tbData.Text);
                if (data.Date > DateTime.Now.Date)
                    throw new Exception("Data de aquisição não pode ser superior à data atual");
                decimal preco = decimal.Parse(tbPreco.Text);
                if (preco < 0) throw new Exception("O preço não pode ser inferior a zero");
                //verificar se existe capa
                if (fuCapa.HasFile == false) throw new Exception("Tem de indicar uma capa para o livro");
                int id=BaseDados.Instance.adicionarLivro(nome, ano, data, preco);
                //guardar imagem
                if(fuCapa.PostedFile.ContentType=="image/jpeg" 
                    && fuCapa.PostedFile.ContentLength > 0)
                {
                    string ficheiro = Server.MapPath(@"~\Imagens\");
                    ficheiro += id + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
                tbNomeLivro.Text = "";
                tbAno.Text = "";
                tbPreco.Text = "0";
                lbErroLivro.Text = "Dados adicionados com sucesso";
                lbErroLivro.CssClass = "alert alert-success";

            }catch(Exception erro)
            {
                lbErroLivro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErroLivro.CssClass = "alert alert-danger";
            }
            finally
            {
                atualizaGrelhaLivros();
            }
        }
        #endregion
        #region utilizadores
        protected void btUtilizadores_Click(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            divLivros.Visible = false;
            divUtilizadores.Visible = true;
            divEmprestimos.Visible = false;
            btLivros.CssClass = "btn btn-info";
            btUtilizadores.CssClass = "btn btn-info active";
            btEmprestimos.CssClass = "btn btn-info";
            atualizaGrelhaUtilizadores();
        }

        private void atualizaGrelhaUtilizadores()
        {
            gvUtilizadores.Columns.Clear();
            gvUtilizadores.DataSource = null;
            gvUtilizadores.DataBind();

            DataTable dados = BaseDados.Instance.listaUtilizadoresDisponiveis();
            if (dados == null || dados.Rows.Count == 0) return;

            gvUtilizadores.DataSource = dados;
            gvUtilizadores.AutoGenerateColumns = true;
            gvUtilizadores.AutoGenerateEditButton = true;
            gvUtilizadores.AutoGenerateDeleteButton = true;

            //adicionar coluna para ativar/desativar
            ButtonField btEstado = new ButtonField();
            btEstado.HeaderText = "Ativar/Desativar";
            btEstado.Text = "Ativar/Desativar";
            btEstado.ButtonType = ButtonType.Button;
            btEstado.CommandName = "ativarDesativar";
            gvUtilizadores.Columns.Add(btEstado);
            //adicionar coluna para ver o histórico
            ButtonField btHistorico = new ButtonField();
            btHistorico.HeaderText = "Histórico";
            btHistorico.Text = "Histórico";
            btHistorico.ButtonType = ButtonType.Button;
            btHistorico.CommandName = "histórico";
            gvUtilizadores.Columns.Add(btHistorico);

            gvUtilizadores.DataBind();
        }
        protected void btAdicionarUtilizador_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNomeUtilizador.Text;
                if (nome.Length < 3) throw new Exception("O nome é muito pequeno");
                string morada = tbMorada.Text;
                string nif = tbNIF.Text;
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                int perfil = int.Parse(ddPerfil.SelectedValue);
                int estado = cbEstado.Checked == true ? 1 : 0;
                //guardar na bd
                BaseDados.Instance.registarUtilizador(email, nome, morada, nif, password, estado, perfil);
                atualizaGrelhaUtilizadores();
                //limpar tb
                tbEmail.Text = "";
            }
            catch (Exception erro)
            {
                lbErroUtilizador.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErroUtilizador.CssClass = "alert alert-danger";
            }
        }

        #endregion
        #region Empréstimos
        protected void btEmprestimos_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}