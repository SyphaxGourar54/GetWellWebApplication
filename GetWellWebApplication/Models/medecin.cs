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
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class medecin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medecin()
        {
            this.categorie = new HashSet<categorie>();
            this.certificat = new HashSet<certificat>();
            this.diagnostique = new HashSet<diagnostique>();
            this.nootation = new HashSet<nootation>();
            this.rendezvous = new HashSet<rendezvous>();
            this.teleconsultation = new HashSet<teleconsultation>();
        }

        public int Id_doc { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Tel { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string ville { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Adresse { get; set; }
        public string Facebook { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Linkeden { get; set; }
        public string password { get; set; }
        [Compare("password", ErrorMessage = "La confirmation de votre mot de passe est invalide")]
        public string Confirmpassword { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression("^([a-zA-Z]{2})([0-9]{5})$|^([a-zA-Z]{1})([0-9]{6})$", ErrorMessage = "le format de CIN est incorrecte")]
        public string cin { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public HttpPostedFileBase ImageFile { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<categorie> categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<certificat> certificat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diagnostique> diagnostique { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nootation> nootation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvous> rendezvous { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teleconsultation> teleconsultation { get; set; }
    }
}