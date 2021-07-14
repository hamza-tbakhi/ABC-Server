using System;

namespace Domain.DTO
{
    public class UserRequestDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}
