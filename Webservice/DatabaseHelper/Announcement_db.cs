using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Core;
using System.Data;
using Webservice.Models;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;

namespace Webservice.DatabaseHelper
{
    public class Announcement_db
    {

        public static List<Announcement> AllAnnouncement(DBContext context)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Announcement",
                    parameters: new Dictionary<string, object>
                    {

                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Announcement> inst = new List<Announcement>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Announcement(
                        id: int.Parse(row["Id"].ToString()),
                        header: row["UserName"].ToString(),
                        comment: row["Password"].ToString()
                        )
                    );
                }
                return inst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    public static void AddAnnouncement(string header, string comment,  DBContext context)
        {
            try
            {
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "INSERT INTO Announcement (Header, Comment) VALUES (@header, @comment)",
                    parameters: new Dictionary<string, object> {
                        {"@header", header },
                        {"@comment", comment }
                    },
                    message: out string message
                );
                if (rowsAffected == -1)
                    throw new Exception(message);
                if (rowsAffected == 0)
                    throw new Exception(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
