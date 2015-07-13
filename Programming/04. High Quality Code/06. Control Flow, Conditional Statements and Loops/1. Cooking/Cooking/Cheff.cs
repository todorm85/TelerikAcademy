using Ingredients;
using Utensils;

namespace Cooking
{
    public class Cheff
    {
        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(IVegetable potato)
        {
            //...
        }

        private void Peel(IVegetable vegetable)
        {
        }

        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }
    }
}
