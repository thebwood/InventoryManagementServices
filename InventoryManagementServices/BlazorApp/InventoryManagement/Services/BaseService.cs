﻿using InventoryManagement.Models.Movies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class BaseService
    {
        public async Task<T> GetAPIResult<T>(string baseURL, string apiCall)
        {

            using (var httpClient = new HttpClient())
            {


                httpClient.BaseAddress = new Uri(baseURL);

                var response = await httpClient.GetAsync(apiCall);

                //response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<T> PostAPIResult<T, U>(string baseURL, string apiCall, U model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(apiCall, model);

                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
        }

    }
}
