using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using CicekciBaciDapper.Models;

namespace CicekciBaciDapper.Controllers
{
    public class CicekBilgiController : Controller
    {
        // GET: CicekBilgi
        public ActionResult Index()
        {
            return View(DP.ReturnList<CicekBilgiModel>("CicekListele"));
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@cicekNo", id);
                return View(DP.ReturnList<CicekBilgiModel>("CicekSirala", param).FirstOrDefault<CicekBilgiModel>());

            }
        }

        [HttpPost]
        public ActionResult EY(CicekBilgiModel cicekBilgi)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@cicekNo", cicekBilgi.cicekNo);
            param.Add("@cicekAdi", cicekBilgi.cicekadi);
            param.Add("@renk", cicekBilgi.renk);
            param.Add("@fiyat", cicekBilgi.fiyat);
            param.Add("@adet", cicekBilgi.adet);
            param.Add("@mensei", cicekBilgi.mensei);
            DP.ExReturn("CicekEY", param);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("cicekNo", id);
            DP.ExReturn("CicekSil", param);
            return RedirectToAction("Index");
        }
    }
}