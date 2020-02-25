using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models.Views
{
    public class ClassRoomAllocationAndClassSchedule
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<ClassRoomAllocation> ClassRoomAllocations { get; set; }

        public ClassRoomAllocationAndClassSchedule()
        {
            ClassRoomAllocations=new List<ClassRoomAllocation>();
        }

    }
}