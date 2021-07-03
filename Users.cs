using System;
using System.Collections.Generic;
using System.Text;

namespace StudingLINQ
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Job Job { get; set; }

        public Users(int Id, string Name, Job Job)
        {
            this.Job = Job;
            this.Name = Name;
            this.Id = Id;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Job: " + Job;
        }
    }
}
