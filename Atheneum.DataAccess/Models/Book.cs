using System;

namespace Atheneum.DataAccess.Models
{
    [Serializable]
    public class Book : BaseEntity
    {
        public string Author { get; set; }
        public DateTime YearOfPublishing { get; set; }
    }
}
