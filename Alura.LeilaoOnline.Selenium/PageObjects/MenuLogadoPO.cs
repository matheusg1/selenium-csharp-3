using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
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
