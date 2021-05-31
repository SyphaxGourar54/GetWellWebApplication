using CliassLibrary.Models;
using System;
using System.Collections.Generic;

namespace CliassLibrary.Models
{
    public partial class teleconsultation
    {
        public int Id_telecon { get; set; }
        public string Description { get; set; }
        public System.DateTime Date_telecon { get; set; }
        public int C_Id_patient { get; set; }
        public int C_Id_doc { get; set; }
    }
}
