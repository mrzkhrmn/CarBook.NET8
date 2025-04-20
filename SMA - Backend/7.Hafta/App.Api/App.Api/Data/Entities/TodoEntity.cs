﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Data.Entities
{
    public class TodoEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(200, MinimumLength =1)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(1000, MinimumLength =5)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
