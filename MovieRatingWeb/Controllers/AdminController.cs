using Microsoft.AspNetCore.Mvc;
using MovieRatingWeb.Models;
using MovieRatingWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieRatingWeb.Controllers
{
    public class AdminController : Controller
    {
        private dbcontext s2;

        public AdminController(dbcontext dbcontext)
        {
            s2 = dbcontext;
        }

        public IActionResult ShowMore(int id)
        {
            UserModel user = s2.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }
            s2.Entry(user).Collection(u => u.Comments).Load();

            return View(user);
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> abc = s2.Users;
            return View(abc);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await s2.Users.FindAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            s2.Users.Remove(user);
            await s2.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}