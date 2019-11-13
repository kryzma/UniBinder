namespace UniBinderAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string Email { get; set; }

        public int? Age { get; set; }

        public int? Score { get; set; }

        public int? Likes { get; set; }

        public int? Dislikes { get; set; }

        public int? PeopleHelped { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Image { get; set; }
    }
}
