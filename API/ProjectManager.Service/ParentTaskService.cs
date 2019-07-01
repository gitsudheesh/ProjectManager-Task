using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Entity;

namespace ProjectManager.Service
{
    public class ParentTaskService
    {
        ProjectManagerEntities5 EntityModel = new ProjectManagerEntities5();
        public List<ParentTask> GetParentTasks()
        {
            var list = EntityModel.ParentTasks.ToList();
            return list;
        }
        public bool AddParentTask(ParentTask request)
        {
            EntityModel.ParentTasks.Add(request);
            EntityModel.SaveChanges();
            return true;
        }
  
    }
}