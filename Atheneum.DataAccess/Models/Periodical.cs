using System;

namespace Atheneum.DataAccess.Models
{
    [Serializable]
    public class Periodical : BaseEntity
    {
        public DateTime YearOfPublishing { get; set; }
    }
}
