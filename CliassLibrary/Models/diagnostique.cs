using System;
using System.Collections.Generic;

namespace CliassLibrary.Models
{
    public partial class diagnostique
    {
        public int Id_diag { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date_diag { get; set; }
        public Nullable<int> C_Id_patient { get; set; }
        public Nullable<int> C_Id_doc { get; set; }
    }
}
