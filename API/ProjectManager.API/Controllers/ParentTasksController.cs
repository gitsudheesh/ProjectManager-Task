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
    [RoutePrefix("parenttasks")]
    public class ParentTasksController : ApiController
    {

        ParentTaskService Service = new ParentTaskService();
        [Route("")]
        public object GetParentTasks()
        {
            var response = Service.GetParentTasks();
            var apiResponse = new APIParentTaskResponseModel();
            apiResponse.Data = response.ToList();
            apiResponse.Success = true;
            return apiResponse;

        }

        [Route("{id}")]
        [HttpGet]
        public APIProjectResponseModel GetParent(int ID)
        {
            List<ParentTask> response = Service.GetParentTasks();
            var apiResponse = new APIProjectResponseModel();
            apiResponse.Data = response.First(x => x.Parent_ID == ID);
            apiResponse.Success = true;
            return apiResponse;

        }
        [Route("add")]
        public object AddParentTask(ParentTask request)
        {
            var apiResponse = new APIParentTaskResponseModel();

            try
            {

                var response = Service.AddParentTask(request);
                if (response)
                {
                    apiResponse.Message = "Parent Task added Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while adding Parent Task";
                    apiResponse.Success = false;
                }

                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while adding Parent Task";
                apiResponse.Success = false;
                return apiResponse;
            }
        }

    }
}
