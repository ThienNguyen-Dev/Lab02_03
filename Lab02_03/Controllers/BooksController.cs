using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_03.Models;


namespace Lab02_03.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private List<Book> listBooks;
        public BooksController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                Id = 1,
                Title = "Sách Lập trình viên",
                Author = "Book 1",
                Imgcover = "Content/images/Book1.jpg"
            });
            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "Sách Java Code",
                Author = "Book 2",
                Imgcover = "Content/images/Book2.jpg"
            });
            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "Sách HTML5 & CSS3",
                Author = "Book 3",
                Imgcover = "Content/images/Book3.jpg"
            });

        }
        // GET: Books
        public ActionResult List()
        {
            ViewBag.TitlePageName = "Danh Sách Book";
            return View(listBooks);
        }
        public ActionResult Edit(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Sách Lập trình viên", "Book 1", "Content/images/Book1.jpg"));
            books.Add(new Book(2, "Sách Java Code", "Book 2", "Content/images/Book2.jpg"));
            books.Add(new Book(3, "Sách HTML5 & CSS3", "Book 3", "Content/images/Book3.jpg"));

            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, string Title, string Author, string Imgcover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Sách Lập trình viên", "Book 1", "Content/images/Book1.jpg"));
            books.Add(new Book(2, "Sách Java Code", "Book 2", "Content/images/Book2.jpg"));
            books.Add(new Book(3, "Sách HTML5 & CSS3", "Book 3", "Content/images/Book3.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Imgcover = Imgcover;
                    break;
                }
            }
            return View("List", books);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id,Title,Author,Imgcover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Sách Lập trình viên", "Book 1", "Content/images/Book1.jpg"));
            books.Add(new Book(2, "Sách Java Code", "Book 2", "Content/images/Book2.jpg"));
            books.Add(new Book(3, "Sách HTML5 & CSS3", "Book 3", "Content/images/Book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            return View("List", books);
        }

    }
}