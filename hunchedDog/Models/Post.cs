namespace hunchedDogBackend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }

        public int User_Id { get; set; }
       /* public User User { get; set; }*/

        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }
}
