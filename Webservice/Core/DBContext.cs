using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Webservice.Core
{
    /// <summary>
    /// REFERENCE : The following class is based on a class example from CPSC471F2021 Week 8 Lectures.
    /// DBContext acts as an abstract class that can be derived from for
    /// specific database providers eg. MySQL, MariaDB, MSSQL
    /// </summary>
    public abstract class DBContext
    {
        #region Constructors

        /// <summary>
        /// Basic constructor which stores the string for database connection purposes.
        /// </summary>
        /// <param name="connection">Hostname URL.</param>
        public DBContext(string hostname)
        {
            Hostname = hostname;
        }

        #endregion

        #region Data

        /// <summary>
        /// Hostname used to connect to the database.
        /// </summary>
        public string Hostname { get; private set; }

        #endregion Data

        /// <summary>
        ///  These methods are from a class example from CPSC471F2021
        /// </summary>
        #region Methods
        /// <summary>
        /// Performs a setup required before running any further commands or queries.
        /// Usually gets called once on startup.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>States if the initialization has been completed without any issue.</returns>
        public abstract bool Initialize(out string message);

        /// <summary>
        /// Executes the provided command.
        /// </summary>
        /// <returns>States the number of rows affected by the command.</returns>
        public abstract int ExecuteNonQueryCommand(string commandText, Dictionary<string, object> parameters, out string message);

        /// <summary>
        /// Executes the provided command and retrieves some data.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>Datatabe with all the rows that are retrieved.</returns>
        public abstract DataTable ExecuteDataQueryCommand(string commandText, Dictionary<string, object> parameters, out string message);

        /// <summary>
        /// Executes the provided stored procedure.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>States the number of rows affected by the command.</returns>
        public abstract int ExecuteNonQueryProcedure(string procedure, Dictionary<string, object> parameters, out string message);

        /// <summary>
        /// Executes the provided stored procedure and retrieves some data.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>Datatabe with all the rows that are retrieved.</returns>
        public abstract DataTable ExecuteDataQueryProcedure(string procedure, Dictionary<string, object> parameters, out string message);

        #endregion
    }
}
