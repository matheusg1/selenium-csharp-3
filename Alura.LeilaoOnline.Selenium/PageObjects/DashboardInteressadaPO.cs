using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaopesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");

        }

        public void PesquisarLeiloes(List<string> categorias)
        {
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();

            Thread.Sleep(5000);
            opcoes.ForEach(o =>
            {
                o.Click();
            });
            Thread.Sleep(5000);

            categorias.ForEach(categ =>
            {
                opcoes.Where(o => o.Text.Contains(categ))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });
            });
            Thread.Sleep(5000);

            selectWrapper.FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        internal void EfetuarLogout()
        {
            var linkLogout = driver.FindElement(byLogoutLink);
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);

            IAction acaoLogout = new Actions(driver)
                .MoveToElement(linkMeuPerfil)
                .MoveToElement(linkLogout)
                .Click()
                .Build();

            acaoLogout.Perform();            
        }
    }
}