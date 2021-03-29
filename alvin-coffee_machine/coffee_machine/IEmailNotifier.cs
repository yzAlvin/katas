using System;
namespace coffee_machine
{
    public interface EmailNotifier 
    {
	    void notifyMissingDrink(String drink);
	}
}