using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TABest.Client.Helpers;
using TABest.Client.Data;

namespace TABest.Client.ViewModels
{
    public class MainPageVM
    {
        private ObservableCollection<ProjectVM> projects;

        public MainPageVM()
        {
            this.projects = new ObservableCollection<ProjectVM>();
            this.getProjects();
        }

        private async void getProjects()
        {
            var dal = new TABestData();
            var projects = await dal.GetPopularProjects();
            var projectVMs = new List<ProjectVM>();
            foreach (var project in projects)
            {
                projectVMs.Add(new ProjectVM()
                {
                    Id = project.Id,
                    Likes = project.Likes,
                    MainImageUrl = "http://best.telerikacademy.com/images/" + project.MainImageUrl + "_high.jpg",
                    ShortDate = project.ShortDate,
                    Title = project.Title
                });
            }

            this.Projects = projectVMs;
        }

        public IEnumerable<ProjectVM> Projects
        {
            get { return this.projects; }

            set
            {
                if (this.projects == null)
                {
                    this.projects = new ObservableCollection<ProjectVM>();
                }

                this.projects.Clear();
                value.ForEach(this.projects.Add);
            }
        }
    }
}