using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Admin.ViewModel
{
    public class SkillsUCVM : BaseVM
    {
        private ObservableCollection<Skill> _skills;
        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set 
            { 
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }

        private Skill _selectedSkill;
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set 
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }

        private String _title;
        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private String _link;
        public String Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged("Link");
            }
        }

        public SkillsUCVM()
        {
            Skills = new ObservableCollection<Skill>(SkillRepository.Instance.GetAllItems().OrderBy(i => i.Title));
        }

        public void SkillsSelectionChanged()
        {
            if (SelectedSkill == null)
                return;

            Title = SelectedSkill.Title;
            Description = SelectedSkill.Description;
            Link = SelectedSkill.Link;
        }

        public void Add()
        {
            Skill item = new Skill();
            SkillRepository.Instance.SetItem(item);

            Skills.Add(item);
            SelectedSkill = item;
        }

        public void Save()
        {
            if (SelectedSkill == null)
                return;

            SelectedSkill.Title = Title;
            SelectedSkill.Description = Description;
            SelectedSkill.Link = Link;

            SkillRepository.Instance.UpdateItem(SelectedSkill);
        }

        public void Delete()
        {
            if (SelectedSkill == null)
                return;

            SkillRepository.Instance.RemoveItem(SelectedSkill);
            Skills.Remove(SelectedSkill);

            Title = "";
            Description = "";
            Link = "";
        }
    }
}
