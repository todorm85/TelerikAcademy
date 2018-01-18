using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School_classes
{
    public class Teacher : Human
    {
        private List<Discipline> disciplines;

        public Teacher(string name)
        {
            this.Name = name;
            this.Disciplines = new List<Discipline>();
        }

        private List<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }

        public void AddDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new NullReferenceException();
            }

            this.Disciplines.Add(discipline);
        }

        public void ViewDisciplines()
        {
            foreach (var disc in Disciplines)
            {
                Console.WriteLine(disc.Name);
            }
        }

        public void RemoveDiscipline(string name)
        {
            int indexToRemove = this.Disciplines.FindIndex(x => x.Name == name);
            this.Disciplines.RemoveAt(indexToRemove);
        }

        public void ClearDisciplines()
        {
            this.Disciplines.Clear();
        }
    }
}
