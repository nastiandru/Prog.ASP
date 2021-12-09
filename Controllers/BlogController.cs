using Prog_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Controllers
{
    public class BlogController : Controller
    {
        private ICRUDBlogItemRepository repository;

        static List<BlogItem> items = new List<BlogItem>()
        {
            new BlogItem() {Title="Programowanie w ASP.NET", Id = 1, Content ="Przykładowa treść",
            CreationTimstamp = DateTime.Now},
            new BlogItem() {Title="Entity Framwork", Id = 2, Content ="Opis EF w .NET",
            CreationTimstamp = DateTime.Now}
        };

        static int index = 2;
        

        public IActionResult Edit(int id)
        {
            BlogItem editedItem = findById(id);
            return View("EditForm", editedItem);
        }
        public IActionResult Delete(int id)
        {
            BlogItem deleteItem = findById(id);
            items.Remove(deleteItem);
            return View("BlogList", items);
        }

        [HttpPost]

        public IActionResult Edit(BlogItem ItemFromForm)
        {
            int id = ItemFromForm.Id;
            BlogItem originItem = findById(id);
            originItem.Content = ItemFromForm.Content;
            originItem.Title = ItemFromForm.Title;
            return View("BlogList", items);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddForm()
        {
            return View();
        }
        public IActionResult Add(BlogItem item)
        {
            if(ModelState.IsValid)
            {
                item.Id = ++index;
                item.CreationTimstamp = DateTime.Now;
                items.Add(item);
                return View("ConfirmBlogItem", item);
            }
            else
            {
                return View("AddForm");
            }
        }
        public IActionResult BlogList()
        {
            return View(items);
        }
        public BlogItem findById(int id)
        {
            foreach(var item in items)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
