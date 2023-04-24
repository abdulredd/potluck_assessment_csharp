using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potluck {
    public class Dish {
        private string name;
        private string category;

        public string Name {
            get { return name; }
        }
        public string Category {
            get { return category; }
        }

        public Dish(string _name, string _category) {
            name = _name;
            category = _category;
        }

    }
}
