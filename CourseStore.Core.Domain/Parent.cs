using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Core.Domain
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child1> Child1s { get; set; }
        public List<Child2> Child2s { get; set; }
        public List<Child3> Child3s { get; set; }
    }

    public class Child1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Child2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Child3
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
