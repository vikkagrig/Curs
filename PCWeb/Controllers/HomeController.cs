using Microsoft.AspNetCore.Mvc;
using PCWeb.Models;
using System.Diagnostics;
using System.Web;
using Microsoft.EntityFrameworkCore;
using PCWeb.Models;
using PCWeb.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PCWeb.Controllers
{
    public class HomeController : Controller
    {
        User usfrEntrant;
        Entrant entrant;
        List<Faculty> faculties;
        List<Spaciality> spacialities;
        ApplicationContext db;
        bool flag = false;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            ViewBag.Entrant = this.entrant;
            ViewBag.List = db.Lists;
            ViewBag.Fac = db.Faculties;
            ViewBag.Spaciality = db.Spacialities;
            return View();
        }
        public IActionResult reg()
        {
            return View();
        }
        public IActionResult ListCreate()
        {
            ViewBag.Entrant = entrant;
            ViewBag.List = db.Lists;
            ViewBag.Entrants = db.Entrants;
            ViewBag.Fac = db.Faculties;
            ViewBag.Spaciality = db.Spacialities;
            return View();
        }
        public IActionResult List()
        {
            ViewBag.Entrant = entrant;
            ViewBag.List = db.Lists;
            ViewBag.Entrants = db.Entrants;
            ViewBag.Fac = db.Faculties;
            ViewBag.Spaciality = db.Spacialities;
            return View();
        }
        [HttpPost]
        public IActionResult ListSpec(string @sel)
        {
            List<Spaciality> spacialities = null;
            foreach(var s in db.Spacialities)
            {
                if(s.IDFac == int.Parse(sel))
                {
                    spacialities.Add(s);
                }
            }
            ViewBag.Sp = spacialities;
            ViewBag.Fac = db.Faculties;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> reg(IFormFile photo, string @password, string @repeat_password, string @login, string @lastname, string @firstname, 
            string @fathername, DateTime @datebirthday, string @personalydata, int @point)
        {
            try
            {
                if (login != null && password != null && repeat_password != null && lastname != null && firstname != null && fathername != null && 
                    photo != null && personalydata != null && password.Trim() != "" && login.Trim() != "" && lastname.Trim() != "" && firstname.Trim() != "" && fathername.Trim() != "" &&
                    personalydata.Trim() != "" && point > 0 && point < 500)
                {
                    if (password.Trim() != repeat_password.Trim())
                    {
                        await Response.WriteAsync("<script>alert('Invalid password')</script>");
                        return View("reg");
                    }
                    else
                    {
                        byte[] bytes = null;
                        if (photo != null)
                        {
                            try
                            {
                                bytes = new byte[photo.Length];
                                User user = new User()
                                {
                                    Login = login.Trim(),
                                    Password = password.Trim(),
                                    Role = "Абитуриент"
                                };
                                db.Users.Add(user);
                                await db.SaveChangesAsync();
                                Entrant entrant = new Entrant()
                                {
                                    IDUser = user.IDUser,
                                    FirstName = firstname.Trim(),
                                    LastName = lastname.Trim(),
                                    FatherName = fathername.Trim(),
                                    DateBirthday = datebirthday,
                                    PersonalyData = personalydata.Trim(),
                                    Point = point,
                                    Photo = bytes
                                };
                                db.Entrants.Add(entrant);
                                await db.SaveChangesAsync();
                                return View("Index");
                                await Response.WriteAsync("<script>alert('Successfully')</script>");
                            }
                            catch
                            {

                                await Response.WriteAsync("<script>alert('Incorrect data')</script>");
                                return View("reg");
                            }
                        }
                        else
                        {
                            await Response.WriteAsync("<script>alert('Photo upload error')</script>");
                            return View("reg");
                        }
                    }
                }
                else
                {
                    return View("reg");
                    Response.WriteAsync("<script>alert('Incorrect data')</script>");
                }
            }
            catch
            {
                return View("reg");
                Response.WriteAsync("<script>alert('Incorrect data')</script>");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Enter(string @login, string @password)
        {
            try
            {
                usfrEntrant = null;
                entrant = null;
                User us = null;
                if (login != null && password != null && login.Trim() != "" && @password.Trim() != "")
                {
                    foreach (User user in db.Users)
                    {
                        if (user.Login == login.Trim() && user.Password == password.Trim() && user.Role == "Абитуриент")
                        {
                            usfrEntrant = db.Users.Find(user.IDUser);
                            us = db.Users.Find(user.IDUser);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        foreach (Entrant en in db.Entrants)
                        {
                            if (en.IDUser == us.IDUser)
                            {
                                this.entrant = db.Entrants.Find(en.IDEntrant);
                                break;
                            }
                        }
                        ViewBag.Entrant = entrant;
                        string imreBase64Data = Convert.ToBase64String(entrant.Photo);
                        string img = String.Format("data:image/png;base64,{0}", imreBase64Data);
                        ViewBag.Ph = img;
                        ViewBag.List = db.Lists;
                        ViewBag.Fac = db.Faculties;
                        ViewBag.Spaciality = db.Spacialities;
                        Entrant e = db.Entrants.FirstOrDefault(g => g.IDEntrant == entrant.IDEntrant);
                        if (e != null)
                        {
                            string imageBase64 = Convert.ToBase64String(e.Photo);
                            string imageUrl = string.Format("data:image/jpg;base64,{0}", imageBase64);
                            var imageTag = new TagBuilder("img");
                            imageTag.MergeAttribute("src", imageUrl);
                            ViewBag.ImageTag = imageTag;
                            ViewBag.URL = imageUrl;
                        }
                        return View("Profile");
                        await Response.WriteAsync("<script>alert('Successfully')</script>");
                    }
                    else
                    {
                        return View("Index");
                        await Response.WriteAsync("<script>alert('User not found')</script>");
                    }
                }
                else
                {
                    return View("Index");
                    await Response.WriteAsync("<script>alert('Incorrect data')</script>");
                }
            }
            catch
            {
                return View("Index");
                await Response.WriteAsync("<script>alert('Incorrect data')</script>");
            }
        }
    }
}