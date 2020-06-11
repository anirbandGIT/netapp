using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class statewise
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
    }
    public class covidData{
      public List<statewise> statewise;
    }
}
