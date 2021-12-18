using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleBookApplication.Models;
using System.Linq;

namespace SampleBookApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly SampleBookDBContext _context;

        public BookController(SampleBookDBContext context)
        {
            _context = context;
        }

        // GET: BookController
        public ActionResult Index()
        {
            var books = _context.Book.ToList();
            if (books == null)
            {
                return NotFound();
            }

            return View("View", books);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,BookName,BookDescription")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(book);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var books = _context.Book.SingleOrDefault(x => x.Id == id);

            if (books != null)
            {
                return View(books);
            }

            return NotFound();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,BookName,BookDescription")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {

            var book = _context.Book.SingleOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var books = _context.Book.SingleOrDefault(m => m.Id == id);
                
                _context.Book.Remove(books);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
