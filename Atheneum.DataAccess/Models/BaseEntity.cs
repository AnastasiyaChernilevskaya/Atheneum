using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.DataAccess.Models
{
    [Serializable]
    public class BaseEntity
    {
        private String id;

        [Key]
        [Required]
        public String id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        public bool IncludeToFile { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }

        public Enums.LibraryType LibraryType { get; set; }
    }
}
