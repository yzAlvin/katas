using System.Threading;
namespace Game_of_Life
{
    public class Sleeper
    {
        public readonly int Duration;
        public Sleeper(int duration = 300) => this.Duration = duration;
        public virtual void Sleep() => Thread.Sleep(Duration);
    }
}