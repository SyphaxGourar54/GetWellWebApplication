//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetWellWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class categorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categorie()
        {
            this.rendezvous = new HashSet<rendezvous>();
        }
    
        public int Id_cat { get; set; }
        public string NomCat { get; set; }
        public string Description { get; set; }
        public Nullable<int> C_Id_doc { get; set; }
    
        public virtual medecin medecin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvous> rendezvous { get; set; }
    }
}
