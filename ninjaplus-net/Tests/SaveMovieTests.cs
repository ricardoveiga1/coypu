using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using System;
using NinjaPlus.Pages;
using NinjaPlus.Common;
using NinjaPlus.Models;

namespace NinjaPlus.Tests
{


    public class SaveMovieTests : BaseTest
    {

        private LoginPage _loginPage;
        private MoviePage _moviePage;


        [SetUp]
        public void Before()
        
        {
            _loginPage = new LoginPage(Browser);
            _moviePage = new MoviePage(Browser);
            _loginPage.With("ricardoveiga.ti@gmail.com", "123");


        }
        [Category("Filmes")]
        [Test]
        public void ShouldSaveMovie()
        {
            var movieData = new MovieModel()
            {
            Title = "Residente Evil",
            Status = "Disponível",
            Year = 2002,
            DataEstreia = "01/02/20202",
            Cast = { "tor1", "Ricardo Teste", "Tom" },
            Plot = "A missão, testesttettetstettskkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"
            };

            _moviePage.Add();
            _moviePage.Save(movieData);
            Thread.Sleep(5000);

        }


    }







}