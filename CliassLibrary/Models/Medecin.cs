using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CliassLibrary.Models
{
    public class Medecin
    {
        public string username { get; set; }
        public string cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Image { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string Linkeden { get; set; }
        public string Facebook { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public int Id_cat { get; set; }
        public categorie categorie { get; set; }
        public nootation notation { get; set; }
        public List<certificat> certificat { get; set; }
    }
}
