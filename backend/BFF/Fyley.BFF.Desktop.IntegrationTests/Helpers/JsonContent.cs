using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Fyley.BFF.Desktop.IntegrationTests.Helpers
{
    public class JsonContent : StringContent
    {
        public JsonContent(object content, Encoding encoding = null) : 
            base(JsonConvert.SerializeObject(content), encoding, "application/json")
        {
        }
    }
}