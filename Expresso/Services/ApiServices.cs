using Expresso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expresso.Services
{
    public class ApiServices
    {
        public async Task<List<Menu>> GetMenu()
        {
            var client = new HttpClient(); // Helps us communicate with the server
            var response = await client.GetStringAsync("https://xpressoapi.azurewebsites.net/api/menus"); //send get request to the API
            return JsonConvert.DeserializeObject<List<Menu>>(response); /*this will deserialize the json string to a list of menu 
                                                                         *It will map the Json with the properties of menu class
                                                                         *in a form of c# objects*/
        }

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reservation); //this will serialize the c# to json format
            var content = new StringContent(json, Encoding.UTF8, "application/json"); /* this StringContent class creates
                                                                                       * a string formatted text appropriate
                                                                                       * for the http server or client communication*/
            var response = await client.PostAsync("https://xpressoapi.azurewebsites.net/api/reservations", content); /* post content 
                                                                                                                     * in our server */
            return response.IsSuccessStatusCode; // to return the status code 

        }
    }
}
