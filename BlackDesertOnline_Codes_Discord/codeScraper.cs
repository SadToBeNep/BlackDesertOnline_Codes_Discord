using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    static class codeScraper
    {
        public static void scraper()
        {
            Thread.Sleep(5000);
            //t.Start();
            //List<BDO_Code_Model> list_of_codes = new List<BDO_Code_Model>(); //List that we use to store codes before writing to SQL 
            BDO_Code_Model new_code = new BDO_Code_Model(); //Model for codes
            var url = "https://incendar.com/bdo_pearl_abyss_coupon_codes.php"; //Url from where we grab the codes
            var web = new HtmlWeb(); //Create object
            var doc = web.Load(url); //Load page

            var value = doc.DocumentNode.SelectNodes("/html/body/center/table"); //Location of the table that contains the code [XPATH]
            var stripped = value[0].InnerHtml; //Select the part where the codes are
            var x = Regex.Matches(stripped, "[\\w]{4}-[\\w]{4}-[\\w]{4}-[\\w]{4}"); //Regex search the pattern [XXXX-XXXX-XXXX-XXXX]
            foreach (Match match in x)
            {
                new_code.addToList(code: match.Value, date: "XXX");
            }
            Console.WriteLine("[+]Collected all codes from website");

            var codes_from_db = DatabaseOperations.GetAllCodesFromDatabase();

            var all_new_codes = CompareDbToNewCodes.CompareTheTwo(codes_from_db, new_code);
            Console.WriteLine("[+]Filtered out all the new codes");
            Console.WriteLine("[+]Adding new codes to database");
            DatabaseOperations.AddCodeToTable(all_new_codes);
            CurrentCodes.current_codes = codes_from_db;

            Console.Write("[+]Updated, waiting...");
            Thread.Sleep(7300000);
        }
    }
}
