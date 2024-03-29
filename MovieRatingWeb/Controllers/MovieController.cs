using MovieRatingWeb.Data;
using MovieRatingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MovieRatingWeb.Controllers
{
    public class MovieController : Controller
    {
        private dbcontext s2;
        private object userService;

        public MovieController(dbcontext dbcontext)
        {
            s2 = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult TvSeries()
        {
            return View();
        }

        public IActionResult Trending()
        {
            return View();
        }

        public IActionResult TopRated()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserModel abc)
        {
            s2.Users.Add(abc);
            s2.SaveChanges();

            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel abc)
        {
            var user = s2.Users.FirstOrDefault(u => u.UserEmail == abc.UserEmail && u.UserPassword == abc.UserPassword);
            if (user != null)
            {
                HttpContext.Session.SetString("UserSession", user.UserEmail);
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.Message = "Login Failed !!!";
            }
            return View(abc);
        }

        //public async Task<IActionResult> ShowMore()
        //{
        //    var comments = await s2.Comments.Include(c => c.User).ToListAsync();

        //    if (HttpContext.Session.GetString("UserSession") != null)
        //    {
        //        ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    return View(comments);
        //}

        // MovieController.cs

        public async Task<IActionResult> ShowMore()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                var comments = await s2.Comments.Include(c => c.User).ToListAsync();
                return View(comments);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public IActionResult ShowMore2()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore3()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore4()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore5()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore6()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore7()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowMore8()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CommentModel comment)
        {
           
             
                    var userEmail = HttpContext.Session.GetString("UserSession");
                    var user = await s2.Users.FirstOrDefaultAsync(u => u.UserEmail == userEmail);

                    if (user != null)
                    {
                        comment.Text = comment.Text;
                        comment.UserId = user.UserId;
                        comment.PostedAt = DateTime.Now;

                        s2.Comments.Add(comment);
                        await s2.SaveChangesAsync();

                        return RedirectToAction("ShowMore");
                    }
                

                var comments = await s2.Comments.Include(c => c.User).ToListAsync();
                return View("ShowMore", comments);
            
        }

    }
}