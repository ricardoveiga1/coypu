using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using System;
using NinjaPlus.Pages;
using NinjaPlus.Common;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {

        //public BrowserSession browser;

        private LoginPage _login;
        private Sidebar _side;

     [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser); //instanciando login page no setup, para nãoter que fazer isso dentro de cada teste
            _side = new Sidebar(Browser);
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser() //padrão escrita BDD, deve ver usuário logado
        {
            //var loginPage = new LoginPage(browser);
            //var sidebar = new Sidebar(browser);
            
            //browser.Visit("/login");
            //loginPage.Acessa();

            //método FillIn procura na ordem de elementos id>name>label, tanto faz qual indicar no método
            //browser.FillIn("email").With("ricardoveiga.ti@gmail.com");
            //browser.FindCss("input[placeholder=senha]").SendKeys("123");
            //browser.ClickButton("Entrar");
            //loginPage.PreencheEmail("ricardoveiga.ti@gmail.com");
            //loginPage.PreencheSenha("123");
            //loginPage.BotaoEntrar();

            _login.With("ricardoveiga.ti@gmail.com", "123");
            

            //var loggedUser = browser.FindCss(".user .info span");
            //Assert.AreEqual("Ricardo", loggedUser.Text);    //desfecho do teste, usuário logado

            Assert.AreEqual("Ricardo", _side.LoggedUser()); 

            //Thread.Sleep(15000);
        }
//DDT - orientado a dados
        [TestCase("ricardoveiga.ti@gmail.com", "123344", "Usuário e/ou senha inválidos")]
        [TestCase("ricardoveiga.ti@gmail.com", "123344", "Usuário e/ou senha inválidos")]
        [TestCase("", "123344", "Opps. Cadê o email?")]
        [TestCase("ricardoveiga.ti@gmail.com", "", "Opps. Cadê a senha?")]

        public void ShouldSeeAlertMessage(String email, String senha, String expecMessage)
        {
             _login.With(email, senha);
            Assert.AreEqual(expecMessage, _login.AlertMessage());

        }
//         [Test]
//         [Category("Negativo")]
//         public void ShouldSeeIncorrectPass()
//         {
//             //var loginPage = new LoginPage(browser);

//             _login.With("ricardoveiga.ti@gmail.com", "123344");
            
//             //var alertMessage = browser.FindCss(".alert");
//             Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());
//         }
//         [Test]
//         [Category("Negativo")]
//         public void ShouldSeeIncorrectPass2()
//         {            
//             _login.With("ricardoveiga.ti@gmail.com", "123344");
//             Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());
//         }

//         [Test]
//         [Category("Negativo")]
//         public void ShouldSeeRequireEmail()
//         {
//             _login.With("", "123344");
//             Assert.AreEqual("Opps. Cadê o email?", _login.AlertMessage());
//         }

//         [Test]
//         [Category("Negativo")]
//         public void ShouldSeeRequirePass()
//         {     
//             _login.With("ricardoveiga.ti@gmail.com", "");
//             Assert.AreEqual("Opps. Cadê a senha?", _login.AlertMessage());
//         }

     }

 }