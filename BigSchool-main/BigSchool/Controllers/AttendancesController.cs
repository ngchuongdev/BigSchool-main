﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Coursee attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendances.Any(p=>p.Attendee==userID && p.CourseId==attendanceDto.Id))
            {
                return BadRequest("The attendance already exist!");
            }
            var attendance = new Attendance() { CourseId = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }

        
    }
}
