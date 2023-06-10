using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaopesquisar;


        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaopesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);
            select.DeselectAll();

            Thread.Sleep(1000);

            categorias.ForEach(categ =>
            {
                select.MultipleSelectByText(categ);
            });
            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAndamento) driver.FindElement(byInputAndamento).Click();

            driver.FindElement(byBotaopesquisar).Click();
        }
    }
}
