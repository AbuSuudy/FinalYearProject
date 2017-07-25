namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Blackboard.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Blackboard.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blackboard.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddLecturer(context);
            AddStudents(context);
        }

        bool AddLecturer(Blackboard.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Lecturer"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "Carer@email.com",
            };

            ir = um.Create(user, "password");

            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "Lecturer");
            return ir.Succeeded;
        }
        /*bool AddStudent(Blackboard.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Student"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "Student1@email.com",
            };

            ir = um.Create(user, "password");

            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "Student");
            return ir.Succeeded;
        }*/
        void AddStudents(Blackboard.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Student"));

            var user = new Models.ApplicationUser
            {
                UserName = "Person@email.com"
            };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            um.Create(user, "password");

        }
    }
}
