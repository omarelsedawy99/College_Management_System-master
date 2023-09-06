using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DatabaseIntializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            #region Adding Roles Data
            context.Roles.Add(new Role() { Title = "Dean" });
            context.Roles.Add(new Role() { Title = "Doctor" });
            context.Roles.Add(new Role() { Title = "Student" });
            context.Roles.Add(new Role() { Title = "Employee" });
            #endregion

            #region Adding Levels Data
            context.Levels.Add(new Level() { level = 1 });
            context.Levels.Add(new Level() { level = 2 });
            context.Levels.Add(new Level() { level = 3 });
            context.Levels.Add(new Level() { level = 4 });
            #endregion

            #region Adding Departments Data
            context.Departments.Add(new Department() { Title = "General" });
            context.Departments.Add(new Department() { Title = "Computer Science" });
            context.Departments.Add(new Department() { Title = "Information System" });
            context.Departments.Add(new Department() { Title = "Internet Technology" });
            context.Departments.Add(new Department() { Title = "Accounting" });
            context.Departments.Add(new Department() { Title = "Treasury" });
            context.Departments.Add(new Department() { Title = "Public Relations" });
            #endregion

            #region Adding Students Data
            context.Students.Add(new Student()
            {
                User = new User()
                {
                    SSN = "26431757512467",
                    FullName = "Mostafa Youssef Ramadan Taha",
                    Gender = true,
                    BirthDate = DateTime.Parse("2000 - 01 - 12"),
                    Phone = "01278436951",
                    Street = "Talbia",
                    City = "Cairo",
                    Country = "Egypt",
                    Email = "mostafa542@yahoo.com",
                    Password = "mostafa542",
                    RoleID = 3
                },
                Lvl = 1,
                MajorDepID = 1,
                MinorDepID = 1,
                PaymentStatus = false
            });
            context.Students.Add(new Student()
            {
                User = new User()
                {
                    SSN = "26431412831246",
                    FullName = "Mohamed Ahmed Saad Ahmed",
                    Gender = true,
                    BirthDate = DateTime.Parse("1999 - 06 - 13"),
                    Phone = "01012081083",
                    Street = "Haram",
                    City = "Giza",
                    Country = "Egypt",
                    Email = "Ma39547@yahoo.com",
                    Password = "Ma39547",
                    RoleID = 3
                },
                Lvl = 3,
                MajorDepID = 2,
                MinorDepID = 3,
                PaymentStatus = false
            });
            context.Students.Add(new Student()
            {
                User = new User()
                {
                    SSN = "26431992331245",
                    FullName = "Reem Osman Tarek Ibrahem",
                    Gender = false,
                    BirthDate = DateTime.Parse("1999 - 09 - 21"),
                    Phone = "01296475363",
                    Street = "Youseef Gamal",
                    City = "Alexandria",
                    Country = "Egypt",
                    Email = "Reem9921@hotmail.com",
                    Password = "Reem99921",
                    RoleID = 3
                },
                Lvl = 4,
                MajorDepID = 4,
                MinorDepID = 3,
                PaymentStatus = true
            });
            #endregion

            #region Adding Doctors Data
            context.Doctors.Add(new Doctor()
            {
                User = new User()
                {
                    SSN = "26943812864456",
                    FullName = "Ismail Taha Hamed Kareem",
                    Gender = true,
                    BirthDate = DateTime.Parse("1985 - 07 - 19"),
                    Phone = "01176342981",
                    Street = "Faysal",
                    City = "Giza",
                    Country = "Egypt",
                    Email = "Taha85@gmail.com",
                    Password = "Taha01176342981",
                    RoleID = 1
                },
                DepID = 2,
                Salary = 3000
            });
            context.Doctors.Add(new Doctor()
            {
                User = new User()
                {
                    SSN = "26943897332456",
                    FullName = "Sanaa Mohamed Farouk Farag",
                    Gender = false,
                    BirthDate = DateTime.Parse("1980 - 02 - 24"),
                    Phone = "01234685726",
                    Street = "Helwan",
                    City = "Cairo",
                    Country = "Egypt",
                    Email = "DrSanaa80@gmail.com",
                    Password = "01234685726",
                    RoleID = 2
                },
                DepID = 3,
                Salary = 4000
            });
            context.Doctors.Add(new Doctor()
            {
                User = new User()
                {
                    SSN = "21218213312456",
                    FullName = "Salah Ibrahim Serag Ahmed",
                    Gender = true,
                    BirthDate = DateTime.Parse("1979 - 08 - 04"),
                    Phone = "01048937520",
                    Street = "Dar-Elsalam",
                    City = "Cairo",
                    Country = "Egypt",
                    Email = "SalahIbrahim798@gmail.com",
                    Password = "Salah798Ibrahim",
                    RoleID = 2
                },
                DepID = 4,
                Salary = 4500
            });
            #endregion

            #region Adding Employees Data
            context.Employees.Add(new Employee()
            {
                User = new User()
                {
                    SSN = "26911211864456",
                    FullName = "Youssef Ali Ahmed Shahat",
                    Gender = true,
                    BirthDate = DateTime.Parse("1992 - 03 - 05"),
                    Phone = "01254781564",
                    Street = "Doki",
                    City = "Giza",
                    Country = "Egypt",
                    Email = "Youssef.Ali.92@gmail.com",
                    Password = "Youssef123456",
                    RoleID = 4
                },
                DepID = 5,
                Salary = 3500
            });
            context.Employees.Add(new Employee()
            {
                User = new User()
                {
                    SSN = "26913124814456",
                    FullName = "Abeer Yahia Saeed Gamal",
                    Gender = false,
                    BirthDate = DateTime.Parse("1994 - 05 - 19"),
                    Phone = "01102349005",
                    Street = "Behoos",
                    City = "Giza",
                    Country = "Egypt",
                    Email = "Abeer.Ali94@gmail.com",
                    Password = "AbeerAli1994",
                    RoleID = 4
                },
                DepID = 6,
                Salary = 3200
            });
            context.Employees.Add(new Employee()
            {
                User = new User()
                {
                    SSN = "23459167842384",
                    FullName = "Mohamed Ahmed Eid Ahmed",
                    Gender = true,
                    BirthDate = DateTime.Parse("1990 - 07 - 23"),
                    Phone = "01045987631",
                    Street = "Opera",
                    City = "Giza",
                    Country = "Egypt",
                    Email = "Eid45987631@gmail.com",
                    Password = "Eid45987631",
                    RoleID = 4
                },
                DepID = 7,
                Salary = 3200
            });
            #endregion

            #region Adding Courses Data
            //context.Courses.Add(new Course() {  });
            #endregion

            base.Seed(context);
        }
    }
}