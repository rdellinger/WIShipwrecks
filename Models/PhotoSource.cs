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
    
    public partial class PhotoSource
    {
        public PhotoSource()
        {
            this.VesselPhotos = new HashSet<VesselPhoto>();
            this.AttractionPhotos = new HashSet<AttractionPhoto>();
        }
    
        public int ID { get; set; }
        public string Source { get; set; }
        public string URL { get; set; }
    
        public virtual ICollection<VesselPhoto> VesselPhotos { get; set; }
        public virtual ICollection<AttractionPhoto> AttractionPhotos { get; set; }
    }
}
