﻿using System;
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
                        foreach (DataRow row in table.Rows) {
                            if (row["UserName"].ToString() == "Admin")
                            {
                                Console.WriteLine("Hello Admin!");
                                return 2;
                            }
                            else {
                                Console.WriteLine("Hello User!");
                                return 1;
                            }
                        }
                        return 0;
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

        public static List<Users> AllAccounts(DBContext context)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Users",
                    parameters: new Dictionary<string, object>
                    {

                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Users> inst = new List<Users>();
                foreach (DataRow row in table.Rows)
                {
                    if (row["UserName"].ToString() != "Admin")
                    {
                        inst.Add(new Users(
                        id: int.Parse(row["Id"].ToString()),
                        username: row["UserName"].ToString(),
                        password: row["Password"].ToString()
                        )
                    );
                    }
                }
                return inst;
            }
            catch (Exception ex)
            {
                return null;
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

        public static Users getAccount(int id, DBContext context)
        {
            try
            {
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Users WHERE `Id` = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", id}
                    },
                    message: out string sql
                    );
                if (table == null)
                    throw new Exception(sql);
                Users users = null;
                Console.WriteLine("work?");
                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine("hi2");
                    users = new Users(
                    id,
                    username: dataRow["UserName"].ToString(),
                    password: dataRow["Password"].ToString()
                    );
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void EditAccount(string username, string password, DBContext context)
        {
            Console.WriteLine("Updating " + username);
            try
            {
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "UPDATE `Users` SET `Password`=@password WHERE `UserName`=@username",
                    parameters: new Dictionary<string, object> {
                        {"@username", username },
                        {"@password", password },
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
