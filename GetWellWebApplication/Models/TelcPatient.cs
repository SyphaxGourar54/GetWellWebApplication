using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GetWellWebApplication.Models;

namespace GetWellWebApplication.Models
{
    public class TelcPatient
    {
        public patient patient { get; set; }
        public teleconsultation teleconsultation { get; set; }
    }
}