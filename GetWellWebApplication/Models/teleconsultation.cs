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
    
    public partial class teleconsultation
    {
        public int Id_telecon { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date_telecon { get; set; }
        public Nullable<int> C_Id_patient { get; set; }
        public Nullable<int> C_Id_doc { get; set; }
    
        public virtual medecin medecin { get; set; }
        public virtual patient patient { get; set; }
    }
}
