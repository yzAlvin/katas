using System;
namespace coffee_machine
{
    public class ExtraHot : Drink
    {
        private Drink Drink;
        
        public ExtraHot(Drink drink)
        {
            if (drink.GetType() == typeof(OrangeJuice))
            {
                throw new InvalidOperationException("Orange Juice can't be extra hot.");
            }
            this.Drink = drink;
        }

        public override decimal Price()
        {
            return this.Drink.Price();
        }

        public Drink GetDrink() => this.Drink;
    }
}