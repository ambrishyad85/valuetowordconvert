using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using MVCValueToWord.Controllers;
using API.Controllers;

namespace Unity
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void checknumbertoword()
        {
            string ExpectedNumericToWords = "one hundred  twenty-three dollars and  cents";
            string ExpectedName = "Ambrish";
            ClsValueToWord _ClsValueToWord = new ClsValueToWord();
            _ClsValueToWord.Name = "Ambrish";
            _ClsValueToWord.Value = 123.45;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51859/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responce = client.PostAsJsonAsync("api/ValueToWord/Create", _ClsValueToWord);

                // Assert.AreEqual(ExpectedNumericToWords, _ClsValueToWord.NumericToWords);
                Assert.AreEqual(ExpectedName, _ClsValueToWord.Name);
            }
        }
        //[Test]
        
        //public void abc()
        //{

        //    string ExpectedNumericToWords = "one hundred  twenty-three dollars and  cents";
        //    string ExpectedName = "Ambrish";
        //    var _ClsValueToWord = new ClsValueToWord();
        //    _ClsValueToWord.Name = "Ambrish";
        //    _ClsValueToWord.Value = 123.45;

        //    var controller = new ValueToWordController();

        //    var actionResult = controller.Create(_ClsValueToWord);
            
        //    Assert.AreEqual(ExpectedNumericToWords, actionResult.NumericToWords);
        //    Assert.AreEqual(ExpectedName, actionResult.Name);
        //}

    }
}
