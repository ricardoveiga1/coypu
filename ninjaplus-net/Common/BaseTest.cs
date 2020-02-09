using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using System;


namespace NinjaPlus.Common
{

    public class BaseTest
    {

//publico => public(pode ser acessada por qualquer código, até mesmo por outro projeto)
//privado => private(só pode ser acessado pela classe que está)
//publico => public(só pode ser acessado por ela ou classe herdada)
//Notação
//public String nome;
//private String _nome;
//protected String Nome;

        protected BrowserSession Browser;


        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",  // poderia "http://ninjaplus-web:5000"
                Port = 5000,
                SSL = false, //devido não usarmos https e sim http
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)
            };

            Browser = new BrowserSession(configs); // nova sessao com todas a configurações listadas acima
            Browser.MaximiseWindow();
        }

        [TearDown]
        public void Finish()
        {
            Browser.Dispose();
        }


    }

}