using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListMvcAsp.Models;
using ToDoListMvcAsp.Services;

namespace ToDoListMvcAsp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        // Use constructor injection to get the ITodoService
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        // GET: Todo
        public ActionResult Index()
        {
            var todos = _todoService.GetAll();
            return View(todos);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,Description,DueDate")]TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Create(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DueDate")]TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Update(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _todoService.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Todo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var todo = _todoService.GetById(id.Value);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }
    }
}