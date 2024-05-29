using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        public UserController()
        {
            if (userlist.Count == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    userlist.Add(new User
                    {
                        Id = i,
                        Name = $"User{i}",
                        Email = $"user{i}@example.com",                        
                    });
                }
            }
        }

        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Add the new user to the list
                userlist.Add(user);

                // Return a 201 Created status code
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Created);
            }

            // If model state is not valid, return the user back to the Create view
            return View(user);
        }


        // GET: User/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                return RedirectToAction("Index");
            }

            // If model state is not valid, return the user back to the Edit view
            return View(user);
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(user);
            return RedirectToAction("Index");
        }


        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
