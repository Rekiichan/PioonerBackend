﻿namespace Pioneer_Backend.DataAccess
{
    public class MemberDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MembersCollectionName { get; set; } = null!;
    }
}
