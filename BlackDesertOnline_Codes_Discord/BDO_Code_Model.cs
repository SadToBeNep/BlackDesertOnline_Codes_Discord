using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    
    internal class BDO_Code_Model
    {
        public string date { get; set; }
        public string code { get; set; }
        public List<BDO_Code_Model> stored_codes = new List<BDO_Code_Model>() { };

        public void addToList(string code, string date)
        {
            stored_codes.Add(new BDO_Code_Model { code = code, date = date });
        }

        

    }
}
