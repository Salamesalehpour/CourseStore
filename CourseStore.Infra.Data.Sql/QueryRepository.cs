﻿using CourseStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Infra.Data.Sql
{
    public class QueryRepository
    {

        public static void AddToParent()
        {
            var context = ContextFactory.SqlServerCourseStoreContext();

            var parent = new Parent { Name = "Salam" };

            parent.Child1s = new List<Child1>();
            parent.Child2s = new List<Child2>();
            parent.Child3s = new List<Child3>();

            for (int i = 0; i < 1000; i++)
            {
                parent.Child1s.Add(new Child1 { Name = $"Name {i}" });
                parent.Child2s.Add(new Child2 { Name = $"Name {i}" });
                parent.Child3s.Add(new Child3 { Name = $"Name {i}" });
            }

            context.Parents.Add(parent);

            context.SaveChanges();
        }

        public static void EagerLoadingSample()
        {
            var ctx = ContextFactory.SqlServerCourseStoreContext();

            var query1 = ctx.Courses.ToList();

            var query2 = ctx.Courses.Include(c => c.Comments.Where(cc => cc.Title.Length > 5)).ToList();

            var query3 = ctx.Courses.Include(c => c.CourseTeachers).ToList();

            var query4 = ctx.Courses.Include(c => c.CourseTeachers).ThenInclude(ct => ct.Teacher).ToList();
        }

        public static void ExplicitLoadingSample()
        {
            var ctx = ContextFactory.SqlServerCourseStoreContext();

            var course = ctx.Courses.Find(1);

            ctx.Entry(course).Collection(c => c.Comments).Load();
        }

        public static void SelectLoadingSample()
        {
            var ctx = ContextFactory.SqlServerCourseStoreContext();

            var courses = ctx.Courses.Select(c => new
            {
                Title = c.Title,
                CommentCount = c.Comments.Count
            });
        }

        public static void AddDefaultData()
        {
            var context = ContextFactory.SqlServerCourseStoreContext();

            context.Courses.Where(c => c.Title == "");
            context.Courses.Add(new Course
            {
                Title = "Pro ASP.NET Core",
                Price = 100,
                Description = "Description ASP Net Core",
                Discount = new Discount
                {
                    Name = "Yalda",
                    NewPrice = 80
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Title = "Comment Title",
                        CommentDate = DateTime.Now,
                        CommentText = "Comment Text"
                    }
                },
                CourseTeachers = new List<CourseTeacher>
                {
                    new CourseTeacher
                    {
                        SortOrder = 1,
                        Teacher = new Teacher
                        {
                            FirstName= "Alireza",
                            LastName = "Oroumand"
                        }
                    }
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Title = "ASP.NET"
                    },
                    new Tag
                    {
                        Title = ".NET 5"
                    }
                }
            });
            context.SaveChanges();
        }
    }
}
