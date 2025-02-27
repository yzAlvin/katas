# Coffee Machine

In this kata, the task is to implement the logic (starting from a simple class) that translates orders from customers of the coffee machine to the drink maker. Code will use the drink maker protocol to send commands to the drink maker.

## Iterations

This project starts simple and will grow in added features through the iterations. Do not read the next iteration until you have completed the current iteration (reading ahead is a no no :-)

1) First iteration: Making Drinks   
2) Second iteration: Going into business  
3) Third iteration: Extra hot  
4) Fourth iteration: Making money  
5) Fifth iteration: Running out 

----------------------------------------------------------------------

### First Iteration - Making Drinks

In this iteration, your task is to implement the logic (starting from a simple class) that translates orders from customers of the coffee machine to the drink maker. Your code will use the drink maker protocol (see below) to send commands to the drink maker.

The coffee machine can serves 3 type of drinks: tea, coffee, chocolate.

#### Requirements

* The drink maker should receive the correct instructions for my coffee / tea / chocolate order
* I want to be able to send instructions to the drink maker to add one or two sugars
* When my order contains sugar the drink maker should add a stick (touillette) with it

#### Drink maker protocol

The drink maker receives string commands from your code to make the drinks. It can also deliver info messages to the customer if ordered so. The instructions it receives follow this format:

~~~
"T:1:0" (Drink maker makes 1 tea with 1 sugar and a stick)

"H::" (Drink maker makes 1 chocolate with no sugar - and therefore no stick)

"C:2:0" (Drink maker makes 1 coffee with 2 sugars and a stick)

"M:message-content" (Drink maker forwards any message received onto the coffee machine interface for the customer to see)
~~~

#### Implementation details

You can represent the incoming order of the customer as you wish. For instance, it could be a simple POJO that contains the order details, or a simple String, try to think of the simplest thing that do the job. Complex matters will arrive soon enough, trust us.

#### Thought Process

* Coffee Machine takes in string commands, returns drink or message.

* Command will be some interface with an evaluate method, that DrinkCommand and MessageCommand implement. DrinkCommand makes a drink, MessageCommand returns a messaeg.

* DrinkType could be an enum Coffee, Tea, and HotChocolate, or separate classes that inherit from a Drink Base Class.

##### Tests

* Throw exception when command is invalid (does not start with T:, H:, C: or M:)

* Returns drinks with correct sugar and stick

* Throw exception when negative sugars is passed in

* Returns message

----------------------------------------------------------------------

### Second Iteration - Going Into Business

The coffee machine is not free anymore! One tea is 0,4 euro, a coffee is 0,6 euro, a chocolate is 0,5 euro.

The drink maker will now only make a drink if enough money is given for it

#### Requirements

* The drink maker should make the drinks only if the correct amount of money is given
* If not enough money is provided, we want to send a message to the drink maker. The message should contains at least the amount of money missing.

Remember that the drink maker forwards any message received onto the coffee machine interface for the customer to see.

If too much money is given, the drink maker will still make the drink according to the instructions. The machine will handle the return of the correct change. So do not worry about that.

You don't need to worry if there is too much money inserted. Just make sure, the minimum amount of money is set.

#### Thought Process

* I can maybe refactor the DrinkType Enum into a Coffee, HotChoc, Tea class. Maybe create a drink interface that has a price property that the drinks implement. Drink interface would have sugars and stick as properties too.

* How is money given to the machine? Going to assume it is just another variable passed in alongside the command. 

* I don't need to worry about handling change, so I won't.

##### Tests

* Generate message when not enough money provided that contains amount of money missing.

* Returns correct drinks when money is equal to cost of drink

* Returns correct drinks when money is more than cost of drink

-------------------------------------------------------------------

### Third Iteration - Extra Hot

The machine has been upgraded and the drink maker is now able to make orange juice and to deliver extra hot drinks.

#### Requirements

* I want to be able to buy a orange juice for 0,6 euro
* I want to be able to have my coffee, chocolate or tea extra hot

#### Implementation details

Here are the new protocol commands added to the new firmware of the drink maker:

~~~
"O::" (Drink maker will make one orange juice)
"Ch::" (Drink maker will make an extra hot coffee with no sugar)
"Hh:1:0" (Drink maker will make an extra hot chocolate with one sugar and a stick)
"Th:2:0" (The drink maker will make an extra hot tea with two sugar and a stick)
~~~

