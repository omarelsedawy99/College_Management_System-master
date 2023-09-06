namespace Project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseIntializer());
        }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPicture> UserPictures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Assignment’s relations

            modelBuilder.Entity<Assignment>()
                .HasMany<Answer>(a => a.Answers)
                .WithRequired(e => e.Assignment)
                .HasForeignKey(e => e.AssignmentID);

            #endregion
            //note
            #region Course’s relations

            modelBuilder.Entity<Course>()
                .HasMany<Assignment>(c => c.Assignments)
                .WithRequired(a => a.Course)
                .HasForeignKey(a => a.CourseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasOptional<Course>(c => c.PrerequestCourse)
                .WithOptionalPrincipal()
                .Map(c => c.MapKey("PrerequestCourseID"))
                .WillCascadeOnDelete(false);//--> true

            #endregion

            #region Department’s relations

            modelBuilder.Entity<Department>()
                .HasMany<Doctor>(dep => dep.Doctors)
                .WithRequired(d => d.Department)
                .HasForeignKey<int>(d => d.DepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany<Employee>(dep => dep.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey<int>(e => e.DepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany<Student>(dep => dep.MajorDepStudents)
                .WithRequired(s => s.StudentMajorDepartment)
                .HasForeignKey<int>(s => s.MajorDepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                 .HasMany<Student>(dep => dep.MinorDepStudents)
                 .WithRequired(s => s.StudentMinorDepartment)
                 .HasForeignKey<int>(s => s.MinorDepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                 .HasMany<Timetable>(dep => dep.MajorDepTimetables)
                 .WithRequired(t => t.MajorDepartment)
                 .HasForeignKey<int>(t => t.MajorDepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                 .HasMany<Timetable>(dep => dep.MinorDepTimetables)
                 .WithRequired(t => t.MinorDepartment)
                 .HasForeignKey<int>(t => t.MinorDepID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany<Course>(dep => dep.Courses)
                .WithRequired(c => c.Department)
                .HasForeignKey<int>(c => c.DepID)
                .WillCascadeOnDelete(false);

            #endregion
            //note
            #region Doctor’s relations

            modelBuilder.Entity<Doctor>()
                .HasMany<Course>(d => d.Courses)
                .WithRequired(c => c.Doctor)//--> Optional
                .HasForeignKey(c => c.DoctorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany<Assignment>(d => d.Assignments)
                .WithRequired(a => a.Doctor)
                .HasForeignKey(a => a.DoctorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasRequired<User>(d => d.User)
                .WithOptional(u => u.Doctor)
                .Map(d => d.MapKey("UserID"))
                .WillCascadeOnDelete(false);

            #endregion

            #region Employee’s relations

            modelBuilder.Entity<Employee>()
                .HasRequired<User>(d => d.User)
                .WithOptional(u => u.Employee)
                .Map(d => d.MapKey("UserID"))
                .WillCascadeOnDelete(false);

            #endregion

            #region Lecture’s relations

            modelBuilder.Entity<Lecture>()
                .HasRequired<Course>(l => l.Course)
                .WithOptional(c => c.Lecture)
                .Map(l => l.MapKey("CourseID"))
                .WillCascadeOnDelete(false);

            #endregion

            #region Level’s relations

            modelBuilder.Entity<Level>()
                .HasMany<Student>(l => l.Students)
                .WithRequired(s => s.Level)
                .HasForeignKey(s => s.Lvl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany<Course>(l => l.Courses)
                .WithRequired(c => c.Level)
                .HasForeignKey(c => c.Lvl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany<Timetable>(l => l.Timetables)
                .WithRequired(t => t.Level)
                .HasForeignKey(t => t.Lvl)
                .WillCascadeOnDelete(false);

            #endregion

            #region Role’s relations

            modelBuilder.Entity<Role>()
                .HasMany<User>(r => r.Users)
                .WithRequired(u => u.Role)
                .HasForeignKey(u => u.RoleID)
                .WillCascadeOnDelete(false);

            #endregion

            #region Student’s relations

            modelBuilder.Entity<Student>()
                .HasRequired<User>(s => s.User)
                .WithOptional(u => u.Student)
                .Map(s => s.MapKey("UserID"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Student>()
                .HasMany<Answer>(s => s.Answers)
                .WithRequired(a => a.Student)
                .HasForeignKey<int>(a => a.StudentID);

            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(sc =>
                {
                    sc.MapLeftKey("StudentID");
                    sc.MapRightKey("CourseID");
                    sc.ToTable("StudentCourses");
                });

            #endregion

            #region Timetable’s relations

            modelBuilder.Entity<Timetable>()
                .HasMany<Lecture>(t => t.Lectures)
                .WithRequired(l => l.Timetable)
                .HasForeignKey<int>(l => l.TimetableID)
                .WillCascadeOnDelete(false);

            #endregion

            #region User’s relations

            modelBuilder.Entity<User>()
                .HasMany<Mail>(u => u.SendedMails)
                .WithRequired(m => m.Sender)
                .HasForeignKey(u => u.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany<Mail>(u => u.ReceivedMails)
                .WithRequired(m => m.Receiver)
                .HasForeignKey(u => u.ReceiverID)
                .WillCascadeOnDelete(false);

            #endregion

            #region UserPicture’s relations

            modelBuilder.Entity<UserPicture>()
                .HasRequired<User>(p => p.User)
                .WithOptional(u => u.UserPicture)
                .Map(p => p.MapKey("UserSSN"))
                .WillCascadeOnDelete(false);

            #endregion
        }
    }
}
