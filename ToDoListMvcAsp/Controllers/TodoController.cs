using NLog;
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
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        public ActionResult Index()
        {
            _logger.Info("Accessed Todo Index page.");
            var todos = _todoService.GetAll();
            return View(todos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,Description,DueDate")]TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Create(todo);
                return RedirectToAction("Index");
            }
            _logger.Info("New todo has been created.");

            return View(todo);
        }

        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DueDate")]TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Update(todo);
                _logger.Info($"Todo {todo.Id} has been edited");
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        public ActionResult Delete(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _todoService.Delete(id);
            _logger.Info($"Todo {id} has been deleted");
            return RedirectToAction("Index");

        }

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