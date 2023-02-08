using iscaBar.DAO.Servidor;
using iscaBar.Helpers;
using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IscaBar.DAO.Servidor
{
    internal class CategorySDAO
    {
        private static CategorySDAO _instance = null;
        public static CategorySDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new CategorySDAO(); return _instance;
                }
            }

        }
        public async Task<List<Categoria>> GetAllAsync()
        {
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(BaseUrl.UrlApi);

                HttpResponseMessage response = await client.GetAsync("/restaurapp_app/getCategory");
                String content = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                    List<Categoria> cat = JsonConvert.DeserializeObject<List<Categoria>>(data["data"].ToString());
                    return cat;

                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<String> UpdateAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/updateCat";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<String> AddAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/addCat";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<String> DeleteAsync(Categoria cat)
        {
            string URL = Constant.UrlApi + "restaurapp_app/delCat";
            Uri URI = new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat.Id);
            var httpContent = new StringContent(js, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PutAsync(URI, httpContent);
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                String list = JsonConvert.DeserializeObject<String>(content);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
