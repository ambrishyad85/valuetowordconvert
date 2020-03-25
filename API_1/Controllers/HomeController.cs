using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;
namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(CLSConvertToWord _ConvertToWord)
        {
            CLSConvertToWord _CTW = new CLSConvertToWord();
            _ConvertToWord.NumericToWords = ConvertToWord.NumericToWords(1891056.123);
             
            return View();
        }
    }
}
