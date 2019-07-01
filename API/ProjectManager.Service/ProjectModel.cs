using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Service
{
    public class ProjectModel
    {

        public int ProjectID { get; set; }
        public string Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Priority { get; set; }
    }
}