using AppCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCorp.Controllers
{
    public class mobileNumbarController : Controller
    {
        // GET: mobileNumbar
        [HttpGet]
        public ActionResult sendMessage()
        {

            List<mobileNumbar> data = new List<mobileNumbar>();
            using (AppcorpEntities1 dbModal = new AppcorpEntities1())
            {
               if(dbModal.mobileNumbars.Any(item => item.isSend != true)){
                    data= dbModal.mobileNumbars.Where(item => item.isSend != true).Take(10).ToList();
                }
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult sendMessage(mobileNumbar[] modal)
        {
            List<mobileNumbar> data = new List<mobileNumbar>();
            using (AppcorpEntities1 dbModal = new AppcorpEntities1())
            {
                foreach(mobileNumbar mobilModal in modal)
                {
                  var mobileNumbar= dbModal.mobileNumbars.FirstOrDefault(x => x.id == mobilModal.id);
                    if (mobileNumbar !=null)
                    {
                        mobileNumbar.isSend = true;
                        dbModal.SaveChanges();
                    }
                }

                if (dbModal.mobileNumbars.Any(item => item.isSend != true))
                {
                    data = dbModal.mobileNumbars.Where(item => item.isSend != true).Take(10).ToList();
                }
            }
            return RedirectToAction("sendMessage",data);
        }
    }
}