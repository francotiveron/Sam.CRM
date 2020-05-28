using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sam.Data.Model;

namespace Sam.Web.FrontEnd.Blazor.Services
{
    public interface ISamDataService
    {
        Task<IEnumerable<Country>> GetCountries();
    }
    public class SamDataServiceLocal : ISamDataService
    {
        public static Country[] _Countries = new Country[] { new Country("USA"), new Country("Australia") };

        async Task<IEnumerable<Country>> ISamDataService.GetCountries() => await Task.Run(() => _Countries);
    }

    public class SamDataServiceRemote : ISamDataService
    {
        static readonly string baseDevUrl = @"https://localhost:44396/api";
        static readonly string baseProdUrl = @"https://sam-mvp-api.azurewebsites.net/api";
        readonly string baseUrl;
        static readonly string countryUrl = @"Country";
        HttpClient hc;
        
        public SamDataServiceRemote(HttpClient httpClient, IWebAssemblyHostEnvironment env) { 
            hc = httpClient;
            if (env.IsProduction()) baseUrl = baseProdUrl;
            else baseUrl = baseDevUrl;
        }

        async Task<IEnumerable<Country>> ISamDataService.GetCountries() => await hc.GetFromJsonAsync<IEnumerable<Country>>(@$"{baseUrl}/{countryUrl}");
    }
}
