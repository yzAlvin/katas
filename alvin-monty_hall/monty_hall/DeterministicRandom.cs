using System;
namespace monty_hall
{

    public class DeterministicRandom : Random{
            int Seed = 0;

            public DeterministicRandom(int seed) : base(){
                this.Seed = seed;
            }
            public DeterministicRandom() : base(){

            }

            public override int Next(int start, int end){
                this.Seed = start;
                return Seed;
            }
        }

}