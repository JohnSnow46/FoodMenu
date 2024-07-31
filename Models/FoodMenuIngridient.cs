namespace FoodMenu.Models
{
    public class FoodMenuIngridient
    {
        public int IngridientId { get; set; }
        public Ingridient Ingridient { get; set;}
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public List<Ingridient>? Ingridients { get; set; }
        public List<Food>? FoodMenus { get; set; }
    }
}
