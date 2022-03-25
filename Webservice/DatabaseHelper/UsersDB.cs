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
    public class UsersDB
    {
        public static int ValidateLogin(DBContext context, string username, string password)
        {
            try
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Users WHERE `UserName` = @username AND `Password`=@password",
                    parameters: new Dictionary<string, object>
                    {
                        {"@username", username},
                        {"@password", password}
                    },
                    message: out string sql
                    );
       
                if (table == null)
                {
                    Console.WriteLine("Table error");
                    Console.WriteLine(sql);
                    return 0;
                }
                else
                {
                    Console.WriteLine("Checking db...");
                    if (table.Rows.Count > 0)
                    {
                        Console.WriteLine("Found matching credentials!");
                        return 1;
                    }
                    else {
                        Console.WriteLine("No users found!");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Here 2");
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static void AddAccount(string username, string password,  DBContext context)
        {
            try
            {
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "INSERT INTO Users (UserName, Password) VALUES (@username, @password)",
                    parameters: new Dictionary<string, object> {
                        {"@username", username },
                        {"@password", password }
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
