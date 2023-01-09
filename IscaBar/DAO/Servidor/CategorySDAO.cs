using IscaBar.Helpers;
using IscaBar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IscaBar.DAO.Servidor
{
    internal class CategorySDAO
    {
        public static async Task<List<Category>> UpdateCategory(Category cat)
        {
            string URL;
            Uri URI;

            URL = Constant.UrlApi + "restaurapp_app/category";
            URI= new Uri(URL);
            HttpClient client = new HttpClient();
            var js = JsonConvert.SerializeObject(cat);
            var httpContent = new StringContent(js, System.Text.Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.GetAsync(URI);
            
            try
            {
                response.Result.EnsureSuccessStatusCode();
                string content = await response.Result.Content.ReadAsStringAsync();
                List<Category> lcategories = JsonConvert.DeserializeObject<List<Category>>(content);
                return lcategories;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
