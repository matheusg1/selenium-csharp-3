using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public IEnumerable<IWebElement> Options => opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);

            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public void OpenWrapper()
        {
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper.FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();

            opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });

            LoseFocus();
        }

        public void MultipleSelectByText(string option)
        {
            OpenWrapper();
            Thread.Sleep(1000);

            var listaFiltrada = opcoes.Where(o => o.Text.Contains(option)).ToList();           

            listaFiltrada
            .ForEach(o =>
                {
                    o.Click();
                }
            );
            LoseFocus();
        }
    }
}
