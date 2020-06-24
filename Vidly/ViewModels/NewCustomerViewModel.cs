using System.Collections.Generic;


namespace Vidly.Models
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}