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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_a7366b_getwellEntities1 : DbContext
    {
        public db_a7366b_getwellEntities1()
            : base("name=db_a7366b_getwellEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorie> categorie { get; set; }
        public virtual DbSet<certificat> certificat { get; set; }
        public virtual DbSet<diagnostique> diagnostique { get; set; }
        public virtual DbSet<medecin> medecin { get; set; }
        public virtual DbSet<nootation> nootation { get; set; }
        public virtual DbSet<patient> patient { get; set; }
        public virtual DbSet<rendezvous> rendezvous { get; set; }
        public virtual DbSet<teleconsultation> teleconsultation { get; set; }
    }
}
