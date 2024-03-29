﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WFM_API.Models.Identity;

namespace WFM_API.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeAppointment> EmployeeAppointments { get; set; }
        public DbSet<EmpException> Exceptions { get; set; }



    }
}
