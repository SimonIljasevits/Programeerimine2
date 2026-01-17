using System;
using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    public class FoodRecord
    { 
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime RecordDate { get; set; }
        public MealType MealType { get; set; }
        public ICollection<FoodRecordItem> FoodRecordItems { get; set; } = new List<FoodRecordItem>();
    }

    public enum MealType { Breakfast, Lunch, Dinner, Snack}
}
