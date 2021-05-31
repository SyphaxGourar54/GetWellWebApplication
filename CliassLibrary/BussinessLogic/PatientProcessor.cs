using CliassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliassLibrary.Models;
using System.Data;
using Dapper;

namespace CliassLibrary.BussinessLogic
{
    public class PatientProcessor
    {
        
        public static bool CreatePatient(string cin, string firstName,
            string lastName, DateTime date_naissance, string tel, string emailAddress)
        {
            bool result = false;
            if(CheckPatient(cin) == 0)
            {
                patient data = new patient
                {
                    CIN = cin,
                    Nom = lastName,
                    Prenom = firstName,
                    Date_naissance = date_naissance,
                    Tel = tel,
                    Email = emailAddress
                };

                string sql = "AddPatient";

                SqlDataAccess.SaveData(sql, data);

                result = true;
            }
            return result;
        }

        public static void CreateTelPatient(string cin, string firstName,
    string lastName, DateTime date_naissance, string tel, string emailAddress,
    string descroption)
        {
             Telcpatient telc = new Telcpatient();
             telc.patient.CIN = cin;
             telc.patient.Nom = lastName;
             telc.patient.Prenom = firstName;
             telc.patient.Date_naissance = date_naissance;
             telc.patient.Tel = tel;
             telc.patient.Email = emailAddress;
             telc.teleconsultation.Description = descroption;
             telc.teleconsultation.Date_telecon = DateTime.Now;

             DynamicParameters dp = new DynamicParameters();

             dp.Add(name: "@CIN", value: telc.patient.CIN, dbType: DbType.String);
             dp.Add(name: "@Nom", value: telc.patient.Nom, dbType: DbType.String);
             dp.Add(name: "@Prenom", value: telc.patient.Prenom, dbType: DbType.String);
             dp.Add(name: "@Date_naissance", value: telc.patient.Date_naissance, dbType: DbType.DateTime);
             dp.Add(name: "@Tel", value: telc.patient.Tel, dbType: DbType.String);
             dp.Add(name: "@Email", value: telc.patient.Email, dbType: DbType.String);
             dp.Add(name: "@Description", value: telc.teleconsultation.Description, dbType: DbType.String);
             dp.Add(name: "@Date_con", value: telc.teleconsultation.Date_telecon, dbType: DbType.DateTime);

             string sql = "AddPatientTelec";

             SqlDataAccess.SaveDataWithoutTransiction(sql, dp);
        }

        public static int CheckPatient(string cin)
        {
            string sql = "Select count(*) from patient where cin = @cin";

            var qp = new DynamicParameters();
            qp.Add(name: "@CIN", value: cin, dbType: DbType.String, direction: ParameterDirection.Input);

            return SqlDataAccess.ReturnsSingleValue(sql, qp);
        }

        public static int GetLastPatient()
        {
            string sql = "Select Max(id_patient) from patient";

            return SqlDataAccess.ReturnsSingleValueWithoutParameter(sql);
        }

        public static int GetPatientId(string cin)
        {
            var qp = new DynamicParameters();
            qp.Add(name: "@CIN", value: cin, dbType: DbType.String, direction: ParameterDirection.Input);

            string sql = "Select id_patient from patient where cin = @cin";

            return SqlDataAccess.ReturnsSingleValue(sql,qp);
        }

        //public static int AddAppointement()
        //{

        //}

    }
}
