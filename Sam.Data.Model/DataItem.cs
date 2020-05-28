using System;

namespace Sam.Data.Model
{
    public interface IDataItem
    {
        string Id { get; set;  }
        string Name { get; set;  }
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

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
