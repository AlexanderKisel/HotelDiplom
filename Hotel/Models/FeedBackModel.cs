namespace Hotel.Api.Models
{
    public class FeedbackModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsSent { get; set; }
    }
}
