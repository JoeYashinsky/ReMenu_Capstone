using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Interfaces
{
    public interface IInterfaceWrapper
    {
        IFoodieInterface Foodie { get; }

        IMealInterface Meal { get; }

        IRestaurantInterface Restaurant { get; }

        Task SaveAsync();
    }
}
