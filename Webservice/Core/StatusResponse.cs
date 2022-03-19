using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Webservice.Core
{
    /// <summary>
    ///  REFERENCE : The following class is from an class example from CPSC471F2021 Week 8 Lectures.
    ///  StatusResponse is a class which stores the specified HTTP response of a request
    ///  when it is called in Database Helper methods.
    /// </summary>
    public class StatusResponse
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public StatusResponse(HttpStatusCode statusCode, string message)
        {
            Setup(statusCode, message);
        }

        /// <summary>
        /// Creates a valid response.
        /// </summary>
        public StatusResponse(string message)
            : this(HttpStatusCode.OK, message)
        {
        }

        /// <summary>
        /// Creates a status response from an exception.
        /// </summary>
        public StatusResponse(Exception exception)
        {
            if (exception is StatusException statusException)
                Setup(statusException.StatusCode, statusException.Message);
            else
                Setup(HttpStatusCode.InternalServerError, exception.ToString());
        }

        #endregion

        #region Properties

        /// <summary>
        /// The status code that represents the status of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Human readable explanation of the status code.
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Called by the constructors to setup the properties.
        /// </summary>
        private void Setup(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// Custom ToString to help with debugging.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", StatusCode.ToString(), Message);
        }

        #endregion
    }
}
