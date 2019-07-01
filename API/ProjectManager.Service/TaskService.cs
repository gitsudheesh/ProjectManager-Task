using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Entity;

namespace ProjectManager.Service
{
    public class TaskService
    {
        ProjectManagerEntities5 EntityModel = new ProjectManagerEntities5();
        public List<Task> GetTasks()
        {
            var list = EntityModel.Tasks.ToList();
            return list;
        }
        public bool AddTask(Task request)
        {

            Task task = new Task();
            task.End_Date = request.End_Date;
            task.Start_Date= request.End_Date;
            task.Parent_ID = request.Parent_ID;
            task.Project_ID = request.Project.Project_ID;
            task.Priority = request.Priority;
            task.Task1 = "Test Task";//Fix here
            task.Status = "Open";
            EntityModel.Tasks.Add(task);
            EntityModel.SaveChanges();

            return true;
        }
        public bool UpdateTask(Task request)
        {
            var result = EntityModel.Tasks.SingleOrDefault(x => x.Task_ID == request.Task_ID);
            if (result != null)
            {
                result.Task_ID = request.Task_ID;
                result.Parent_ID = request.Parent_ID;
                result.Priority = request.Priority;
                result.Start_Date = request.Start_Date;
                result.End_Date = request.End_Date;
                result.Project_ID = request.Project_ID;
                result.Task_ID = request.Task_ID;
                result.Status = "Open";
                EntityModel.SaveChanges();
                return true;

            }
            return false;

        }

        public bool DeleteUser(int ID)
        {
            var deleteUser = new User { User_ID = ID };
            EntityModel.Users.Attach(deleteUser);
            EntityModel.Users.Remove(deleteUser);
            EntityModel.SaveChanges();
            return true;
        }
    }
}