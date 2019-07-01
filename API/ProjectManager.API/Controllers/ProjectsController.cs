using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager;
using ProjectManager.Service;
using ProjectManager.Entity;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("projects")]
    public class ProjectsController : ApiController
    {
        ProjectService Service = new ProjectService();
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("")]
        public APIProjectResponseModel GetProjects(string sortKey = null)
        {
            List<Project> response = Service.GetProjects();
            switch (sortKey)
            {
                case "Start_Date":
                    response = response.OrderBy(x => x.Start_Date).ToList();
                    break;
                case "End_Date":
                    response = response.OrderBy(x => x.End_Date).ToList();
                    break;
                case "Priority":
                    response = response.OrderBy(x => x.Priority).ToList();
                    break;
            }
            var apiResponse = new APIProjectResponseModel();
            apiResponse.Data = response.ToList();
            apiResponse.Success = true;
            return apiResponse;
            
        }

        [Route("{id}")]
        [HttpGet]
        public APIProjectResponseModel GetProject(int ID)
        {
            List<Project> response = Service.GetProjects();
            var apiResponse = new APIProjectResponseModel();
            apiResponse.Data = response.First(x=>x.Project_ID==ID);
            apiResponse.Success = true;
            return apiResponse;

        }



        [Route("add")]
        public APIProjectResponseModel AddProject(Project request)
        {
            var apiResponse = new APIProjectResponseModel();
            try
            {

                var response = Service.AddProject(request);
                apiResponse.Message = "Project Added Sucessfully";
                apiResponse.Success = true;
                return apiResponse;
            }
            catch(Exception Ex)
            {
                apiResponse.Message = "Errror while Adding Project";
                apiResponse.Success = false;
                return apiResponse;
            }
        }

        [Route("edit/{ID}")]
        [HttpPost]
        public object Update(Project request,int ID)
        {
            var apiResponse = new APIProjectResponseModel();
            try
            {

                var response = Service.UpdateProject(request);
                apiResponse.Message = "Project Updated Sucessfully";
                apiResponse.Success = true;
                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Updating Project";
                apiResponse.Success = false;
                return apiResponse;
            }
        }

        [Route("delete/{ID}")]
        [HttpGet]
        public object Delete(int ID)
        {
            var apiResponse = new APIProjectResponseModel();
            try
            {

                var response = Service.DeleteProject(ID);
                if (response)
                {
                    apiResponse.Message = "Project Deleted Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while Deleting Project";
                    apiResponse.Success = false;
                }

                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Deleting Project";
                apiResponse.Success = false;
                return apiResponse;
            }
        }
    }
}
