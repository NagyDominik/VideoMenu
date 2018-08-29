using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.Core.Entity
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return Id + ". " + Title + " " + Length + "min";
        }
    }
}
