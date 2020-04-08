using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data.Models
{
    public class CoreEntity : ICoreEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public CoreEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}