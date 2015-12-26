using System;
using System.Data.Entity;
using LabelConverter.Models;
using LabelsMain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LabelConverter
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public virtual DbSet<LabelViewModel> Spreadsheets { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}