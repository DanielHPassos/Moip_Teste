using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Model
{
    public class RequestResponseModel
    {
        public string RequestUrl { get; set; }
        public string ResponseStatus { get; set; }

        public bool Any()
        {
            return RequestUrl != null && ResponseStatus != null;
        }
    }
}
