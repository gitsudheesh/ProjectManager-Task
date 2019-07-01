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

    [RoutePrefix("users")]
    public class UsersController : ApiController
    {

        UserService Service = new UserService();
        [Route("")]
        public object GetUsers(string sortKey = null)
        {
            var response = Service.GetUsers();
            switch (sortKey)
            {
                case "First_Name":
                    response = response.OrderBy(x => x.First_Name).ToList();
                    break;
                case "Last_Name":
                    response = response.OrderBy(x => x.Last_Name).ToList();
                    break;
                case "Employee_ID":
                    response = response.OrderBy(x => x.Employee_ID).ToList();
                    break;
            }
            var apiResponse = new APIUserResponseModel();
            apiResponse.Data = response.ToList();
            apiResponse.Success = true;
            return apiResponse;

        }

        [Route("{ID}")]
        public object GetUser(int ID)
        {
            var response = Service.GetUsers();
            var apiResponse = new APIUserResponseModel();
            apiResponse.Data = response.FirstOrDefault(x=>x.User_ID==ID);
            apiResponse.Success = true;
            return apiResponse;

        }


        [Route("add")]
        public object Add(User request)
        {
            var apiResponse = new APIUserResponseModel();
            try
            {

                var response = Service.AddUser(request);
                apiResponse.Message = "User Added Sucessfully";
                apiResponse.Success = true;
                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Adding User";
                apiResponse.Success = false;
                return apiResponse;
            }
        }

        [Route("edit/{ID}")]
        [HttpPost]
        public object Update(User request,int ID)
        {
            var apiResponse = new APIUserResponseModel();

            try
            {

                var response = Service.UpdateUser(request);
                if (response)
                {
                    apiResponse.Message = "User Updated Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while Updating User";
                    apiResponse.Success = false;
                }

                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Updating User";
                apiResponse.Success = false;
                return apiResponse;
            }
        }

        [Route("delete/{ID}")]
        [HttpGet]
        public object Delete(int ID)
        {
            var apiResponse = new APIUserResponseModel();

            try { 
                var response = Service.DeleteUser(ID);
                if (response)
                {
                    apiResponse.Message = "User Deleted Sucessfully";
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Message = "Errror while Deleting User";
                    apiResponse.Success = true;
                }
                return apiResponse;
            }
            catch (Exception Ex)
            {
                apiResponse.Message = "Errror while Deleting User";
                apiResponse.Success = false;
                return apiResponse;
            }
}
    }
}
