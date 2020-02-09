using Coypu;

namespace NinjaPlus.Pages
{

    public class Sidebar
    {

        private readonly BrowserSession _browser; //por convensão do c# em método privado, devemos usar _browser

        public Sidebar(BrowserSession browser) //construtor na mesmo nome da classe
        {
            _browser = browser;
        }

        public string LoggedUser() //método que retorna usuário logado // Encapsulamento da barra de nagevação
        {
            return _browser.FindCss(".user .info span").Text;

        }
    }
}