namespace FoodMenu.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FoodMenuIngridient> FoodMenuIngridients { get; set; }
    }
}
