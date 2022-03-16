using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Core.Common
{
    public class Response
    {
        /// <summary>
        /// Is success.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Response message.
        /// </summary>
        public dynamic Message { get; set; }

        /// <summary>
        /// Gets or sets the extra information.
        /// </summary>
        public dynamic ExtraInfo { get; set; }
    }
}
