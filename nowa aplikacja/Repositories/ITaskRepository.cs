﻿using nowa_aplikacja.Models;
namespace nowa_aplikacja.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int taskId);
        IQueryable<TaskModel> GetAllActive();

        void Add(TaskModel task);
        void Update(int taskId, TaskModel task);
        void Delete(int taskId);
    }
}
