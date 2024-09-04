using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.DTO
{
    /// <summary>
    /// Represents the response format for API operations.
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public HttpStatusCode StatusCode;

        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool IsSuccess = true;

        /// <summary>
        /// Gets or sets a list of error messages, if any.
        /// </summary>
        public List<string> ErrorMessages = new List<string>();

        /// <summary>
        /// Gets or sets the result of the API operation.
        /// </summary>
        public object Result { get; set; }
    }
}
