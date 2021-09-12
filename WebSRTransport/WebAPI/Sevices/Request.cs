using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Sevices
{
    public class Request
    {
        private HttpWebRequest request;
        private HttpWebResponse response;

        public string GetData(string url)
        {
            string result = "";
            try
            {
                using (Stream stream = GetResponse(url))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return result;
        }

        public Stream GetResponse(string url)
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30000;
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            return response.GetResponseStream();
        }

        public Request()
        {
        }

        ~Request()
        {
            response?.Close();
        }
    }
}
