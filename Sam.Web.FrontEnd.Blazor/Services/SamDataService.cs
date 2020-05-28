using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sam.Web.FrontEnd.Blazor.Models;

namespace Sam.Web.FrontEnd.Blazor.Services
{
    public interface ISamDataService
    {
        IEnumerable<Country> Countries { get; }
    }
    public class SamDataService : ISamDataService
    {
        public static Country[] _Countries = new Country[] { new Country("USA"), new Country("Australia") };

        IEnumerable<Country> ISamDataService.Countries => _Countries;
    }

}
