using System;

namespace coffee_machine
{
    public interface IBeverageQuantityChecker 
    {
	    Boolean IsEmpty(Drink drink);
	}
}