#### Thought Process

* Orange Juice is just another class that inherits from Drink

* Extra Hot can be another class that implements  Drink; that takes in a Drink in it's constructor, returning the drink as an extra hot drink. I think this is the decorator pattern.

* To parse the "h" I will need something like a CheckIfExtaHot method

##### Tests

* Can make orange juice

* Can make extra hot drinks, excluding orange juice

-----------------------------------------------------------

### Fourth Iteration - Making Money

The machine is becoming popular in the office. The management is eager to have daily reports of what is sold and when.

#### Requirements

* I want to be able to print a report anytime that contains: 
    * how many of each drink was sold 
    * the total amount of money earned so far.

#### Implementation details

For the reporting, you can have a repository of data with a simple data structure in memory. A simple reporting can be done by printing to the console. Of course all of that should be tested before it is written, but you know that already, don't you ? ;)


#### Thought Process

* To track how many of each drink is sold I can have a Dictionary with <key, value> pairs of <Drink, amountSold>

* To track the total amount of money earned I can iterate over the dictionary, multiplying the drink prices and the amount sold of each

##### Tests

* Can track drinks

* Can track total money earned

---------------------------------------------

### Fifth Iteration - Running Out

The users of the coffee machine are complaining that there is often shortages of water and/or milk. It takes weeks before the machine is refilled.

Your product owner wants to you to take advantage of the machine capabilities to inform the user that there is a shortage and to send a email notification to the company so that they can come and refill the machine.

#### Requirements

* When I order a drink and it can't be delivered because of a shortage, I want to see a message to the coffee machine console that indicates me the shortage and that a notification has been sent

#### Implementation details

You can take advantages of the 2 services implemented by the coffee machine:

~~~
public interface EmailNotifier {
	void notifyMissingDrink(String drink)
	}
~~~

~~~
public interface BeverageQuantityChecker {
	boolean isEmpty(String drink)
	}
~~~

Add those two services to your project and use mocking to finish your story.

#### Thought Process

* Coffee Machines will now take in an EmailNotifier and BeverageQuantityChecker object..

* When MakeDrink is called it will check that the beverage is able to be made (IsEmpty method)

* If it is empty it will send an email notification (NotifyMissingDrink method)

* To test this I can mock the object to say any drink is empty, and to check the notify method was called once.

##### Tests

* When there is a shortage of something needed for a drink (BeverageQuantityChecker.IsEmpty):
	* the coffee machine will add a message "there is not enough water or milk"
	* it will call NotifyMissingDrink on the EmailNotifier interface

-----------------------------------

### Extra Iteration - Testing Flexibility

To test how flexible my system is and to identify areas for refactoring:

* How would you implement Extra Cold?
* What if only some drinks can be extra hot and/or extra cold?
* What if only some drinks can have sugars
* <s>Drinks require Water and Milk</s>

#### Requirements

* Extra Cold drinks
* Not all drinks can be extra cold, or extra hot

#### Implementation details

* Coffee -- extra hot and extra cold and normal
* Tea -- extra hot and extra cold and normal
* Hot Chocolate -- extra hot and normal
* Orange Juice -- extra cold and normal
* Orange Juice -- can not add sugar

#### Thought Process

To implement different temperatures:

* ExtraHot and ExtraCold class that wraps Drinks
	* bad because I will be type checking and have to use an if statement in a few places
* A Temperature interface that all Drinks implement
	* not good use of interface, what methods would temperature require ? IsExtraHot, IsExtraCold? sounds bad
* ExtraHot and ExtraCold are interfaces that Drinks that can be them implement
	* IsExtraHot, IsExtraCold, respectively? same problem as above
	* reference: [c-sharp multiple inheritance](https://www.geeksforgeeks.org/c-sharp-multiple-inheritance-using-interfaces/)
* Temperature could just be an enum that all Drinks have a property of.
	* sounds simple
	* different temperatures does not lead to different behaviours **currently** so I think it will be okay, no need for any additional branching
	* No way to say that a certain drink can't be a certain temperature (oj can't be hot), unless I check the temperature being passed in inside the constructor of the drink or the commandParser?

#### Tests

* Test ExtraHot drinks
* Test normal drinks
* Test ExtraCold drinks

-----------------------------------


