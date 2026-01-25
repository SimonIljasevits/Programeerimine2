using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public class FoodRecordRepository : BaseRepository<FoodRecord>, IFoodRecordRepository
    {
        public FoodRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
