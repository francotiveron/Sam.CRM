using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.Web.FrontEnd.Blazor.Models
{
    public interface IDataItem
    {
        string Id { get; }
        string Name { get; }
    }

    public class DataItem : IDataItem
    {
        public DataItem(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public DataItem(string name) : this(Guid.NewGuid().ToString(), name) { }
        public DataItem() : this("Unnamed") { }

        public string Id { get; private set; }

        public string Name { get; private set; }
    }
}
