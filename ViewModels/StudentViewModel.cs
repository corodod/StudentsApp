#nullable enable

using System;
using System.ComponentModel;
using System.Windows.Input;
using StudentApp.Models;

namespace StudentApp.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _student;
        private string _result;

        public string LastName
        {
            get => _student.LastName;
            set
            {
                _student.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FirstName
        {
            get => _student.FirstName;
            set
            {
                _student.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public DateTime BirthDate
        {
            get => _student.BirthDate;
            set
            {
                _student.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public int Course
        {
            get => _student.Course;
            set
            {
                _student.Course = value;
                OnPropertyChanged(nameof(Course));
            }
        }

        public string Group
        {
            get => _student.Group;
            set
            {
                _student.Group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand CalculateAverageGradeCommand { get; }
        public ICommand CalculateAverageGradeBySubjectCommand { get; }
        public ICommand GetFailedSubjectsCommand { get; }

        public StudentViewModel(Student student)
        {
            _student = student;
            _result = string.Empty;

            // Инициализация команд
            CalculateAverageGradeCommand = new RelayCommand(_ => Result = _student.CalculateAverageGrade().ToString());
            CalculateAverageGradeBySubjectCommand = new RelayCommand(_ => Result = _student.CalculateAverageGradeBySubject("Математика").ToString());
            GetFailedSubjectsCommand = new RelayCommand(_ => Result = string.Join(", ", _student.GetFailedSubjects()));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}