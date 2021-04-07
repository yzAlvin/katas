namespace coffee_machine
{
    public class MessageCommand : ICommand
    {
        public string Message {get;}
        
        public MessageCommand(string message)
        {
            Message = message;
        }

    }
}