using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public class FoodRecordItemRepository : BaseRepository<FoodRecordItem>, IFoodRecordItemRepository
    {
        public FoodRecordItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
