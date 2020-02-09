using NUnit.Framework;
using Coypu;
using NinjaPlus.Common;
using NinjaPlus.Pages;
using NinjaPlus.Models;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic; //para usar o List

namespace NinjaPlus.Pages
{
    public class MoviePage : BaseTest
    {

        private readonly BrowserSession _browser;

        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }
        public void Add()
        {
            _browser.FindCss(".movie-add").Click();

        }


        public void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();

        }

         private void InputCast(List<string> cast)
        {
            var castInput = _browser.FindCss("input[placeholder$=ator]");
            //vamos percorrer nossa lista de atores
            foreach(var actor in cast)
            {
                castInput.SendKeys(actor);
                castInput.SendKeys(Keys.Tab);//simulando tecla tab com recuso do selenium
                Thread.Sleep(500);//thinking time, caso aplicação não esteja preparada para ser tão rápido
            }

        }


        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name=title]").SendKeys(movie.Title);
            SelectStatus(movie.Status);
            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());
            _browser.FindCss("input[name=release_date]").SendKeys(movie.DataEstreia);     
            InputCast(movie.Cast);       
            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);           
        
        }

       










    }












}