using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Core;
using Webservice.Models;
using System.Data;
using Webservice.DatabaseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webservice.DatabaseHelper
{
    public class Booking_db
    {

        public static int max_bookings = 0;

        /* Utility Functions */
        // Function utilizes getBookingsByHour to return the number of available bookings
        // by querying the application configuration
        // and comparing the relative values
        // @param date expected to be the START of the hour to be queried
        // @returns Number of the available bookings.
        //      Note: CAN be negative, recommended to use a > 0 comparison when
        //      checking in loop.
        public static int bookingsAvailable(DateTime date, DBContext context)
        {
            // Query list of bookings for given DateTime
            List<Booking> bookings = getBookingsByHour(date, context);
            int filled = 0;
            if (bookings != null)
            {
                filled = bookings.Count;
            }

            if (max_bookings == 0) {
                // Get the current maximum bookings per hour
                // based on the program configuration
                max_bookings = DatabaseHelper
                     .ConfigurationHelper_db
                     .getClientConfiguration(context)
                     .MAX_BOOKINGS_PER_HOUR;
            }
            
           // Compare and return difference
           return max_bookings - filled;

        }


        /* Selective Application Unified Database Queries */
        // Function returns a List of Booking objects containing all bookings for a specific hour passed by the
        // DateTime object given in the 'date' parameter.
        // Note : While we expect bookings to always start based on the exact hour, with no in between hours
        // this function will account for potential partial hours.
        // @param date expected to be the START of the hour to be queried
        // @returns List<Booking>
        public static List<Booking> getBookingsByHour(DateTime date, DBContext context)
        {


            // Attempt query
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM `Bookings` WHERE `booktime` = @start",
                    parameters: new Dictionary<string, object>
                    {
                        {"@start", date.ToString("yyyy/MM/dd HH:mm:ss")}
                    },
                    message: out string message
                );

                if (table == null) {
                    Console.WriteLine(message);
                    return null;
                }
                    

                // Parse
                List<Booking> inst = new List<Booking>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Booking(
                        id: int.Parse(row["Id"].ToString()),
                        time: DateTime.Parse(row["booktime"].ToString()),
                        name: row["username"].ToString()
                        )
                    );
                }

                // Return
                Console.WriteLine("Bookings successfully retreived for time " + date.ToString() + ".");
                return inst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /* Direct Database Queries */
        /// <summary>
        /// Force deletes an booking by its id, by deleting ALL linked assets.
        /// </summary>
        /// <returns>Account_db object</returns>
        public static int ForceDelete(DBContext context, int id = -1)
        {
            if (id == -1)
            {
                throw new Exception("Invalid ID book.");
            }

            try
            {
                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "DELETE FROM `Bookings` WHERE `Id`=@Id",
                    parameters: new Dictionary<string, object> {
                        {"@Id", id },
                    },
                    message: out string message
                );
                if (rowsAffected == -1)
                    throw new Exception(message);
                if (rowsAffected == 0)
                {
                         Console.WriteLine("No booking with given id.");
                }
                else {
                         Console.WriteLine("Sucessfully deleted.");
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        /// <summary>
        ///  updates an account's parameters based on it's Id 
        /// </summary>
        /// <returns>Booing object</returns>
        public static void Update(int id,DateTime time, DBContext context)
        {
            try
            {

                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "UPDATE `Bookings` SET `booktime`=@time WHERE `Id`=@id",
                    parameters: new Dictionary<string, object> {
                        {"@id", id},
                        {"@time", time.ToString("yyyy/MM/dd HH:mm:ss")},
                    },
                    message: out string message
                );
                if (rowsAffected == -1 || rowsAffected == 0) {
                        Console.WriteLine(message);
                }


                // Return

               Console.WriteLine("Booking updated successfully");
            }
            catch (Exception ex)
            {
               Console.WriteLine("Booking not updated");
            }
        }


        /// <summary>
        /// Add adds a new account entry into the database, assuming that it is active and using the current UTC time.
        /// </summary>
        /// <returns>Account_db object</returns>
        public static void Add(DateTime time, string name, DBContext context)
        {
            try
            {
                // Validate current data
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(System.Net.HttpStatusCode.BadRequest, "Invalid name entered.");



                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "INSERT INTO Bookings (username, booktime) VALUES (@username, @booktime)",
                    parameters: new Dictionary<string, object> {
                        {"@username", name },
                        {"@booktime", time },
                    },
                    message: out string message
                );
                if (rowsAffected == -1) {
                       Console.WriteLine(message);
                }


                // Return

                  Console.WriteLine("Booking added successfully");
            }
            catch {
                Console.WriteLine("Booking adding failed");
            }
        }


        public static List<Booking> getCollection(DBContext context, out StatusResponse response)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Bookings",
                    parameters: new Dictionary<string, object>
                    {

                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Booking> inst = new List<Booking>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Booking(
                        id: int.Parse(row["Id"].ToString()),
                        time: DateTime.Parse(row["booktime"].ToString()),
                        name: row["username"].ToString()
                        )
                    );
                }

                // Return
                response = new StatusResponse("Bookings successfully retreived.");
                return inst;
            }
            catch (Exception ex)
            {
                response = new StatusResponse(ex);
                return null;
            }
        }

        public static List<Booking> getBookingById(int id, DBContext context, out StatusResponse response)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Bookings WHERE `Id`=@id",
                    parameters: new Dictionary<string, object>
                    {
                        {"@id", id}
                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Booking> inst = new List<Booking>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Booking(
                        id: int.Parse(row["Id"].ToString()),
                        time: DateTime.Parse(row["booktime"].ToString()),
                        name: row["username"].ToString()
                        )
                    );
                }

                // Return
                response = new StatusResponse("Accounts successfully retreived.");
                return inst;
            }
            catch (Exception ex)
            {
                response = new StatusResponse(ex);
                return null;
            }
        }

        public static List<Booking> getCollection(DBContext context)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Bookings",
                    parameters: new Dictionary<string, object>
                    {

                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Booking> inst = new List<Booking>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Booking(
                        id: int.Parse(row["Id"].ToString()),
                        time: DateTime.Parse(row["booktime"].ToString()),
                        name: row["name"].ToString()
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

        public static List<Booking> getCollection(string name, DBContext context)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Bookings WHERE `username` = @username",
                    parameters: new Dictionary<string, object>
                    {
                        {"@username", name},
                    },
                    message: out string message
                );

                if (table == null)
                    throw new Exception(message);

                // Parse
                List<Booking> inst = new List<Booking>();
                foreach (DataRow row in table.Rows)
                {
                    inst.Add(new Booking(
                        id: int.Parse(row["Id"].ToString()),
                        time: DateTime.Parse(row["booktime"].ToString()),
                        name: row["username"].ToString()
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
    }
}