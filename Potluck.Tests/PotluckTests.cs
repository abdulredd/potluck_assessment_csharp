namespace Potluck.Tests {
    public class PotluckTests {
        [Fact]
        public void ExistsWithAttributes() {
            Potluck potluck = new Potluck("7-13-18");

            Assert.IsType<Potluck>(potluck);
            Assert.Equal("7-13-18", potluck.Date);
        }

        [Fact]
        public void StartsWithNoDishes() {
            Potluck potluck = new Potluck("7-13-18");

            Assert.Empty(potluck.Dishes);
        }

        [Fact]
        public void CanAddDishesToPotluck() {
            Potluck potluck = new Potluck("7-13-18");

            Dish couscousSalad = new Dish("Couscous Salad", "appetizer");
            Dish cocktailMeatballs = new Dish("Cocktail Meatballs", "entre");

            potluck.AddDish(couscousSalad);
            potluck.AddDish(cocktailMeatballs);

            List<Dish> expectedDishes = new List<Dish> { couscousSalad, cocktailMeatballs };

            Assert.Equal(expectedDishes, potluck.Dishes);
            Assert.Equal(2, potluck.Dishes.Count);
        }

        [Fact]
        public void CanGetAllDishesFromCategory() {
            Potluck potluck = new Potluck("7-13-18");

            Dish couscousSalad = new Dish("Couscous Salad", "appetizer");
            Dish summerPizza = new Dish("Summer Pizza", "appetizer");
            Dish roastPork = new Dish("Roast Pork", "entre");
            Dish cocktailMeatballs = new Dish("Cocktail Meatballs", "entre");
            Dish candySalad = new Dish("Candy Salad", "dessert");

            potluck.AddDish(couscousSalad);
            potluck.AddDish(summerPizza);
            potluck.AddDish(roastPork);
            potluck.AddDish(cocktailMeatballs);
            potluck.AddDish(candySalad);

            List<Dish> expectedAppetizerDishes = new List<Dish> { couscousSalad, summerPizza };

            Assert.Equal(expectedAppetizerDishes, potluck.GetAllFromCategory("appetizer"));
            Assert.Equal(couscousSalad, potluck.GetAllFromCategory("appetizer").First());
            Assert.Equal("Couscous Salad", potluck.GetAllFromCategory("appetizer").First().Name);
        }

        [Fact]
        public void ReturnsThePotLucksMenuAsADictionary() {
            Potluck potluck = new Potluck("7-13-18");

            Dish couscousSalad = new Dish("Couscous Salad", "appetizer");
            Dish summerPizza = new Dish("Summer Pizza", "appetizer");
            Dish roastPork = new Dish("Roast Pork", "entre");
            Dish cocktailMeatballs = new Dish("Cocktail Meatballs", "entre");
            Dish candySalad = new Dish("Candy Salad", "dessert");
            Dish beanDip = new Dish("Bean Dip", "appetizer");

            potluck.AddDish(couscousSalad);
            potluck.AddDish(summerPizza);
            potluck.AddDish(roastPork);
            potluck.AddDish(cocktailMeatballs);
            potluck.AddDish(candySalad);
            potluck.AddDish(beanDip);

            Dictionary<string, List<Dish>> expectedMenu = new Dictionary<string, List<Dish>>()
            {
                { "appetizer", new List<Dish>() { couscousSalad, summerPizza, beanDip} },
                { "entre", new List<Dish>() { roastPork, cocktailMeatballs } },
                { "dessert", new List<Dish>() { candySalad } }
            };

            Assert.Equal(expectedMenu, potluck.Menu());
        }

        [Fact]
        public void CanGetTheRatioOfDishesByCategory() {
            Potluck potluck = new Potluck("7-13-18");

            Dish couscousSalad = new Dish("Couscous Salad", "appetizer");
            Dish summerPizza = new Dish("Summer Pizza", "appetizer");
            Dish roastPork = new Dish("Roast Pork", "entre");
            Dish cocktailMeatballs = new Dish("Cocktail Meatballs", "entre");
            Dish candySalad = new Dish("Candy Salad", "dessert");
            Dish beanDip = new Dish("Bean Dip", "appetizer");

            potluck.AddDish(couscousSalad);
            potluck.AddDish(summerPizza);
            potluck.AddDish(roastPork);
            potluck.AddDish(cocktailMeatballs);
            potluck.AddDish(candySalad);
            potluck.AddDish(beanDip);

            Assert.Equal(50.0, potluck.Ratio("appetizer"));
            Assert.Equal(33.3, potluck.Ratio("entre"));
            Assert.Equal(16.7, potluck.Ratio("dessert"));
        }
    }
}
