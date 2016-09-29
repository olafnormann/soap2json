using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using soap2json.personref;
//using System.Web.Script.Serialization;
using soap2json.Models;

namespace soap2json.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string personregister(string id)
        {
            const string format = "Format: ./personregister/###########";
            
            if (id != null && id.Length!=11)
            {
                return "Lengde på personnr er feil (må være 11 siffer) <br />" + format;
            }
            else if (id == null)
            {
                return "Du må angi personnr (11 siffer) <br />" + format;
            }
            else //angitt persnr ser ut til å være rett. Prøve å hente:
            {
                personregister persreg = new personregister();

                string pp = persreg.HentPerson(id);

                if (pp == null || pp=="null")
                {
                    return "Personnr " + id + " finnes ikke! <br />" + format;
                }
                else //Ser ut til at vi har fått noe fra persreg:
                {
                    return pp;
                }
            }
        }

        public string barnregister(string id)
        {
            const string format = "Format: ./barneregister/###########";

            if (id != null && id.Length != 11)
            {
                return "Lengde på personnr er feil (må være 11 siffer) <br />" + format;
            }
            else if (id == null)
            {
                return "Du må angi personnr (11 siffer) til mor eller far<br />" + format;
            }
            else //angitt persnr ser ut til å være rett. Prøve å hente:
            {
                personregister persreg = new personregister();

                string pp = persreg.HentBarn(id);

                if (pp == null || pp == "null")
                {
                    return "Personnr " + id + " finnes ikke! <br />" + format;
                }
                else //Ser ut til at vi har fått noe fra persreg:
                {
                    return pp;
                }
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Olaf Normann.";

            return View();
        }
    }
}