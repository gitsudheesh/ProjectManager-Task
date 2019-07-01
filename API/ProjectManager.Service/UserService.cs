using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Entity;

namespace ProjectManager.Service
{
    public class UserService
    {
        ProjectManagerEntities5 EntityModel = new ProjectManagerEntities5();
        public List<User> GetUsers()
        {
            var list = EntityModel.Users.ToList();
            return list;
        }
        public bool AddUser(User request)
        {
            EntityModel.Users.Add(request);
            EntityModel.SaveChanges();
            return true;
        }
        public bool UpdateUser(User request)
        {
            var result = EntityModel.Users.SingleOrDefault(x => x.User_ID == request.User_ID);
            if (result != null)
            {
                result.User_ID = request.User_ID;
                result.Last_Name = request.Last_Name;
                result.First_Name = request.First_Name;
                result.Project_ID = request.Project_ID;
                result.Task_ID = request.Task_ID;
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