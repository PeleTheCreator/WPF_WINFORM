

namespace UserProfile.Domain.Entities
{
   
    public class UserProfileEntity
    {
        public int Id { get; set; }                  // UserProfileId
        public RecordStatus Status { get; set; }              // 0 = active, -1 = deleted
        public string Account { get; set; }          // UserProfileAccount
        public string DomainName { get; set; }       // UserProfileDomainName
        public string DisplayName { get; set; }      // UserProfileName (e.g. eu\uname01)
        public string Email { get; set; }            // UserProfileMailAddress
        public bool IsAdmin { get; set; }            // UserProfileUserLevelToUserAdmin ('Y'/'N')
    }
}
