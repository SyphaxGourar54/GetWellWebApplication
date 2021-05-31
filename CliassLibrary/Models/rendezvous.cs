using System;
using System.Collections.Generic;

namespace CliassLibrary.Models
{
    public class rendezvous
    {
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> dateprise { get; set; }
        public Nullable<System.TimeSpan> temp_rdv { get; set; }
        public Nullable<int> Id_patient { get; set; }
        public Nullable<int> Id_doc { get; set; }
    }
}
