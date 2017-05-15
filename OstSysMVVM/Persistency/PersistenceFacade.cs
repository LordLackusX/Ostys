using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using OstSysMVVM.Model;

namespace OstSysMVVM.Persistency
{
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:61359";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public List<Apartment> GetApartments()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Apartments").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var apartmentlist = response.Content.ReadAsAsync<IEnumerable<Apartment>>().Result;
                        return apartmentlist.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
    }
}
