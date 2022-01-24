using System.Collections.Generic;

namespace RealEstate.Properties.Contracts.DTO
{
    public class ServiceError
    {
        public ICollection<string> Errors { get; set; }
    }
}
