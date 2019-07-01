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

    [RoutePrefix("tasks")]
    public class TasksController : ApiController
    {

        TaskService Service = new TaskService();

        [Route("")]
        public object GetTasks(int? projectId=null,string sortKey=null)
        {
            List<Task> response;
            if(projectId==null)
                response = Service.GetTasks().ToList();
            else
                response = Service.GetTasks().Where(x=>x.Project_ID == projectId).ToList();
            switch(sortKey)
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
                case "Status":
                    response = response.OrderBy(x => x.Status).ToList();
                    break;
            }

            var apiResponse = new APITaskResponseModel();
            apiResponse.Data = response.ToList();
            apiResponse.Success = true;
            return apiResponse;

        }

        [Route("{id}")]
        [HttpGet]
        public APIProjectResponseModel GetTask(int ID)
        {
            List<Task> response = Service.GetTasks();
            var apiResponse = new APIProjectResponseModel();
            apiResponse.Data = response.First(x => x.Task_ID == ID);
            apiResponse.Success = true;
            return apiResponse;

        }
        [Route("add")]
        public object AddTask(Task request)
        {
            var apiResponse = new APITaskResponseModel();
            try
            {
                var response = Service.AddTask(request);
                if (response)
                {
                    apiResponse.Message = "Task Added Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while Task Addition";
                    apiResponse.Success = false;

                }
                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Adding Task";
                apiResponse.Success = false;
                return apiResponse;
            }

        }

        [Route("edit")]
        [HttpPost]

        public object Update(Task request)
        {
            var apiResponse = new APITaskResponseModel();
           try
            {
                var response = Service.UpdateTask(request);
                if (response)
                {
                    apiResponse.Message = "Task Updated Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while Task Updation";
                    apiResponse.Success = true;
                }

                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Task Update";
                apiResponse.Success = true;
                return apiResponse;
            }
        }

        [Route("delete")]
        [HttpGet]
        public object Delete(int ID)
        {
            var response = Service.DeleteUser(ID);
            return true;
        }
    }
}
