using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    public class TextReadController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Table02Model> Get()
        {
            string strTable01Address = @"C:\ReposGit\PracticeASPNETWebApi\PracticeASPNET-WebAPI\Text Tables\Table01.txt";
            string strTable02Address = @"C:\ReposGit\PracticeASPNETWebApi\PracticeASPNET-WebAPI\Text Tables\Table02.txt";
            ViewModel model = new ViewModel();

            return model.GetModel(strTable01Address, strTable02Address);
        }

        


    }
}
