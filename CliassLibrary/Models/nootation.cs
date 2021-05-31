using System;
using System.Collections.Generic;

namespace CliassLibrary.Models
{
    public partial class nootation
    {
        public int Id_not { get; set; }
        public Nullable<double> Note { get; set; }
        public Nullable<int> C_Id_patient { get; set; }
        public Nullable<int> C_Id_doc { get; set; }
    }
}
