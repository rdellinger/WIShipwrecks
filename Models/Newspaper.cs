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
    
    public partial class Newspaper
    {
        public Newspaper()
        {
            this.NewsArticles = new HashSet<NewsArticle>();
        }
    
        public int ID { get; set; }
        public string Newspaper1 { get; set; }
    
        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
