using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Core;
using Webservice.Models;
using System.Data;
using Webservice.DatabaseHelper;


namespace Webservice.Helpers
{
    public class Booking_db
    {

        /* Utility Functions */
        // Function utilizes getBookingsByHour to return the number of available bookings
        // by querying the application configuration
        // and comparing the relative values
        // @param date expected to be the START of the hour to be queried
        // @returns Number of the available bookings.
        //      Note: CAN be negative, recommended to use a > 0 comparison when
        //      checking in loop.
        public static int bookingsAvailable(DBContext context, out StatusResponse response, DateTime date)
        {
            // Query list of bookings for given DateTime
            List<Booking> bookings = getBookingsByHour(context, out response, date);
            int filled = bookings.Count;

            // Get the current maximum bookings per hour
            // based on the program configuration
            int max_bookings = DatabaseHelper
                .ConfigurationHelper_db
                .getClientConfiguration(context, out response)
                .MAX_BOOKINGS_PER_HOUR;

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
        public static List<Booking> getBookingsByHour(DBContext context, out StatusResponse response, DateTime date)
        {
            // Initialize helper variables for tracking time
            DateTime start = date;
            DateTime end = date.AddHours(1);

            // Attempt query
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Bookings WHERE " +
                    "`DateTime` >= @start" +
                    "AND" +
                    "`DateTime` < @end",
                    parameters: new Dictionary<string, object>
                    {
                        {"@start", date.ToString()},
                        {"@end", date.AddHours(1).ToString()}
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
                        time: DateTime.Parse(row["timeBooked"].ToString()),
                        name: row["username"].ToString()
                        )
                    );
                }

                // Return
                response = new StatusResponse("Bookings successfully retreived for time " + date.ToString() + ".");
                return inst;
            }
            catch (Exception ex)
            {
                response = new StatusResponse(ex);
                return null;
            }
        }



        /* Direct Database Queries */
        /// <summary>
        /// Force deletes an booking by its id, by deleting ALL linked assets.
        /// </summary>
        /// <returns>Account_db object</returns>
        public static int ForceDelete(DBContext context, out StatusResponse response, int id = -1)
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
                    response = new StatusResponse("No booking with given id.");
                }
                else
                    response = new StatusResponse("Sucessfully deleted.");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Error occured.
                response = new StatusResponse(ex);
                return -1;
            }
        }

        /// <summary>
        ///  updates an account's parameters based on it's Id 
        /// </summary>
        /// <returns>Booing object</returns>
        public static Booking Update(int id,DateTime time, string name, DBContext context, out StatusResponse response)
        {
            try
            {
                // Validate current data
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(System.Net.HttpStatusCode.BadRequest, "Invalid name entered.");

                // Create instance
                Booking inst = new Booking(id,time,name);

                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "UPDATE `Bookings` SET `username`=@name,`timeBooked`=@time, WHERE `Id`=@id",
                    parameters: new Dictionary<string, object> {
                        {"@id", inst.Id },
                        {"@time", inst.TimeBooked },
                        {"@name", inst.Username},
                    },
                    message: out string message
                );
                if (rowsAffected == -1 || rowsAffected == 0)
                    throw new Exception(message);

                // Return

                response = new StatusResponse("Booking updated successfully");
                return inst;
            }
            catch (Exception ex)
            {
                // Error occured.
                response = new StatusResponse(ex);
                return null;
            }
        }


        /// <summary>
        /// Add adds a new account entry into the database, assuming that it is active and using the current UTC time.
        /// </summary>
        /// <returns>Account_db object</returns>
        public static Booking Add(int id, DateTime time, string name, DBContext context, out StatusResponse response)
        {
            try
            {
                // Validate current data
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(System.Net.HttpStatusCode.BadRequest, "Invalid name entered.");

                // Create instance
                Booking inst = new Booking(id, time, name);


                // Attempt to add to database
                int rowsAffected = context.ExecuteNonQueryCommand(
                    commandText: "UPDATE `Bookings` SET `username`=@name,`timeBooked`=@time, WHERE `Id`=@id",
                    parameters: new Dictionary<string, object> {
                        {"@id", inst.Id },
                        {"@time", inst.TimeBooked },
                        {"@name", inst.Username },
                    },
                    message: out string message
                );
                if (rowsAffected == -1)
                    throw new Exception(message);

                // Return

                response = new StatusResponse("Booking added successfully");
                return inst;
            }
            catch (Exception ex)
            {
                // Error occured.
                response = new StatusResponse(ex);
                return null;
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
                        time: DateTime.Parse(row["timeBooked"].ToString()),
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
                        time: DateTime.Parse(row["timeBooked"].ToString()),
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
                        time: DateTime.Parse(row["timeBooked"].ToString()),
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
    }
}