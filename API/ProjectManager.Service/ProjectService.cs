using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Entity;

namespace ProjectManager.Service
{
    public class ProjectService
    {
        ProjectManagerEntities5 EntityModel = new ProjectManagerEntities5();
        public List<Project> GetProjects()
        {
            var list = EntityModel.Projects.ToList();
            return list;
        }

      
        public bool AddProject(Project request)
        {
            //EntityModel.Projects.Add(new Project {Project_Name= request.Priority,Start_Date=request.StartDate,End_Date=request.EndDate });
            EntityModel.Projects.Add(request);
            EntityModel.SaveChanges();
            return true;
        }
        public bool UpdateProject(Project request)
        {
            var result = EntityModel.Projects.SingleOrDefault(x => x.Project_ID == request.Project_ID);
            if(result !=null)
            {
                result.Project_Name = request.Project_Name;
                result.Priority = request.Priority;
                result.Start_Date = request.Start_Date;
                result.End_Date = request.End_Date;
                EntityModel.SaveChanges();
                return true;

            }
            return false;

        }

        public bool DeleteProject(int ID)
        {
            var deleteProject = new Project { Project_ID = ID };
            EntityModel.Projects.Attach(deleteProject);
            EntityModel.Projects.Remove(deleteProject);
            EntityModel.SaveChanges();
            return true;
        }
    }
}