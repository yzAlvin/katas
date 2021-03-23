namespace coffee_machine
{
    public class ErrorCommand : IMachineCommand
    {
        public string Message {get;}

        public ErrorCommand(string errorMessage)
        {
            Message = errorMessage;
        }
    }
}