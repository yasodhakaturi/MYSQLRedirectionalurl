//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analytics
{
    using System;
    using System.Collections.Generic;
    
    public partial class hitnotify
    {
        public int PK_HitNotifi { get; set; }
        public Nullable<int> LastHitId { get; set; }
        public Nullable<int> LastAckID { get; set; }
        public Nullable<System.DateTime> LastSuccHitDate { get; set; }
        public Nullable<System.DateTime> LastSucAckDate { get; set; }
        public Nullable<int> NotifyCount { get; set; }
        public Nullable<int> FK_RID { get; set; }
        public Nullable<int> FK_ClientID { get; set; }
        public Nullable<int> FK_HookID { get; set; }
    
        public virtual campaignhookurl campaignhookurl { get; set; }
    }
}