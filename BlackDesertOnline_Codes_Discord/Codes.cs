using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    [Table(name: "tbl_BDOCodes")]
    internal class Codes
    {
        public int id { get; set; }
        public string date_till { get; set; }
        public string gift_code { get; set; }
    }
}
