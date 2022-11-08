using System;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

public class AdobeSignAuthPostRequest
{

    private string authUrl = "https://secure.na4.adobesign.com/oauth/v2/token";

    static void Main(string[] args)
    {
        AdobeSignAuthPostRequest adobe = new AdobeSignAuthPostRequest();
        adobe.getCode();
    }

    public async Task getCode()
    {
        var tokenUrl = "https://api.na1.echosign.com/oauth/v2/refresh";
        var query = new Dictionary<string, string>()
        {
            ["refresh_token"] = "3AAABLblqZhC952GRZqHCgXNPKGlDEvpYxHc0X6xVAYshqq7MXK19bDaXya7iCHILL2gikjA1wF4*",
            ["client_id"] = "CBJCHBCAABAAdVRw0T08yGCdAdD4R2ohlhVS4v3xzLHW",
            ["client_secret"] = "e5RibobnBGCVP2dqh08supj9BcSMnqJo",
            ["grant_type"] = "refresh_token",
        };

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsync(tokenUrl, new FormUrlEncodedContent(query)).Result;
            var plainText = await response.Content.ReadAsStringAsync();
            Console.WriteLine(plainText);
        }
    }

    public class Root
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string api_access_point { get; set; }
        public string web_access_point { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
