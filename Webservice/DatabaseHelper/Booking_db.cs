using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Core;
using Webservice.Models;
using System.Data;


namespace Webservice.Helpers
{
    public class Booking_db
    {
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