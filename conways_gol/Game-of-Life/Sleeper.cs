using System.Threading;
namespace Game_of_Life
{
    public class Sleeper
    {
        public virtual void Sleep(int duration = 300) => Thread.Sleep(duration);
    }
}