using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Model
{
    public class RequestUrlModel
    {
        public string RequestUrl { get; set; }

        public RequestUrlModel(string requestUrl)
        {
            this.RequestUrl = requestUrl;
        }
    }
}
