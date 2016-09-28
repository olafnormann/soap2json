using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using soap2json.personref;
using System.Web.Script.Serialization;

namespace soap2json.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult s2j()
        {
            JavaScriptSerializer jser = new JavaScriptSerializer();
            String str;
            Person pp;
            PersonServiceClient ps = new PersonServiceClient();
            LookupParameters lookup = new LookupParameters();
            lookup.NIN = "13049544221";
            ps.ClientCredentials.UserName.UserName = "test";
            ps.ClientCredentials.UserName.Password = "BF32511";

            pp = ps.GetPerson(lookup);
            str = jser.Serialize(pp);

            //Det følgende er et forsøk på å få til newline (<br />) men ga opp.....:
            IHtmlString html = new HtmlString("Serialisert JSON for Persnr "
                        + lookup.NIN.ToString()
                        + " Navn: " + pp.GivenName +  ": < br />") ;

            ViewBag.Message =  (html + str);
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}