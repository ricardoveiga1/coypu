
using Coypu;


namespace NinjaPlus.Pages
{

    public class LoginPage
    {

        private readonly BrowserSession _browser; //por convensão do c# em método privado, devemos usar _browser

        public LoginPage(BrowserSession browser) //construtor na mesmo nome da classe
        {
            _browser = browser;
        }

        public void Acessa()
        {
            _browser.Visit("/login");
        }

        public void With(string email, string pass)
        {
            this.Acessa();
            _browser.FillIn("email").With(email);
            _browser.FindCss("input[placeholder=senha]").SendKeys(pass);
            _browser.ClickButton("Entrar");

        }

        public string AlertMessage()//metodo criado para pegar o alert quando da erro ao logar, é um alert
        {
            return _browser.FindCss(".alert").Text;
        }


    }
}