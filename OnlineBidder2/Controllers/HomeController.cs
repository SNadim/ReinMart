using OnlineBidder2.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineBidder2.Controllers
{
    public class HomeController : Controller
    {
        REINMARTEntities db = new REINMARTEntities();
        
        

        public ActionResult Index(int? page)
        {
            
            // pagination

            var data = (from s in db.products select s);

            var newProduct = data.OrderByDescending(s => s.productId).Take(3);

            ViewBag.newProduct = newProduct.ToList();

            if (page > 0)
                page = page;
            else page = 1;

            int limit = 1;
            int start =(int) (page - 1) * limit;
            int totalProduct = data.Count();
            ViewBag.totalPage = totalProduct;
            ViewBag.pageCurrent = page;
            float numberPage = (float)(totalProduct / limit);
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataProduct = data.OrderByDescending(s => s.productId).Skip(start).Take(limit);
            return View(dataProduct.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View(); 
            
        }

        [HttpGet]
        public ActionResult Login()
        {

            if (Request.Cookies["user"] == null)
            {
                return View();

            }
             else  return RedirectToAction("Index","Home");
            
        }

        [HttpPost]
        public ActionResult Login(user u)
        {
            try
            {
                var usr = db.users.Single(uc => uc.userMail == u.userMail && uc.userPassword == u.userPassword);
                if (usr != null && usr.status == "User")
                {
                    HttpCookie userCookie = new HttpCookie("user", usr.userId.ToString());
                    //userCookie.Expires = DateTime.Now
                    Response.Cookies.Add(userCookie);

                    return RedirectToAction("");
                }
                else if (usr != null && usr.status == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (Exception)
            {
                ModelState.Clear();
                ViewBag.Message = "Login Failed";

                return View();
            }
            return View();



        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            HttpCookie nameCookie = Request.Cookies["user"];
            nameCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(nameCookie);

            return RedirectToAction("Login");
        }
    


        [HttpGet]
        public ActionResult Register()
        {

            if (Request.Cookies["user"] == null)
            {
                return View();

            }
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Register(user u)
        {
            if (ModelState.IsValid)
            {
                if(u.ImageFile.ContentLength<=1000)
                {

                    string filename = Path.GetFileName(u.ImageFile.FileName);
                    string extension = Path.GetExtension(u.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    u.userImage = "~/assets/img/UserImages/" + filename;
                    filename = Path.Combine(Server.MapPath("~/assets/img/UserImages/"), filename);
                    u.ImageFile.SaveAs(filename);
                    return RedirectToAction("Index", "Home");
                }
                
                u.status = "User";
                db.users.Add(u);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Message = u.userName + " successfully registered";
            return View();
        }

        public ActionResult UserProfile(int? id)
        {

            if (Request.Cookies["user"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var loggedUser = db.users.Find(id);
                return View(loggedUser);

            }
            else return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult UserProfile(HttpPostedFileBase file, user u)
        {
            return View();
        }


        public ActionResult SingleProduct(int? id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var product = db.products.Find(id);
                //Session["imgPath"] = product.image;

                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);

            }else return RedirectToAction("Login", "Home");
            
        }

        [HttpPost]
        public ActionResult SingleProduct(product p)
        {
            return View();

        }
    }
}
