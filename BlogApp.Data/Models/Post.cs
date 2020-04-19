namespace BlogApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Post : CoreEntity
    {       
        [
            Required,
            MaxLength(100)
        ]
        public string Title { get; set; }
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
