using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potluck {
    public class Potluck {
        private string date;
        public string Date {
            get { return date; }
        }

        private List<Dish> dishes = new List<Dish>();
        public List<Dish> Dishes {
            get { return dishes; }
        }

        public Potluck(string _date) {
            date = _date;
        }

        public void AddDish(Dish dish) {
            dishes.Add(dish);
        }

        public List<Dish> GetAllFromCategory(string category) {
            return dishes.FindAll(dish => dish.Category == category);
        }

        public Dictionary<string, List<Dish>> Menu() {
            Dictionary<string, List<Dish>> menu = new Dictionary<string, List<Dish>>();

            foreach (Dish dish in dishes) {
                if (!menu.ContainsKey(dish.Category)) {
                    menu.Add(dish.Category, new List<Dish>() { dish });
                } else {
                    menu[dish.Category].Add(dish);
                }
            }

            return menu;
        }

        public double Ratio(string category) {
            return Math.Round((double)GetAllFromCategory(category).Count / dishes.Count * 100, 1);
        }
    }
}
