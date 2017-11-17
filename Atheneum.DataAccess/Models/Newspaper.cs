using System;

namespace Atheneum.DataAccess.Models
{
    [Serializable]
    public class Newspaper : BaseEntity
    {
        public DateTime YearOfPublishing { get; set; }
    }
}
