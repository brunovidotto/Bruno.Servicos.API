using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bruno.Servicos.Utilitario
{
    public class ClientWebApi
    {
        readonly HttpClient _client = new HttpClient();

        public Encoding Encoding { get; set; }

        public TimeSpan Timeout
        {
            set { _client.Timeout = value; }
        }
        public ClientWebApi(string url)
        {
            Encoding = Encoding.UTF8;


            // New code:
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            
            _client.DefaultRequestHeaders.ExpectContinue = false;
        }


        public T Get<T>(string path)
        {
            T entity = default(T);
            HttpResponseMessage response = _client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                entity = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception(GetExceptionMessage(response));
            }
            return entity;

        }



        public T GetWithParameters<T>(string path, Dictionary<string, object> urlParameters)
        {
            T entity = default(T);
            string parameters = BuildURLParametersString(urlParameters);
            HttpResponseMessage response = _client.GetAsync(path + parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                entity = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception(GetExceptionMessage(response));
            }
            return entity;
        }

        private string BuildURLParametersString(Dictionary<string, object> parameters)
        {
            UriBuilder uriBuilder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var urlParameter in parameters)
            {
                query[urlParameter.Key] = urlParameter.Value.ToString();
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.Query;
        }

        public T Post<T>(string path, object entity)
        {
            var response = _client.PostAsJsonAsync(path, entity).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception(GetExceptionMessage(response));
            }
        }   

        public void Post(string path)
        {
            var response = _client.PostAsJsonAsync(path, (object)null).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(GetExceptionMessage(response));
            }
        }


        public void Post(string path, object entity)
        {
            var response = _client.PostAsJsonAsync(path, entity).Result;
            if (!response.IsSuccessStatusCode)
            { 
                throw new Exception(GetExceptionMessage(response));
            }
        }

        public void Put(string path, object entity)
        {
            var response = _client.PutAsJsonAsync(path, entity).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(GetExceptionMessage(response));
            }
        }

    

        public T Put<T>(string path, object entity)
        {
            var response = _client.PutAsJsonAsync(path, entity).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception(GetExceptionMessage(response));
            }
        }

        private string GetExceptionMessage(HttpResponseMessage response)
        {
            if (response != null)
            {
                var responseValue = string.Empty;

                Task task = response.Content.ReadAsStreamAsync().ContinueWith(t =>
                {
                    var stream = t.Result;
                    using (var reader = new StreamReader(stream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
                });

                task.Wait();
                return responseValue;


            }
            return string.Empty;
        }

        public void Delete(string path)
        {
            var response = _client.DeleteAsync(path).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(GetExceptionMessage(response));
            }
        }
    }

}
