using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniBinderAPI.EntityFramework
{
    public class DbInitialiazer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //IList<Grade> grades = new List<Grade>();

            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });
            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "B" });
            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "C" });
            //grades.Add(new Grade() { GradeName = "Grade 2", Section = "A" });
            //grades.Add(new Grade() { GradeName = "Grade 3", Section = "A" });

            //context.Grades.AddRange(grades);

            base.Seed(context);
        }
    }
}