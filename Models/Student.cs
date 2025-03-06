using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Models
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTimeOffset BirthDate { get; set; } // Изменено на DateTimeOffset
        public int Course { get; set; }
        public string Group { get; set; }
        private Dictionary<int, Dictionary<string, List<int>>> Grades { get; set; }

        public Student(string lastName, string firstName, DateTimeOffset birthDate, int course, string group, Dictionary<int, Dictionary<string, List<int>>> subjects)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate; // Изменено на DateTimeOffset
            Course = course;
            Group = group;
            Grades = subjects;
        }

        public double CalculateAverageGrade()
        {
            var allGrades = Grades.Values.SelectMany(semester => semester.Values.SelectMany(subject => subject));
            return allGrades.Any() ? allGrades.Average() : 0;
        }

        public double CalculateAverageGradeBySubject(string subject)
        {
            var subjectGrades = Grades.Values.SelectMany(semester => semester.ContainsKey(subject) ? semester[subject] : Enumerable.Empty<int>());
            return subjectGrades.Any() ? subjectGrades.Average() : 0;
        }

        public List<string> GetFailedSubjects()
        {
            return Grades.Values
                .SelectMany(semester => semester.Where(subject => subject.Value.Average() < 3).Select(subject => subject.Key))
                .Distinct()
                .ToList();
        }
    }
}