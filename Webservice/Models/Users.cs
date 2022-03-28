using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class Users
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Users()
        {

        }
        public Users(int id, string username, string password)
        {
            Id = id;
            UserName = username;
            Password = password;

        }

        #endregion

        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }


        #endregion
    }
}
