//https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request

using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanA
{
    public class HTTPRequestReciever
    {
        string _basenameUri;
        static readonly HttpClient client = new HttpClient();

        public HTTPRequestReciever(string ip)
        {
            _basenameUri = ip;
        }

        public async Task<string> POST(string controller, string action, Dictionary<string, string> data)
        {
            data.Add("action", action);

            var content = new FormUrlEncodedContent(data);

            var response = await client.PostAsync(_basenameUri + "/" + controller, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> GET()
        {
            string responseString = await client.GetStringAsync(_basenameUri);
            return responseString;
        }
    }
}
