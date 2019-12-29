using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
	public class PostConfig
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Content")]
		public string Content { get; set; }

        [Display(Name = "CountBad")]
        public int CountBad { get; set; }

        [Display(Name = "CountGood")]
        public int CountGood { get; set; }

        [Display(Name = "Tag")]
        public string Tag { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Created")]
		public DateTime Created { get; set; }
	}

	[MetadataType(typeof(PostConfig))]
	[Table("post")]
	public class Post
    {
		public Post()
		{
		}

		[Column("id")]
		public int Id { get; set; }

		[Column("title")]
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }

		[Column("content")]
		[Required(ErrorMessage = "Content is required")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Column("count_bad")]
        [Required(ErrorMessage = "CountBad is required")]
        public int CountBad { get; set; }

        [Column("count_good")]
        [Required(ErrorMessage = "CountGood is required")]
        public int CountGood { get; set; }

        [Column("tag")]
        [Required(ErrorMessage = "Tag is required")]
        public string Tag { get; set; }

        [Column("author")]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Column("created")]
		[Required(ErrorMessage = "Created is required")]
		public DateTime Created { get; set; }

        public override string ToString()
        {
            return "Post: " + Id + " " + Title;
        }

    }
}

