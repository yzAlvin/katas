using System;
namespace coffee_machine
{
    public interface IEmailNotifier 
    {
	    void notifyMissingDrink(Drink drink);
	}
}