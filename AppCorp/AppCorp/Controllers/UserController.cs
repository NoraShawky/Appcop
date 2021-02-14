using AppCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace AppCorp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModal = new User();
            return View(userModal);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModal)
        {
            try
            {
                using (AppcorpEntities1 dbModal = new AppcorpEntities1())
                {
                    if (dbModal.Users.Any(item => item.UserName == userModal.UserName))
                    {
                        ViewBag.DuplicateMessage = "username already existed .";
                        return View(userModal);
                    }
                    dbModal.Users.Add(userModal);
                    dbModal.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registration SuccessFully";
                return RedirectToAction("sendMessage", "mobileNumbar");
            }catch(Exception ex)
            {
                return View(userModal);
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            User userModal = new User();
            return View(userModal);
        }
        [HttpPost]
        public ActionResult Login(User userModal)
        {
            try
            {
                User user =null;
                using (AppcorpEntities1 dbModal = new AppcorpEntities1())
                {
                   user=  dbModal.Users.Where(item => item.Password == userModal.Password && item.UserName == userModal.UserName).FirstOrDefault();
                }
                ModelState.Clear();
                if (user==null)
                {
                    ViewBag.SuccessMessage = "Login Failed";
                    return View(userModal);
                }
                else
                {
                    return RedirectToAction("sendMessage", "mobileNumbar");
                }
            }
            catch (Exception ex)
            {
                return View(userModal);
            }
        }
    }
}