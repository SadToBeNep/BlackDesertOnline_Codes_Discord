using BlackDesertOnline_Codes_Discord;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;



var t = new Thread(webScraper);
t.Start();
var b = new DiscordBotController();
b.RunAsync().GetAwaiter().GetResult();
void webScraper() {
    Thread.Sleep(5000);
    //t.Start();
    //List<BDO_Code_Model> list_of_codes = new List<BDO_Code_Model>(); //List that we use to store codes before writing to SQL 
    BDO_Code_Model new_code = new BDO_Code_Model(); //Model for codes
    var url = "https://incendar.com/bdo_pearl_abyss_coupon_codes.php"; //Url from where we grab the codes
    var web = new HtmlWeb(); //Create object
    var doc = web.Load(url); //Load page

    var value = doc.DocumentNode.SelectNodes("/html/body/center/table"); //Location of the table that contains the code [XPATH]
    var stripped = value[0].InnerHtml; //Select the part where the codes are
                                       //var stripped = "<table class=\"bluetable\"><tbody><tr><td>✔️</td><td><center>⌛</center></td><td></td><td><center>🖱️</center></td><td class=\"priority-1\"><center>📝\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JUNE-XXXX-INGL-XXXX\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JUNE-M22N-INGL-IGHT\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JUNE-MORN-I22L-IGHT\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JUNE-MORN-INGL-I22T\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JU3E-MORN-INGL-IGHT\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>\r\n</center></td></tr><tr><td><input type=\"checkbox\" aria-label=\"bcodecheckbox\" id=\"bcode499\" class=\"box\" button=\"\" onclick=\"save(499)\"></td><td>7d</td><td>🖥️</td><td><input type=\"text\" aria-label=\"code\" size=\"20\" value=\"JU8E-MORN-INGL-IGHT\" id=\"inc499\" onclick=\"copy(499)\"> </td><td></td><td class=\"priority-1\">Haetae<br>Choose Your 7-Day</td></tr></tbody></table>"+stripped2;
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



