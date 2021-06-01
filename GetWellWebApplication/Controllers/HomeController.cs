using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetWellWebApplication.Models;
using CliassLibrary;
using static CliassLibrary.BussinessLogic.PatientProcessor;
using static CliassLibrary.BussinessLogic.MedecinProcessor;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Mail;

namespace GetWellWebApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public static List<medecin> Medecin = new List<medecin>();
        public ActionResult Accueil()
        {
            return View();
        }

        public ActionResult GetCities(string ville)
        {
            var city = LoadCity(ville);
            List<medecin> med = new List<medecin>();

            foreach (var row in city)
            {
                med.Add(new medecin
                {
                    ville = row.Ville
                });
            }

            return Json(med, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetCategories(string category)
        {
            var categories = LoadCategoriesForSearch(category);
            List<categorie> categoriesList = new List<categorie>();

            foreach (var row in categories)
            {
                categoriesList.Add(new categorie
                {
                    NomCat = row.NomCat
                });
            }

            return Json(categoriesList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendDoctorsIdentifications(DropDownValues dropDownValues)
        {
            var LodedDoctors = LoadDoctors(dropDownValues.Ville, dropDownValues.Categorie);

            List<medecin> med = new List<medecin>();

            foreach (var row in LodedDoctors)
            {
                med.Add(new medecin
                {
                    Id_doc = row.Id_doc,
                    Username = row.username,
                    Adresse = row.Adresse,
                    Image = row.Image,
                    longitude = row.longitude,
                    latitude = row.latitude
                });
            }

            Medecin = med;

            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult GetDoctors()
        {
            return Json(Medecin, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllDoctors()
        {
            return Json(LoadAllDoctors(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult index(int id)
        {
            TempData["ID"] = id;

            return View();
        }

        public ActionResult GetDoctorById()
        {
            int id = Convert.ToInt32(TempData["ID"]);
            TempData.Keep("ID");

            var med = LoadDoctorsById(id);

            return Json(med, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAllLocation()
        //{
        //    var data = context.medecin.ToList().First();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetAllLocationById(int id)
        //{
        //    var data = context.medecin.Where(x => x.Id_doc == id).SingleOrDefault();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult TeleConsultation()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult TeleConsultation(TelcPatient telc)
        {
            if (ModelState.IsValid)
            {
                CreateTelPatient(telc.patient.CIN,
                     telc.patient.Nom,
                     telc.patient.Prenom,
                     Convert.ToDateTime(telc.patient.Date_naissance),
                     telc.patient.Tel,
                     telc.patient.Email,
                     telc.teleconsultation.Description);
            }
            ViewBag.Data = "Exists";
            return View();
        }

        [HttpGet]
        public ActionResult PrendreRendezvous()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PrendreRendezvous(patient patient)
        {
            bool result;
            if (ModelState.IsValid)
            {
                result = CreatePatient(patient.CIN,
                     patient.Nom,
                     patient.Prenom,
                     Convert.ToDateTime(patient.Date_naissance),
                     patient.Tel,
                     patient.Email);
                if (result)
                {
                    TempData["Id_pat"] = GetLastPatient() + 1;
                    ViewBag.Data = null;
                    return RedirectToAction("JourRendezvous");
                }
                else
                {
                    TempData["Id_pat"] = GetPatientId(patient.CIN);
                    ViewBag.Data = "Exists";
                    return View();
                }
            }
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult JourRendezvous()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JourRendezvous(string JourRendervous)
        {
            TempData["JourRendezvous"] = JourRendervous;
            return RedirectToAction("HeurRendezVous");
        }

        public ActionResult HeurRendezVous()
        {
            ViewBag.Day = TempData["JourRendezvous"];
            TempData.Keep("JourRendezvous");
            return View();
        }

        [HttpPost]
        public ActionResult HeurRendezVous(string heure)
        {
            TimeSpan Hour = Convert.ToDateTime(heure).TimeOfDay;

            int result = AddAppointment(Convert.ToString(TempData["JourRendezvous"]),Hour,Convert.ToInt32(TempData["Id_pat"]), Convert.ToInt32(TempData["ID"]));

            return ActionResult("Accueil");
        }

        [HttpGet]
        public ActionResult information_medecin()
        {
            var category = LoadCategory();
            List<categorie> cat = new List<categorie>();

            foreach (var row in category)
            {
                cat.Add(new categorie
                {
                    Id_cat = row.Id_cat,
                    NomCat = row.NomCat
                });
            }

            SelectList Categorylist = new SelectList(cat, "Id_cat", "NomCat");
            ViewBag.categories = Categorylist;

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult information_medecin(medecin medecin, int CategoryList)
        {
            string filename = Path.GetFileNameWithoutExtension(medecin.ImageFile.FileName);
            string extension = Path.GetExtension(medecin.ImageFile.FileName);
            bool result;
            if (ModelState.IsValid)
            {
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                medecin.Image = "Images/Doctors images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Doctors images/"), filename);
                medecin.ImageFile.SaveAs(filename);
                result = CreateMedecin(medecin.Username,
                    medecin.cin,
                    medecin.Nom,
                    medecin.Prenom,
                    medecin.Image,
                    medecin.Tel,
                    medecin.Email,
                    medecin.password,
                    medecin.ville,
                    medecin.Adresse,
                    medecin.longitude,
                    medecin.latitude,
                    medecin.Linkeden,
                    medecin.Facebook,
                    medecin.Whatsapp,
                    medecin.Instagram,
                    medecin.Twitter,
                    CategoryList);
                if (result)
                {
                    var category = LoadCategory();
                    List<categorie> cat = new List<categorie>();

                    foreach (var row in category)
                    {
                        cat.Add(new categorie
                        {
                            Id_cat = row.Id_cat,
                            NomCat = row.NomCat
                        });
                    }

                    SelectList Categorylist = new SelectList(cat, "Id_cat", "NomCat");
                    ViewBag.categories = Categorylist;

                    ViewBag.Data = "Doesn't exist";
                    return RedirectToAction("Certificats_medecin");
                }
                else
                {
                    var category = LoadCategory();
                    List<categorie> cat = new List<categorie>();

                    foreach (var row in category)
                    {
                        cat.Add(new categorie
                        {
                            Id_cat = row.Id_cat,
                            NomCat = row.NomCat
                        });
                    }

                    SelectList Categorylist = new SelectList(cat, "Id_cat", "NomCat");
                    ViewBag.categories = Categorylist;

                    ViewBag.Data = "Exists";
                    return View();
                }
            }
            return new EmptyResult();
        }

        public ActionResult AlreadyExistMessageForMedecin()
        {
            return View();
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }

        public ActionResult AlreadyExistMessageForMedecinPost()
        {
            return RedirectToAction("information_medecin");
        }

        public ActionResult Certificats_medecin()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Certificats_medecin(certificat certificat)
        {
            if (ModelState.IsValid)
            {
                int result = AddCertificate(certificat.NomCert, certificat.annén, certificat.institut);
                if (result != 0)
                {
                    ViewBag.result = "done";
                    return View();
                }
            }
            

            return new EmptyResult();

        }

        public ActionResult SuccessMessageForCertificate()
        {
            return View();
        }

        public ActionResult SuccessMessageForCertificatePost()
        {
            return RedirectToAction("Accueil");
        }

        [HttpPost]
        public ActionResult SuccessMessagePost()
        {
            return RedirectToAction("Certificats_medecin");
        }

        [HttpGet]
        public ActionResult AlreadyExistMessage()
        {
            return PartialView();
        }

        public ActionResult AlreadyExistMessageForTeleconsultation()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AlreadyExistMessagePost()
        {
            return RedirectToAction("JourRendezvous");
        }
    }
}