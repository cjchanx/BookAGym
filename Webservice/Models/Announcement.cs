using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class Announcement
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Header"></param>
        /// <param name="Comment"></param>
        public Announcement()
        {

        }
        public Announcement(int id, string header, string comment)
        {
            Id = id;
            Header = header;
            Comment = comment;

        }

        #endregion

        #region Properties
        public int Id { get; set; }

        public string Header { get; set; }
        public string Comment { get; set; }


        #endregion
    }
}
