using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Model
{
    public class ResponseStatusModel
    {
        public string ResponseStatus { get; set; }

        public ResponseStatusModel(string responseStatus)
        {
            this.ResponseStatus = responseStatus;
        }
    }
}
