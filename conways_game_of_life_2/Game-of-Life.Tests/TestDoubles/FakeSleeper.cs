namespace Game_of_Life
{
    public class FakeSleeper : ISleeper
    {
        public int Calls {get; set;}

        public void Sleep()
        {
            this.Calls++;
        }
    }
}