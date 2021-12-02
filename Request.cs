using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GameHeaven
{
    public static class Request<T>
    {
        
        public async static Task<T> GetAsync(string link, string token = null)
        {
            HttpClient client = new();
            if (token is not null)
            {
                client.DefaultRequestHeaders.Authorization =
                                   new AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage response = await client.GetAsync(link);
            string responseBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(responseBody);
            return values;
        }
        public async static Task<T> PostAsync(string link, string jsonData, string mediaType = "application/json", string token = null, List<(string, string)> filePaths = null, List<(string, string)> variables = null)
        {
            HttpClient client = new();
            if (token is not null)
            {
                client.DefaultRequestHeaders.Authorization =
                                   new AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage response = null;
            if (mediaType.Equals("application/json"))
            {
                HttpContent httpContent = new StringContent(jsonData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                response = await client.PostAsync(link, httpContent);
            }
            else
            {
                using var form = new MultipartFormDataContent();
                for (int i = 0; i < filePaths.Count; i++)
                {
                    var fileContent = new StreamContent(new FileStream(filePaths[i].Item1, FileMode.Open));
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, filePaths[i].Item2, Path.GetFileName(filePaths[i].Item1));
                }
                foreach (var variable in variables)
                {
                    if (variable.Item2 is not null)
                        form.Add(new StringContent(variable.Item2), variable.Item1);

                }
                response = await client.PostAsync(link, form);
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(responseBody);
            return values;


        }

        public async static Task<T> PutAsync(string link, string jsonData, string mediaType = "application/json", string token = null, List<(string, string)> filePaths = null, List<(string, string)> variables = null)
        {
            HttpClient client = new();
            if (token is not null)
            {
                client.DefaultRequestHeaders.Authorization =
                                   new AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage response = null;
            if (mediaType.Equals("application/json"))
            {
                HttpContent httpContent = new StringContent(jsonData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                response = await client.PutAsync(link, httpContent);
            }
            else
            {
                using var form = new MultipartFormDataContent();
                if (filePaths.Count>0)
                {
                    for (int i = 0; i < filePaths.Count; i++)
                    {
                        var fileContent = new StreamContent(new FileStream(filePaths[i].Item1, FileMode.Open));
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, filePaths[i].Item2, Path.GetFileName(filePaths[i].Item1));
                    }
                }
                foreach (var variable in variables)
                {
                    if (variable.Item2 is not null)
                        form.Add(new StringContent(variable.Item2), variable.Item1);

                }
                response = await client.PutAsync(link, form);
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(responseBody);
            return values;

        }
        public async static Task<T> DeleteAsync(string link, string token = null)
        {
            HttpClient client = new();
            if (token is not null)
            {
                client.DefaultRequestHeaders.Authorization =
                                   new AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage response = await client.DeleteAsync(link);
            string responseBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<T>(responseBody);
            return values;
        }
    }
}
