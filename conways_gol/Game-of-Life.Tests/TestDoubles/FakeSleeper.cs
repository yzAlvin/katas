using System.Runtime.ConstrainedExecution;
namespace Game_of_Life
{
    public class FakeSleeper : Sleeper
    {
        public int Calls { get; private set; }

        public override void Sleep() => this.Calls++;
    }
}