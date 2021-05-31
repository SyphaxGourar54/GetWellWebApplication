using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliassLibrary.Models
{
    public partial class categorie
    {
        public int Id_cat { get; set; }
        public string NomCat { get; set; }
        public string Description { get; set; }
        public Nullable<int> C_Id_doc { get; set; }
    
    }
}
