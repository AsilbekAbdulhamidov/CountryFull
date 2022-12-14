using System.Text;
using Data1.Models;
using Newtonsoft.Json;
using System.Windows;
using Data1.DTO;
using System.Net.Http;

namespace ToWinFromFromAPI
{
    public class HalperAPI
    {
        private readonly HttpClient _client;
        private readonly string _url;
        public HalperAPI( string url)
        {
            _client = new HttpClient ();
            _url = url;
        }

        public async Task<List<Country>> Get()
        {
            var response = await _client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var res = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(json);
                return res;
            }

            else
            {
                
               
                return null;
            }
        }

        public async Task<Country> Get(int id)
        {
            var response = await _client.GetAsync(_url+"/"+id.ToString());  
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Country>(json);
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Delete(int id)
        {
            var response = await _client.DeleteAsync(_url + "/" + id.ToString());

            return response.ReasonPhrase;

        }

        public async Task<string> Put(int id, CounrtyDto country)
        {
            var json = JsonConvert.SerializeObject(country);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_url + "/" + id.ToString(), data);

            return response.ReasonPhrase;
        }

        public async Task<string> Post(CounrtyDto country)
        {
            var json = JsonConvert.SerializeObject(country);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, data);

            return response.ReasonPhrase;
        }

        //Region
        public async Task<string> DeleteRegion(int id)
        {
            var response = await _client.DeleteAsync(_url + "/" + id.ToString());

            return response.ReasonPhrase;

        }

        public async Task<string> PostRegion(RegionDto reg)
        {
            var json = JsonConvert.SerializeObject(reg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, data);

            return response.ReasonPhrase;
        }

        public async Task<string> PutRegion(int id, RegionDto country)
        {
            var json = JsonConvert.SerializeObject(country);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_url + "/" + id.ToString(), data);

            return response.ReasonPhrase;
        }


    }
}