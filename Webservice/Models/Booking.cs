using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class Booking
    {
        #region Constructors
        /// <summary>
        /// Account constructor with parameters.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="name"></param>

        public Booking(int id, DateTime time, string name)
        {
            Id = id;
            TimeBooked = time;
            Username = name;
        }

        #endregion

        #region Properties

        public string Username { get; set; }

        public DateTime TimeBooked { get; set; }

        public int Id { get; set; }

        #endregion
    }
}
