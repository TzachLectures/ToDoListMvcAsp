using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMvcAsp.Models;

namespace ToDoListMvcAsp.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        void Delete(int id);
    }
}
