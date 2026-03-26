namespace Client.Models
{
    public class AuthorResponseDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string bio { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string profileImageUrl { get; set; }
    }

    public class AuthorCreateDto
    {
        public string bio { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string profileImageUrl { get; set; }
    }

    public class AuthorUpdateDto
    {
        public string bio { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string profileImageUrl { get; set; }
    }
}
