namespace OnlineBooking.Application.Models.Email
{
    public class EmailModel
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string[] To { get; set; }

        public string[] Cc { get; set; }

        public TagReplacement[] TagReplacements { get; set; }
    }
}
