namespace coffee_machine
{
    public class MessageCommand : IMachineCommand
    {
        public string Message {get;}
        
        public MessageCommand(string message)
        {
            Message = message;
        }
    }
}