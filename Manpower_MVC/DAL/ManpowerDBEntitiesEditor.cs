using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Manpower_MVC.REST.Models;

namespace Manpower_MVC.DAL
{
    public class ManpowerDBEntitiesEditor : DbContext
    {
        public ManpowerDBEntitiesEditor():base("ManpowerDBEntitiesEditor")
        {

        }

        public DbSet<Emp> Emp { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OwnerBuilding> OwnerBuilding { get; set; }
        public DbSet<OwnerPayment> OwnerPayment { get; set; }
        public DbSet<OwnerPayWork> OwnerPayWork { get; set; }
        public DbSet<WorkCategory> WorkCategory { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<InsCate> InsCate { get; set; }
        public DbSet<EmpInsurance> EmpInsurance { get; set; }
        public DbSet<WorkList> WorkList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
