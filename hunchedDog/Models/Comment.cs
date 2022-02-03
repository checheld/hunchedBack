using System.ComponentModel.DataAnnotations.Schema;

namespace hunchedDogBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("Id")]  // добавил из-за ошибки миграции
        public string Title { get; set; }
        public string CreatedAt { get; set; }

        public int User_Id { get; set; }
        /* [ForeignKey("User_Id")]  // добавил из-за ошибки миграции
         public User? User { get; set; }*/


        public int Post_Id { get; set; }
        //[ForeignKey("Post_Id")]  // добавил из-за ошибки миграции
        // public Post? Post { get; set; }
    }
}
