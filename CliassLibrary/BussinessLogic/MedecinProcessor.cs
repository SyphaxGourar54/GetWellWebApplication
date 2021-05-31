using System;
using CliassLibrary.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliassLibrary.Models;
using System.Data;
using Dapper;

namespace CliassLibrary.BussinessLogic
{
    public class MedecinProcessor
    {
        public static bool CreateMedecin(string user, string CIN, string name,
            string fname, string image, string tele, string email, string mdp, string city, string adress, string longi,
            string lat, string link, string fb, string whatssap, string insta, string twit, int id_cat)
        {
            bool result = false;
            if (CheckMedecinByCin(CIN) == 0 && CheckMedecinByEmail(email) == 0)
            {
                MedecinOutOfMapping data = new MedecinOutOfMapping
                {
                    username = user,
                    Password = mdp,
                    Nom = name,
                    Prenom = fname,
                    Tel = tele,
                    Image = image,
                    Email = email,
                    Ville = city,
                    Adresse = adress,
                    Facebook = fb,
                    Whatsapp = whatssap,
                    Instagram = insta,
                    Twitter = twit,
                    Linkeden = link,
                    latitude = lat,
                    longitude = longi,
                    cin = CIN,
                    Id_cat = id_cat
                };

                string sql = "AddMedecine";

                SqlDataAccess.SaveData(sql, data);

                result = true;
            }
            return result;
        }
        public static int CheckMedecinByCin(string cin)
        {
            string sql = "Select count(*) from Medecin where cin = @cin";

            var qp = new DynamicParameters();
            qp.Add(name: "@cin", value: cin, dbType: DbType.String, direction: ParameterDirection.Input);

            return SqlDataAccess.ReturnsSingleValue(sql, qp);
        }

        public static int CheckMedecinByEmail(string email)
        {
            string sql = "Select count(*) from Medecin where email = @email";

            var qp = new DynamicParameters();
            qp.Add(name: "@email", value: email, dbType: DbType.String, direction: ParameterDirection.Input);

            return SqlDataAccess.ReturnsSingleValue(sql, qp);
        }

        public static IEnumerable<MedecinWidthId> LoadCity(string search)
        {
            string sql = "select distinct ville from medecin where ville like @ville";

            DynamicParameters dp = new DynamicParameters();
            dp.Add(name: "@ville", value: search + "%", dbType: DbType.String, direction: ParameterDirection.Input);
            
            return SqlDataAccess.LoadDataForMedecin(sql,dp);
        }

        public static IEnumerable<categorie> LoadCategory()
        {
            string sql = "select id_cat,nomcat from categorie";

            return SqlDataAccess.LoadData<categorie>(sql);
        }

        public static IEnumerable<categorie> LoadCategoriesForSearch(string search)
        {
            string sql = "select nomcat from categorie where nomcat like @category";

            DynamicParameters dp = new DynamicParameters();
            dp.Add(name: "@category", value: search + "%", dbType: DbType.String, direction: ParameterDirection.Input);

            return SqlDataAccess.LoadDataForCategory(sql, dp);
        }

        public static IEnumerable<MedecinWidthId> LoadDoctors(string City, string category)
        {
            var qp = new DynamicParameters();

            qp.Add(name: "@ville", value: City, dbType: DbType.String, direction: ParameterDirection.Input);
            qp.Add(name: "@categorie", value: category, dbType: DbType.String,direction: ParameterDirection.Input);

            string sql = "select id_doc,username,adresse,image,latitude,longitude from medecin inner join categorie on medecin.#id_cat = categorie.id_cat where medecin.ville = @ville and categorie.nomcat = @categorie";

            return SqlDataAccess.LoadDataForMedecin(sql,qp);
        }

        public static IEnumerable<Medecin> LoadDoctorsById(int id)
        {
            var qp = new DynamicParameters();

            qp.Add(name: "@id_doc", value: id, dbType: DbType.String, direction: ParameterDirection.Input);

            string sql = "select id_doc,medecin.nom,prenom,username,tel,email,adresse,image,latitude,longitude,nootation.note,certificat.nomcert, certificat.institut,certificat.annén,categorie.nomcat from medecin inner join categorie on medecin.#id_cat = categorie.id_cat left join nootation on medecin.id_doc = nootation.#id_doc inner join certificat on medecin.id_doc = certificat.#id_doc where medecin.id_doc = @id_doc";

            return SqlDataAccess.LoadDataForMedecinWithId(sql, qp);
        }

        public static int GetLastMedecin()
        {
            string sql = "select max(id_doc) from medecin";

            return SqlDataAccess.ReturnsSingleValueWithoutParameter(sql);
        }



        public static IEnumerable<MedecinWidthId> LoadAllDoctors()
        {
            string sql = "select id_doc,nom, prenom,adresse,image,latitude,longitude from medecin";


            return SqlDataAccess.LoadData<MedecinWidthId>(sql);
        }

        public static int AddCertificate(string CertificateName, string Year, string institut)
        {
            certificat data = new certificat
            {
                NomCert = CertificateName,
                institut = institut,
                annén = Year,
                Id_doc = GetLastMedecin()
            };

            string sql = "AddCertificate";

            return SqlDataAccess.SaveData<certificat>(sql, data);
        }

        public static int AddAppointment(string date, TimeSpan temprv, int id_patint, int id_doc)
        {
            DateTime dateprise = DateTime.Today;

            rendezvous data = new rendezvous
            {
                Date = Convert.ToDateTime(date),
                dateprise = dateprise,
                temp_rdv = temprv,
                Id_patient = id_patint,
                Id_doc = id_doc
            };

            string sql = "addappointment";

            return SqlDataAccess.SaveData<rendezvous>(sql, data);
        }
    }
}
