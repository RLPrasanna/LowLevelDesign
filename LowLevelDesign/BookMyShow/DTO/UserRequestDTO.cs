namespace BookMyShow.DTO
{
    public class UserRequestDTO
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
        public ErrorDTO? ErrorDTO { get; set; }
    }
}
