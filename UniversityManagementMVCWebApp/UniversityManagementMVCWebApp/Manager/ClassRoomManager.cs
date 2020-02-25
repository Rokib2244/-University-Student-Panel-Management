using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Manager
{
   
    public class ClassRoomManager
    {
        private ClassRoomGateway classRoomGateway=new ClassRoomGateway();
        private CourseManager courseManager = new CourseManager();

        public List<ClassRoom> GetAllClassRoomInfo()
        {
            return classRoomGateway.GetAllClassRoomInfo();
        }

        public string Save(ClassRoomAllocation classRoomAllocation)
        {
            List<ClassRoomAllocation> classRoomAllocations =
                classRoomGateway.GetClassRoomAllocationInfo(classRoomAllocation.RoomID, classRoomAllocation.Day);

            //int rowAffected = classRoomGateway.Save(classRoomAllocation);
            if (classRoomAllocations.Count==0)
            {
                int rowAffected = classRoomGateway.Save(classRoomAllocation);
                if (rowAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed.";
                }
            }
            else
            {
                string fromTime = classRoomAllocation.FromTimeHour + " " + classRoomAllocation.FromTimePeriod;
                string toTime = classRoomAllocation.ToTimeHour + " " + classRoomAllocation.ToTimePeriod;
                string dateFormat = "h:mm tt";
                DateTime fromDateTime = DateTime.ParseExact(fromTime, dateFormat, CultureInfo.InvariantCulture);
                DateTime toDateTime = DateTime.ParseExact(toTime, dateFormat, CultureInfo.InvariantCulture);
                bool roomCanBeAllocated = true;
                foreach (ClassRoomAllocation classRoom in classRoomAllocations)
                {
                    DateTime fromTimeAgainstWhichChekingToBeDone = DateTime.ParseExact(classRoom.FromTime, dateFormat,
                        CultureInfo.InvariantCulture);
                    DateTime toTimeAgainstWhichChekingToBeDone = DateTime.ParseExact(classRoom.ToTime, dateFormat,
                        CultureInfo.InvariantCulture);
                    if ((TimeSpan.Compare(fromTimeAgainstWhichChekingToBeDone.TimeOfDay, fromDateTime.TimeOfDay) == 1 &&
                        TimeSpan.Compare(fromTimeAgainstWhichChekingToBeDone.TimeOfDay, toDateTime.TimeOfDay) == 1) || (TimeSpan.Compare(toTimeAgainstWhichChekingToBeDone.TimeOfDay, fromDateTime.TimeOfDay) == -1 &&
                        TimeSpan.Compare(toTimeAgainstWhichChekingToBeDone.TimeOfDay, toDateTime.TimeOfDay)== -1))
                    {
                        roomCanBeAllocated = true;
                    }
                    else
                    {
                        roomCanBeAllocated = false;
                    }
                }
                if (roomCanBeAllocated)
                {
                    int rowAffected = classRoomGateway.Save(classRoomAllocation);
                    if (rowAffected > 0)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Failed.";
                    }
                }
                else
                {
                    return "Room Can't be allocated.";
                }
            }
        }

        public List<ClassRoomAllocationAndClassSchedule> GetClassSchedule(int id)
        {
            List<Course> courses = courseManager.GetCoursesByDepartmentId(id);
            return classRoomGateway.GetClassSchedule(courses);
        }
    }
}