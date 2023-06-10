using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;

        public MenuLogadoPO MenuLogado { get; }
        public FiltroLeiloesPO Filtro { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Filtro = new FiltroLeiloesPO(driver);
            MenuLogado = new MenuLogadoPO(driver);
        }
    }
}