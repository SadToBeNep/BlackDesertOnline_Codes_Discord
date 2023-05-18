using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    internal static class DatabaseOperations
    {

        public static void AddCodeToTable(BDO_Code_Model list_of_codes)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;database=BDOCodes;Trusted_Connection=True;Encrypt=False";

            var db = new DbContextOptionsBuilder<DatabaseController>().UseSqlServer(connectionString).Options;
            var db_context = new DatabaseController(db);
            foreach (var code in list_of_codes.stored_codes)
            {
                Console.WriteLine("Adding: " + code.code + " to database");
                db_context.tbl_BDOCodes.Add(new Codes { id = 0, date_till = code.date, gift_code = code.code });
            }
            db_context.SaveChanges();
            Console.WriteLine("All codes were added to the database, and saved successfully");
        }

        public static BDO_Code_Model GetAllCodesFromDatabase()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;database=BDOCodes;Trusted_Connection=True;Encrypt=False";

            var db = new DbContextOptionsBuilder<DatabaseController>().UseSqlServer(connectionString).Options;
            var db_context = new DatabaseController(db);
            BDO_Code_Model codes_from_db = new BDO_Code_Model();
            var db_stored_codes = db_context.tbl_BDOCodes.AsEnumerable();
            foreach(var x in db_stored_codes)
            {
                codes_from_db.stored_codes.Add(new BDO_Code_Model { date = x.date_till, code = x.gift_code });
            }

            Console.WriteLine("Table got");
            return codes_from_db;
        }
    }
}
