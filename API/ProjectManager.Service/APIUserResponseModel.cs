using ProjectManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Service
{
    public class APIUserResponseModel
    {
        public bool Success { get; set; }
        public Object Data { get; set; }
        public string Message { get; set; }

    }
}