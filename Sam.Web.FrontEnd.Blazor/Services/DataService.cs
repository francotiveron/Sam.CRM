using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sam.Web.FrontEnd.Blazor.

namespace Sam.Web.FrontEnd.Blazor.Services
{
    public class SamDataService : ISamDataService
    {
        public static IEnumerable<Country> Countries = new Country[] { new Country("USA"), new Country("Australia") };
    }

    public interface ISamDataService
    {

    }
}
