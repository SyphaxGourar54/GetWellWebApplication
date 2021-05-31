using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliassLibrary.Models
{
    public partial class certificat
    {
        public string NomCert { get; set; }
        public string institut { get; set; }
        public string annén { get; set; }
        public Nullable<int> Id_doc { get; set; }
    }
}
