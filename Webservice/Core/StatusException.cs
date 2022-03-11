﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Webservice.Core
{

    internal class StatusException : Exception
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public StatusException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The status code that represents the error.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        #endregion

        #region Methods

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
