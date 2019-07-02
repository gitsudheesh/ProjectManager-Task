using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Entity;
using NUnit;
using NUnit.Framework;

namespace ProjectManager.Service
{
    public class APITester
    {
        ProjectManagerEntities5 model = new ProjectManagerEntities5();

        [TestCase]
        public void TestProjects()
        {
            int? itemCount = model.Projects.Count();
            Assert.AreEqual(itemCount, model.Projects.Count());
        }

        [TestCase]
        public void TestAddProject()
        {
            Project request = new Project();
            request.Project_Name = "NUnit Test";
            request.Start_Date = new DateTime(2019, 1, 1);
            request.End_Date = new DateTime(2019, 1, 1);
            request.Priority = 8;
            request.Manager_ID = 1;
            var result = model.Projects.Add(request);
            model.SaveChanges();
            Assert.AreEqual(result, result);

        }

        [TestCase]
        public void TestUsers()
        {
            int? itemCount = model.Users.Count();
            Assert.AreEqual(itemCount, model.Users.Count());
        }

        [TestCase]
        public void TestAddUser()
        {
            User request = new User();
            request.First_Name = "NUNIT Fist Name";
            request.Last_Name = "NUNIT Last Name";
            request.Employee_ID = 123456;
            var result = model.Users.Add(request);
            model.SaveChanges();
            Assert.AreEqual(result, result);

        }


    }
}