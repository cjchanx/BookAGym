using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class Config
    {
        #region Constructors
        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public Config() { }

        /// <summary>
        /// Configuration constructor with parameters.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="name"></param>

        public Config(int max_bookings_per_hour)
        {
            MAX_BOOKINGS_PER_HOUR = max_bookings_per_hour;
        }

        #endregion

        #region Properties

        public int MAX_BOOKINGS_PER_HOUR { get; set; }

        #endregion
    }
}
