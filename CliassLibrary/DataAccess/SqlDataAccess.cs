using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CliassLibrary.Models;

namespace CliassLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "db_a7366b_getwellEntities3")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static IEnumerable<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql);
            }
        }

        public static IEnumerable<Medecin> LoadDataForMedecinWithId(string sql, DynamicParameters dp)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                
                return cnn.Query<Medecin, nootation, certificat, categorie, Medecin>(sql, (med, nootation, certificat, categorie) => {
                   
                    if(med.certificat == null)
                    {
                        med.certificat = new List<certificat>();
                    }
                    med.categorie = categorie;
                    med.notation = nootation;
                    med.certificat.Add(certificat);
                    return med;
                }, dp, splitOn: "id_doc, note, NomCert, NomCat");
            }
        }

        public static IEnumerable<MedecinWidthId> LoadDataForMedecin(string sql, DynamicParameters dp)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<MedecinWidthId>(sql,dp); 
            }
        }

        public static IEnumerable<categorie> LoadDataForCategory(string sql, DynamicParameters dp)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<categorie>(sql, dp);
            }
        }




        public static void SaveDataWithoutTransiction<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();

                cnn.Execute(sql: sql,param: data, commandType: CommandType.StoredProcedure, commandTimeout: 100);
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();

                var trc = cnn.BeginTransaction();

                int result = cnn.Execute(sql, data, trc, 10, CommandType.StoredProcedure);

                if (result == 1)
                {
                    trc.Commit();
                }
                else
                {
                    trc.Rollback();
                }
                
                return result;
            }
        }

        public static int ReturnsSingleValue(string sql,DynamicParameters cin)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();

                return cnn.ExecuteScalar<int>(sql: sql, param: cin, commandTimeout: 50,commandType: CommandType.Text);
            }
        }

        public static int ReturnsSingleValueWithoutParameter(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();

                return cnn.ExecuteScalar<int>(sql: sql, commandTimeout: 50, commandType: CommandType.Text);
            }
        }
    }
}
