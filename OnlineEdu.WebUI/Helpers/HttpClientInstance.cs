﻿namespace OnlineEdu.WebUI.Helpers
{
    public static class HttpClientInstance
    {


        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7191/api/");

            return client;
        }



    }
}
