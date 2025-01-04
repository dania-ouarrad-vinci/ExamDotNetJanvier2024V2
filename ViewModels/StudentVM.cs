using ExamJanvier2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApplication1.ViewModels;

namespace ExamJanvier2024.ViewModels
{
    public class StudentVM
    {
        private SchoolContext dc = new SchoolContext();

        private StudentModel _selectedStudent;
        private ObservableCollection<StudentModel> _StudentsList;
        private ObservableCollection<SectionModel> _sectionsList;

        private DelegateCommand _updateCommand;


        public ObservableCollection<SectionModel> SectionsList
        {
            get
            {
                if (_sectionsList == null)
                {
                    _sectionsList = loadSections();
                }
                return _sectionsList;
            }
        }

        private ObservableCollection<SectionModel> loadSections()
        {
            ObservableCollection<SectionModel> localCollection = new ObservableCollection<SectionModel>();
            foreach (var item in dc.Sections)
            {
                localCollection.Add(new SectionModel(item));
            }
            return localCollection;
        }


        public ObservableCollection<StudentModel> StudentsList
        {
            get
            {
                if (_StudentsList == null)
                {
                    _StudentsList = loadStudent();
                }

                return _StudentsList;

            }

        }

        private ObservableCollection<StudentModel> loadStudent()
        {
            ObservableCollection<StudentModel> localCollection = new ObservableCollection<StudentModel>();
            foreach (var item in dc.Students)
            {
                localCollection.Add(new StudentModel(item));

            }

            return localCollection;

        }

     

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value;  }

        }

        public DelegateCommand UpdateCommand
        {
            get
            {
                return _updateCommand = _updateCommand ?? new DelegateCommand(SaveStudent);
            }

        }

    
        private void SaveStudent()
        {


            Student verif = dc.Students.Where(e => e.StudentId == SelectedStudent.MonStudent.StudentId).SingleOrDefault();
            if (verif != null)
            {
                verif.Name = SelectedStudent.Name;
                verif.Firstname = SelectedStudent.Firstname;
                verif.SectionId = SelectedStudent.Section.SectionId;

                dc.SaveChanges();
                MessageBox.Show("Enregistrement en base de données fait");
            }
        }



    }
}
