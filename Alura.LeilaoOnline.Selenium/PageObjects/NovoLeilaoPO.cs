using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;
        private By byInputCategoriaItemCollection;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button[type=submit]");
        }
        //Select
        /*
        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(By.byInputCategoria));
                elementoCategoria
                    .Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            }
        }*/

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valor, string imagem, DateTime inicio, DateTime termino)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            byInputCategoriaItemCollection = By.XPath("//*[contains(@class,'dropdown-content select-dropdown')]/li[2]/span");
            //driver.FindElement(byInputCategoria).GetAttribute($"option[value={categoria}]");            
            driver.FindElement(By.ClassName("select-wrapper")).Click();
            Thread.Sleep(1000);
            driver.FindElement(byInputCategoriaItemCollection).Click();
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("d"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("d"));
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
