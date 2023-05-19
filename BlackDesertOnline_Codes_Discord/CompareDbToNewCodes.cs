using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

/* Well, I have an idea of how I could compare these two lists
 * First of all, I create a dictionary with keys being all the codes from the database
 * Then I try to add the new codes to the dictionary, if it fails it means the database already contains the code, so I dont need to add it agian, if it adds
 * then it means the database does not contain that code, the keys{bdo codes} that could be added are all new so I store the separetely and later display on discord
 * 
 */



namespace BlackDesertOnline_Codes_Discord
{
    internal static class CompareDbToNewCodes
    {
        public static BDO_Code_Model CompareTheTwo(BDO_Code_Model db_codes, BDO_Code_Model new_codes)
        {
            Dictionary<string, int> codes_from_database = new Dictionary<string, int>();
            BDO_Code_Model codes_not_in_db = new BDO_Code_Model();
            int counter = 0;
            foreach(var code in db_codes.stored_codes)
            {
                codes_from_database.Add(code.code,counter);
            }
            foreach(var codes_new in new_codes.stored_codes)
            {
                try
                {
                    codes_from_database.Add(codes_new.code,counter);
                    Console.WriteLine("[+]Found a new code: "+codes_new.code);
                    codes_not_in_db.stored_codes.Add(new BDO_Code_Model { code = codes_new.code, date = "XXXX" });
                }
                catch 
                {
                    Console.WriteLine("[-]Already added code: "+codes_new.code+" discarded");
                    
                }
            }
            return codes_not_in_db;   
        }
    }
}
