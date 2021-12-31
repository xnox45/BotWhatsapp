using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BotWhatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aplique seu nome aqui
            string meuNome = "Fred";
            string MSG = $"Testando robô do {meuNome}, não se assuste por favor";
            string url = "https://web.whatsapp.com/";

            //Aplique o nome De seus Contato a cada item nessa Lista
            List<string> contatos = new List<string>
            {
                "Amorzinho",
                "Luan",
                "Wemerson",
                "Joao Victor",
                "Caio"
            };

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            Thread.Sleep(5000);

            foreach (var contato in contatos)
            {
                //Essa classe(_13NKt) corresponde ao meu input da minha aba WebWhatsapp, na sua maquina será outra classe que terá que ser aplicada
                var pesquisaEl = driver.FindElement(By.ClassName("_13NKt"));
                pesquisaEl.SendKeys(contato);

                Thread.Sleep(3000);

                var contatoEl = driver.FindElement(By.XPath($"//span[@title = '{contato}']"));
                contatoEl.Click();

                var input = driver.FindElement(By.XPath("//div[@title = 'Digite uma mensagem']"));
                input.SendKeys(MSG);

                Thread.Sleep(2000);

                input.SendKeys(Keys.Enter);
            };
        }
    }
}
