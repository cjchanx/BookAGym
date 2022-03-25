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
    public class ConfigurationHelper_db
    {
        // getClientConfiguration attempts to
        // return a Config object based on the `Configuration` table
        // inside the database
        // @returns - Configuration object on success
        // @returns - null configuration object on failure to access row
        public static Models.Config getClientConfiguration(DBContext context, out StatusResponse response)
        {
            try
            {
                // Attempt to get from the database
                DataTable table = context.ExecuteDataQueryCommand(
                    commandText: "SELECT * FROM Configuration",
                    parameters: new Dictionary<string, object>
                    {
                    },
                    message: out string message
                );


                // Verify object exists
                if (table == null)
                    throw new Exception(message);

                // Parse table and set Config instance
                // note: it is expected that only one row
                // should ever exist in the `Configuration` table
                Config inst = null;
                foreach (DataRow row in table.Rows)
                {
                    inst = new Config(int.Parse(row["MAX_BOOKINGS_PER_HOUR"].ToString()));
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
    }
}
