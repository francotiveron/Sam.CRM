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

        IEnumerable<Location> Locations { get; }

        IEnumerable<Industry> Industries { get; }

        IEnumerable<Bmodel> Bmodels { get; }

        IEnumerable<Yrsestd> Yrsestds { get; }

        IEnumerable<Minvl> Minvls { get; }

        IEnumerable<Maxvl> Maxvls { get; }

        IEnumerable<Fncyear> Fncyears { get; }

        IEnumerable<Stkprice> Stkprices { get; }

        IEnumerable<Crdrtn> Crdrtns { get; }

        IEnumerable<Erp> Erps { get; }

        IEnumerable<Crm> Crms { get; }

        IEnumerable<Fncltool> Fncltools { get; }

        IEnumerable<Dstwh> Dstwhs { get; }

        IEnumerable<Hlpdsk> Hlpdsks { get; }

        IEnumerable<Dbase> Dbases { get; }
    }
    public class SamDataService : ISamDataService
    {
        public static Country[] _Countries = new Country[] { new Country("USA"), new Country("Australia"), new Country("India"), new Country("France")};

        public static Location[] _Locations = new Location[] { new Location("New York"), new Location("Sydney"), new Location("Delhi"), new Location("Paris")};

        public static Industry[] _Industries = new Industry[] { new Industry("Banking & Finance"), new Industry("Retail"), new Industry("Ecommerce"), new Industry("Technology") };

        public static Bmodel[] _Bmodels = new Bmodel[] { new Bmodel("Service Based"), new Bmodel("Onsite"), new Bmodel("Offshore"), new Bmodel("On & Off") };

        public static Yrsestd[] _Yrsestds = new Yrsestd[] { new Yrsestd("2012"), new Yrsestd("2013"), new Yrsestd("2018"), new Yrsestd("2020") };

        public static Minvl[] _Minvls = new Minvl[] { new Minvl("1"), new Minvl("10"), new Minvl("100"), new Minvl("1000") };

        public static Maxvl[] _Maxvls = new Maxvl[] { new Maxvl("10"), new Maxvl("100"), new Maxvl("1000"), new Maxvl("10000") };

        public static Fncyear[] _Fncyears = new Fncyear[] { new Fncyear("2000"), new Fncyear("2010"), new Fncyear("2015"), new Fncyear("2019") };

        public static Stkprice[] _Stkprices = new Stkprice[] { new Stkprice("$10.00"), new Stkprice("$15.00"), new Stkprice("$100.00"), new Stkprice("$200.00") };

        public static Crdrtn[] _Crdrtns = new Crdrtn[] { new Crdrtn("AAA"), new Crdrtn("BBB-"), new Crdrtn("BB+"), new Crdrtn("C") };

        public static Erp[] _Erps = new Erp[] { new Erp("SAP"), new Erp("Microsoft Dynamics"), new Erp("Oracle"), new Erp("Tally") };

        public static Crm[] _Crms = new Crm[] { new Crm("HubSpot"), new Crm("Salesforce"), new Crm("NetSuite"), new Crm("Pipedrive") };

        public static Fncltool[] _Fncltools = new Fncltool[] { new Fncltool("Xero"), new Fncltool("MYOB"), new Fncltool("Sage 50"), new Fncltool("Wave") };

        public static Dstwh[] _Dstwhs = new Dstwh[] { new Dstwh("DBase"), new Dstwh("Oracle"), new Dstwh("IBM"), new Dstwh("Sybase") };

        public static Hlpdsk[] _Hlpdsks = new Hlpdsk[] { new Hlpdsk("Zendesk"), new Hlpdsk("LiveAgent"), new Hlpdsk("Groove"), new Hlpdsk("Kayako"), new Hlpdsk("Intercom") };

        public static Dbase[] _Dbases = new Dbase[] { new Dbase("DBase"), new Dbase("Oracle"), new Dbase("IBM"), new Dbase("Sybase") };


        IEnumerable<Country> ISamDataService.Countries => _Countries;

        IEnumerable<Location> ISamDataService.Locations => _Locations;

        IEnumerable<Industry> ISamDataService.Industries => _Industries;

        IEnumerable<Bmodel> ISamDataService.Bmodels => _Bmodels;

        IEnumerable<Yrsestd> ISamDataService.Yrsestds => _Yrsestds;

        IEnumerable<Minvl> ISamDataService.Minvls => _Minvls;

        IEnumerable<Maxvl> ISamDataService.Maxvls => _Maxvls;

        IEnumerable<Fncyear> ISamDataService.Fncyears => _Fncyears;

        IEnumerable<Stkprice> ISamDataService.Stkprices => _Stkprices;

        IEnumerable<Crdrtn> ISamDataService.Crdrtns => _Crdrtns;

        IEnumerable<Erp> ISamDataService.Erps => _Erps;

        IEnumerable<Crm> ISamDataService.Crms => _Crms;

        IEnumerable<Fncltool> ISamDataService.Fncltools => _Fncltools;

        IEnumerable<Dstwh> ISamDataService.Dstwhs => _Dstwhs;

        IEnumerable<Hlpdsk> ISamDataService.Hlpdsks => _Hlpdsks;

        IEnumerable<Dbase> ISamDataService.Dbases => _Dbases;
    }

}
