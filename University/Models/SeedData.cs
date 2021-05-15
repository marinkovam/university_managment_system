using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using University.Data;

namespace University.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UniversityContext>>()))
            {
                // Look for any movies.
                if (context.Course.Any() || context.Teacher.Any() || context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Teacher.AddRange(
                    new Teacher { /*Id = 1, */firstName = "name1", lastName = "surname1" },
                    new Teacher { /*Id = 2, */firstName = "name2", lastName = "surname2"},
                    new Teacher { /*Id = 3, */firstName = "name3", lastName = "surname3"},
                    new Teacher { /*Id = 4, */firstName = "name4", lastName = "surname4" }
                );
                context.SaveChanges();

                context.Student.AddRange(
                    new Student { studentID = "17", firstName = "n1", lastName = "surname1", enrollmentDate = DateTime.Parse("2017-09-01") },
                    new Student { studentID = "12", firstName = "n2", lastName = "surname2", enrollmentDate = DateTime.Parse("2017-09-01") }
                   
                 );
                context.SaveChanges();

                context.Course.AddRange(
                    new Course
                    {
                        ID = 1050,
                        title = "Calculus",
                        credits = 6,
                        semester = 1,
                        firstTeacherID = context.Teacher.Single(d => d.firstName == "n1" && d.lastName == "surname1").ID,
                        secondTeacherID = context.Teacher.Single(d => d.firstName == "n1" && d.lastName == "surname1").ID
                    },

                   

                    new Course
                    {
                        ID = 1045,
                        title = "Chemistry",
                        credits = 6,
                        semester = 1,
                        firstTeacherID = context.Teacher.Single(d => d.firstName == "n1" && d.lastName == "surname1").ID,
                        secondTeacherID = context.Teacher.Single(d => d.firstName == "n2" && d.lastName == "surname2").ID
                    },

                    

                    new Course
                    {
                        ID = 2042,
                        title = "Literature",
                        credits = 6,
                        semester = 3,
                        firstTeacherID = context.Teacher.Single(d => d.firstName == "n1" && d.lastName == "surname1").ID,
                        secondTeacherID = context.Teacher.Single(d => d.firstName == "n2" && d.lastName == "surname2").ID
                    }
                );
                context.SaveChanges();

                context.Enrollment.AddRange(
                    new Enrollment { studentID = 1, courseID = 1045 },
                   
                    new Enrollment { studentID = 4, courseID = 2042 }
                );

                context.SaveChanges();
            }
        }
    }
}
