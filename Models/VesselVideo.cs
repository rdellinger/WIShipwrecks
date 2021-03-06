//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WIShipwrecks.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VesselVideo
    {
        public int ID { get; set; }
        public int VesselID { get; set; }
        public string YouTubeCode { get; set; }
        public string Thumb { get; set; }
        public string Caption { get; set; }
        public Nullable<int> VideoSourceID { get; set; }
        public Nullable<int> VideoTypeID { get; set; }
        public Nullable<System.DateTime> DateOfVideo { get; set; }
    
        public virtual Vessel Vessel { get; set; }
        public virtual VideoSource VideoSource { get; set; }
        public virtual VideoType VideoType { get; set; }
    }
}
