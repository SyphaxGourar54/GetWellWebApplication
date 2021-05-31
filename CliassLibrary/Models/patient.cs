using System;
using System.Collections.Generic;

namespace CliassLibrary.Models
{
    public partial class patient
    {
        public string CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Nullable<System.DateTime> Date_naissance { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
