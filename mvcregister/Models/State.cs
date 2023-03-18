using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcregister.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int countryId { get; set; }

        public Country Country { get; set; }
    }
}