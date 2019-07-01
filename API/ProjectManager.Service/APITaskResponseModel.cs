using ProjectManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Service
{
    public class APITaskResponseModel
    {
        public bool Success { get; set; }
        public List <Task> Data { get; set; }
        public string Message { get; set; }

    }
}