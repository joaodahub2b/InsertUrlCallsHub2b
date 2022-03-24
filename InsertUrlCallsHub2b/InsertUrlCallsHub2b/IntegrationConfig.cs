using System;
using System.Collections.Generic;

namespace InsertUrlCallsHub2b
{
    public partial class IntegrationConfig
    {
        public int Id { get; set; }
        public int? IdTenant { get; set; }
        public int? IdSystem { get; set; }
        public int? IdSystemResponsibility { get; set; }
        public string? Type { get; set; }
        public string UrlCall { get; set; } = null!;
        public string FrequencyTime { get; set; } = null!;
        public string FrequencyUnit { get; set; } = null!;
        public int? Enabled { get; set; }
        public string? Note { get; set; }
        public string? LastCall { get; set; }
        public int? Success { get; set; }
        public int? IdTenantSystemHasResponsibility { get; set; }
    }
}
