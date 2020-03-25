using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.BAL;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "x-UIVersion")]
    public class ValueToWordController : ApiController
    {
        [System.Web.Http.HttpPost]
        public CLSConvertToWord Create(CLSConvertToWord _ConvertToWord)
        {
            CLSConvertToWord _CTW = new CLSConvertToWord();
            _ConvertToWord.NumericToWords = ConvertToWord.NumericToWords(_ConvertToWord.Value);
            return _ConvertToWord;// Ok(_ConvertToWord);
        }
             
    }
}
