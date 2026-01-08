

using System;
using System.Data;
using UserProfile.Domain.Entities;

namespace UserProfile.Data.DataMappers
{
    public static class UserProfileMapper
    {
        public static   UserProfileEntity Map(IDataRecord record)
        {
            return new UserProfileEntity
            {
                Id = Convert.ToInt32(record["UserProfileId"]),
                Status = (RecordStatus)(
                    record["UserProfileStatus"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(record["UserProfileStatus"])
                ),
                Account = record["UserProfileAccount"]?.ToString(),
                DomainName = record["UserProfileDomainName"]?.ToString(),
                DisplayName = record["UserProfileName"]?.ToString(),
                Email = record["UserProfileMailAddress"]?.ToString(),
                IsAdmin = record["UserProfileUserLevelToUserAdmin"]?.ToString() == "Y"
            };
        }
    }
}
