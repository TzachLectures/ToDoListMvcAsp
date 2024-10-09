using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoListMvcAsp.Models;

namespace ToDoListMvcAsp.Services
{
    public class TodoService:ITodoService
    {
        private static List<TodoItem> _todoItems = new List<TodoItem>();

        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public TodoItem GetById(int id)
        {
            return _todoItems.FirstOrDefault(t => t.Id == id);
        }

        public void Create(TodoItem todo)
        {
            todo.Id = _todoItems.Count + 1;
            _todoItems.Add(todo);
        }

        public void Update(TodoItem todo)
        {
            var existingTodo = _todoItems.FirstOrDefault(t => t.Id == todo.Id);
            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                existingTodo.IsCompleted = todo.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var todo = _todoItems.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todoItems.Remove(todo);
            }
        }
    }
}