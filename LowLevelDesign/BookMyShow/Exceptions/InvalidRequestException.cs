namespace BookMyShow.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message)
        {
            
        }

        public InvalidRequestException(Exception ex): base(ex.Message, ex)
        {

        }


    }
}
