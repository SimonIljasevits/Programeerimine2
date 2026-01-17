using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EnergyKcal { get; set; }
        public decimal? FatGrams { get; set; }
        public decimal? CarbohydrateGrams { get; set; }
        public decimal? ProteinGrams { get; set; }
        public decimal? SaltGrams { get; set; }
        public ICollection<FoodRecordItem> FoodRecordItems { get; set; } = new List<FoodRecordItem>();
    }
}
