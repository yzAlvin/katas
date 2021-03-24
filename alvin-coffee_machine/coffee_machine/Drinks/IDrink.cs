using System;
namespace coffee_machine
{
    public interface IDrink
    {

        DrinkType DrinkType {get;}
        int Sugars {get; set;}

        static decimal Price() => throw new NotImplementedException();
        bool HasStick();


        // public DrinkType DrinkType {get;}
        // public int Sugars {get;}
        // public bool HasStick {get;}

        // public Drink(DrinkType drinkType, int sugars)
        // {
        //     DrinkType = drinkType;
        //     Sugars = sugars;
        //     HasStick = sugars > 0;
        // }
    }
}