using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using CicekciBaciDapper.Models;

namespace CicekciBaciDapper.Controllers
{
    public class TedarikciController : Controller
    {
        // GET: Tedarikci
        public ActionResult Index()
        {
            return View(DP.ReturnList<TedarikcilerModel>("TedarikciListele"));
        }

        public ActionResult EY(int id=0)
        {
            if (id==0)
            {
                return View();

            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TedarikciNo", id);
                return View(DP.ReturnList<TedarikcilerModel>("TedarikciSirala", param).FirstOrDefault<TedarikcilerModel>());
            }
        }

        [HttpPost]
        public ActionResult EY(TedarikcilerModel tedarikci)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@TedarikciNo", tedarikci.TedarikciNo);
            param.Add("@TedarikciAdi", tedarikci.TedarikciAdi);
            param.Add("@Ulke", tedarikci.Ulke);
            param.Add("@Sehir", tedarikci.Sehir);
            DP.ExReturn("TedarikciEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id =0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@TedariikciNo", id);
            DP.ExReturn("TedarikciSil", param);
            return RedirectToAction("Index");   
        }
    }
}