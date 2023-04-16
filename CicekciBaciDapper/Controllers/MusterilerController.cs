using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using CicekciBaciDapper.Models;

namespace CicekciBaciDapper.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        public ActionResult Index()
        {
            return View(DP.ReturnList<MusterilerModel>("MusteriListele"));
        }

        public ActionResult EY(int id =0)
        {
            if (id ==0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MusteriNo", id);
                return View(DP.ReturnList<MusterilerModel>("MusterilerSirala", param).FirstOrDefault<MusterilerModel>());
            }
        }

        [HttpPost]
        public ActionResult EY(MusterilerModel musteri)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MusteriNo", musteri.MusteriNo);
            param.Add("@MusteriAdi", musteri.MusteriAdi);
            param.Add("@telefon", musteri.telefon);
            param.Add("@email", musteri.email);
            DP.ExReturn("MusteriEY",param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MusteriNo", id);
            DP.ExReturn("MusteriSil", param);
            return RedirectToAction("Index");
        }
    }
}