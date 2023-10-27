using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Models;

namespace Troubleshooting.Controllers
{
    public class SystemController : Controller
    {
        private static IList<Error> errors = new List<Error>
        {
            new Error(){Id = 1, ErrorCode = "CS0246", Description = "Nie można znaleźć nazwy typu lub przestrzeni nazw '...'.", Status = "Rozwiązany"},
            new Error(){Id = 2, ErrorCode = "CS0241", Description = "Nie znany błąd...", Status = "W trakcie"},
            new Error(){Id = 3, ErrorCode = "CS0249", Description = "Zmienna typu null, nie może być zainicjowana w obecnym kontekście", Status = "Rozwiązany"}
        };
        // GET: SystemController
        public ActionResult Index()
        {
            return View(errors);
        }

        // GET: SystemController/Details/5
        public ActionResult Details(int id)
        {
            return View(errors.FirstOrDefault(x => x.Id == id));
        }

        // GET: SystemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Error error)
        {
            error.Id = errors.Count + 1;
            errors.Add(error);
            return RedirectToAction("Index");
        }

        // GET: SystemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Error error1 = errors.FirstOrDefault(x => x.Id == id);
            error1.ErrorCode = collection["ErrorCode"];
            error1.Description = collection["Description"];
            error1.Status = collection["Status"];
            return RedirectToAction("Index");
        }

        // GET: SystemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Error error1 = errors.FirstOrDefault(x => x.Id == id);
            errors.Remove(error1);
            return RedirectToAction("Index");
        }
    }
}
