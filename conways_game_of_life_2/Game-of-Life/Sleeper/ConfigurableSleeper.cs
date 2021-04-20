using System.Threading;
namespace Game_of_Life
{
    public class ConfigurableSleeper : ISleeper
    {
        private int Duration;

        public ConfigurableSleeper(int duration)
        {
            this.Duration = duration;
        }

        public void Sleep()
        {
            Thread.Sleep(Duration);
        }
    }
}