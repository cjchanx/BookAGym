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
                        header: row["Header"].ToString(),
                        comment: row["Comment"].ToString()
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

        public static Announcement getAnnouncement(int id, DBContext context)
        {
            try
            {
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Announcement WHERE `Id` = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", id}
                    },
                    message: out string sql
                    );
                if (table == null)
                    throw new Exception(sql);
                Announcement announcement = null;

                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine("hi2");
                    announcement = new Announcement(
                    id,
                    header: dataRow["Header"].ToString(),
                    comment: dataRow["Comment"].ToString()
                    );
                }
                return announcement;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void editAnnouncement(int id, string header, string comment, DBContext context)
        {
            Console.WriteLine("Updating " + id);
            try
            {
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "UPDATE `Announcement` SET `Header`=@header, `Comment`=@comment WHERE `Id`=@id",
                    parameters: new Dictionary<string, object> {
                        {"@id", id },
                        {"@header", header },
                        {"@comment", comment },
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

        public static int ForceDelete(DBContext context, int id = -1)
        {
            if (id == -1)
            {
                throw new Exception("Invalid ID announcement.");
            }

            try
            {
                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "DELETE FROM `Announcement` WHERE `Id`=@Id",
                    parameters: new Dictionary<string, object> {
                        {"@Id", id },
                    },
                    message: out string message
                );
                if (rowsAffected == -1)
                    throw new Exception(message);
                if (rowsAffected == 0)
                {
                    Console.WriteLine("No announcement with given id.");
                }
                else
                {
                    Console.WriteLine("Sucessfully deleted.");
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }
    }
}
