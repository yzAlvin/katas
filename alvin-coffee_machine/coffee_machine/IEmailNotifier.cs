using System;
namespace coffee_machine
{
    public interface IEmailNotifier 
    {
	    void NotifyMissingDrink(Drink drink);
	}
}