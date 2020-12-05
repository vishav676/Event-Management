﻿namespace EventManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This is users table in database.
    /// It will contains users who can access the database.
    /// It will store username along with their password.
    /// </summary>
    [Table("users")]
    public class AdminUser
    {
        /// <summary>
        /// Gets or Sets Id.
        /// This autogenerated field. and will act as primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Password { get; set; }
    }
}