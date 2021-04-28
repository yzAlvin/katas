using System.Threading;
namespace Game_of_Life
{
    public class Sleeper
    { 
        public virtual void Sleep(int duration = 200) => Thread.Sleep(duration);
    }
}