using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ExamJanvier2024.Models;

namespace ExamJanvier2024.ViewModels
{
    public class SectionModel 
    {
        private readonly Section _monSection;
   

        public Section MonSection
        {
            get { return _monSection; }
        }

        public SectionModel(Section current)
        {
            this._monSection = current;
        }

        public int SectionId
        {
            get { return _monSection.SectionId; }
        }

        public string Name
        {
            get { return _monSection.Name; }
        }
    }
}
