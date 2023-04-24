namespace Potluck.Tests {
    public class DishTests {
        [Fact]
        public void ExistsWithAttributes() {
            Dish dish = new Dish("Couscous Salad", "appetizer");

            Assert.IsType<Dish>(dish);
            Assert.Equal("Couscous Salad", dish.Name);
            Assert.Equal("appetizer", dish.Category);
        }
    }
}