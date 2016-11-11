﻿using System.Collections.Generic;

namespace CTL.DAL.Entities
{
    public class Faculty
    {
        public Faculty()
        {
            this.Cathedra = new HashSet<Cathedra>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Cathedra> Cathedra { get; set; }
    }
}