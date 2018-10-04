using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ooui.AspNetCore;
using Xamarin.Forms;
using XamChat.Ooui.Models;
using XamChat.Views;

namespace XamChat.Ooui.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var app = new XamChat.App();
            var element = app.MainPage.GetOouiElement();

            return new ElementResult(element, "Xam Chat");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
