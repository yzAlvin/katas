using System;
namespace monty_hall
{
    
    public class GetRandomNumber{
            private Random random;
            public GetRandomNumber(Random random){
                this.random = random;
            }

            public int getRandomInt(int start, int end){
                return random.Next(start, end);
            }
        }

}