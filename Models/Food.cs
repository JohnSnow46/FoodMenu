namespace FoodMenu.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public List<FoodMenuIngridient> FoodMenuIngridients { get; set; }
    }
}
