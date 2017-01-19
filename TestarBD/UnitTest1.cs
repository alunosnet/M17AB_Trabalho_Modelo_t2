using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M17AB_Trabalho_Modelo_t2;

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
    }
}
