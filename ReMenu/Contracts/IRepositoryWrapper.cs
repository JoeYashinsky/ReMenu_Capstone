using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IRepositoryWrapper
    {
        IFoodieRepository Foodie { get; }

        IMealRepository Meal { get; }

        IRestaurantRepository Restaurant { get; }

        void Save();
    }
}
