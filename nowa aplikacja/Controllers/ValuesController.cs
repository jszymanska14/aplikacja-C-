using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using nowa_aplikacja.Models;
using static System.Collections.Specialized.BitVector32;

namespace nowa_aplikacja.Controllers
{
    public class ValuesController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel(){ TaskId = 1, Name = "Wizyta u lekarza", Description = "Godzina 17:00", Done = false},
            new TaskModel(){ TaskId = 2, Name = "Zrobić obiad", Description = "Godzina 15:00", Done = false},
            new TaskModel() { TaskId = 3, Name = "Trening", Description = "Godzina 8:00", Done = false}

        };

        // GET: Task
        public ActionResult Index()
        {
            
                Console.WriteLine("Tasks count: " + tasks.Count);
            
                return View(tasks.Where(x => !x.Done));
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x=>x.TaskId==id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel()); 
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskId = tasks.Count + 1;
            tasks.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {

            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;
            return RedirectToAction(nameof(Index));

        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(task);

            return RedirectToAction(nameof(Index));
            
            
                

            }
            public ActionResult Done (int id)
            {
                TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
                task.Done = true;

                return RedirectToAction(nameof(Index));
            }
        }

    }

            
     

    

