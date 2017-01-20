using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M17AB_Trabalho_Modelo_t2;
using System.Data;

namespace TestarBD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarAdicionarLivros()
        {
            BaseDados.Instance.adicionarLivro("nome", 10, DateTime.Now.Date, -10);
        }
        [TestMethod]
        public void TestarLogin()
        {
            string nome = "admin@gmail.com";
            string password = "123456";
            DataTable dados = BaseDados.Instance.verificarLogin(nome, password);
            Assert.IsTrue(dados.Rows.Count==1);
        }
    }
}
