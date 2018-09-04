using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class Table02Model
    {

        public string Id { get; set; }
        public string ToyName { get; set; }
        public virtual IEnumerable<Table01Model> Table01List { get; set; }
    }
}