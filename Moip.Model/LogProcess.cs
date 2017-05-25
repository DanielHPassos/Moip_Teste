using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Moip.Model
{
    public class LogProcess
    {
        private List<string> lines;
        private const string SEPARATOR = "level=info";
        private Regex regexRequestTo => new Regex("(request_to=\".+?\")");
        private Regex regexResponseStatus => new Regex("(response_status=\".+?\")");

        public LogProcess(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new Exception();

            lines = File.ReadAllLines(fileName).ToList();

        }
        public List<RequestResponseModel> Process()
        {
            try
            {
                var builder = new StringBuilder();
                var requestResponseList = new List<RequestResponseModel>();

                lines.ForEach(x => builder.Append(x));

                var result = builder.ToString().Split(new string[] { SEPARATOR }, StringSplitOptions.None);

                result.ToList().ForEach(x =>
                {
                    var requestResponse = new RequestResponseModel();

                    if (regexRequestTo.Match(x).Success)
                        requestResponse.RequestUrl = regexRequestTo.Match(x).Value;

                    if (regexResponseStatus.Match(x).Success)
                        requestResponse.ResponseStatus = regexResponseStatus.Match(x).Value;

                    if (requestResponse.Any())
                        requestResponseList.Add(requestResponse);
                });

                return requestResponseList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
                    }
        
        public void GetTopUrl(List<RequestResponseModel> listRequestResponse, int topNumber)
        {
            try
            {
                var resultByRequestUrl = listRequestResponse.GroupBy(x => x.RequestUrl)
                .OrderByDescending(x => x.Count())
                .Take(topNumber)
                .Select(x => new { Value = x.Key, Count = x.Count() });

                foreach (var x in resultByRequestUrl)
                {
                    Console.WriteLine(x.Value.Substring(12, x.Value.Length - 13) + " - " + x.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void GetTopStatus(List<RequestResponseModel> listRequestResponse)
        {
            try
            {
                var resultByRequestUrl = listRequestResponse.GroupBy(x => x.ResponseStatus)
                .OrderByDescending(x => x.Count())
                .Select(x => new { Value = x.Key, Count = x.Count() });

                foreach (var x in resultByRequestUrl)
                {
                    Console.WriteLine(x.Value.Substring(17, x.Value.Length - 18) + " - " + x.Count);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
