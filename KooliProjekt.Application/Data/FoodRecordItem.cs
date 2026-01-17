namespace KooliProjekt.Application.Data
{
    public class FoodRecordItem
    {
        public int Id { get; set; }
        public int FoodRecordId { get; set; }
        public FoodRecord FoodRecord { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public double Quantity { get; set; }
    }
}
