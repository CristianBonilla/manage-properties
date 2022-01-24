using System;
using System.Net;
using System.Collections.Generic;
using RealEstate.Properties.Contracts.DTO;

namespace RealEstate.Properties.Contracts.Exceptions
{
    /// <summary>
    /// Exception for when services fail
    /// </summary>
    public class ServiceErrorException : Exception
    {
        /// <summary>
        /// HTTP status type to return
        /// </summary>
        public HttpStatusCode Status { get; }

        /// <summary>
        /// Instance of the service error to get the list of error messages
        /// </summary>
        public ServiceError Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceErrorException"/> class
        /// </summary>
        /// <param name="status">Http status code</param>
        /// <param name="errors">Error list</param>
        public ServiceErrorException(HttpStatusCode status, params string[] errors)
        {
            Status = status;
            Errors = new() { Errors = new HashSet<string>(errors) };
        }
    }
}
