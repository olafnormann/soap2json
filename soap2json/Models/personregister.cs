using soap2json.personref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace soap2json.Models
{// Checking git.....
    public class personregister
    {
        JavaScriptSerializer jser;
        PersonServiceClient ps;
        LookupParameters lookup;

        private void init()
        {
            jser = new JavaScriptSerializer();
            ps = new PersonServiceClient();
            lookup = new LookupParameters();

            ps.ClientCredentials.UserName.UserName = "test";
            ps.ClientCredentials.UserName.Password = "BF32511";

        }

        public personregister()
        {
            init();
        }
        public string HentPerson(string persno)
        {
            lookup.NIN = persno;
            return jser.Serialize(ps.GetPerson(lookup));
        }

        public string HentBarn(string persno)
        {
            return jser.Serialize(ps.GetChildren(persno));

        }
    }
}