using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WIShipwrecks.Models
{
    public class AttractionMetadata
    {

        [Display(Name = "Attraction Name")]
        [Required(ErrorMessage = "Attration Name is required.")]
        public string AttractionName;

        [Display(Name = "Attraction Type")]
        public int AttractionTypeID;

        [Display(Name = "Body of Water")]
        public int BodyOfWaterID;

        [Display(Name = "Maritime Trail")]
        public int TrailID;

        [Display(Name = "Year Built")]
        [Range(0, 2100, ErrorMessage = "Enter a year.")]
        public string YearBuilt;

        [Display(Name = "Description")]
        [DisplayFormat(HtmlEncode = false)]
        public string Description;

        [Display(Name = "Nearest Address")]
        public string NearestAddress;

        [Display(Name = "Nearest City")]
        public string City;

        [Display(Name = "County")]
        public string County;

        [Display(Name = "Zip Code")]
        [Range(10000, 99999, ErrorMessage = "Enter a 5-digit zip code.")]
        public string ZipCode;

        [DefaultValue(false)]
        [Display(Name = "Open to public?")]
        public bool OpenToPublic;

        [DefaultValue(false)]
        [Display(Name = "Mooring buoy?")]
        public bool HasWHSMooringBuoy;

        [DefaultValue(false)]
        [Display(Name = "Mooring buoy in place?")]
        public bool MooringBuoyInPlace;

        [DefaultValue(false)]
        [Display(Name = "Snorkelable?")]
        public bool IsSnorkelable;

        [DefaultValue(false)]
        [Display(Name = "Dive guide?")]
        public bool HasWHSDiveGuide;

        [DefaultValue(false)]
        [Display(Name = "Trails sign?")]
        public bool HasTrailsSign;

        [DefaultValue(false)]
        [Display(Name = "Trails exhibit?")]
        public bool HasTrailsExhibit;

        [DefaultValue(false)]
        [Display(Name = "National Register?")]
        public bool IsNationalRegisterListed;

        [Display(Name = "Latitude")]
        public string Latitude;

        [Display(Name = "Latitude (Decimal)")]
        public Nullable<double> LatitudeDecimal;

        [Display(Name = "Longitude")]
        public string Longitude;

        [Display(Name = "Longitude (Decimal)")]
        public Nullable<double> LongitudeDecimal;
        
        [Display(Name = "Hide record?")]
        public bool HideRecord;

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy;

        [Display(Name = "Date Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime LastModifiedDate;

    }


    public class AttractionContactMetadata
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Contact Name is required.")]
        public string ContactName;

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string ContactPhone;

        [Display(Name = "Alt Phone Number")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string ContactPhoneAlt;

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email;

        [Display(Name = "Website")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string Website;
    }



    public class AttractionLinkMetadata
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title;

        [Display(Name = "Link")]
        [Required(ErrorMessage = "Link is required.")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string Link;
    }


    public class AttractionPhotoMetadata
    {
        [Display(Name = "Image")]
        public string Image;

        [Display(Name = "Caption")]
        public string Caption;

        [Display(Name = "Photo Source")]
        public string PhotoSourceID;

        [Display(Name = "Photo Type")]
        public string PhotoTypeID;

        [Display(Name = "Date of Photo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfPhoto;
    }

    public class AttractionTypeMetadata
    {
        [Display(Name = "Attraction Type")]
        [Required(ErrorMessage = "Attraction Type is required.")]
        public string AttractionType1;

        [Display(Name = "Display Order")]
        public string DisplayOrder;
    }

    public class BodiesOfWaterMetadata
    {
        [Display(Name = "Body of Water")]
        [Required(ErrorMessage = "Body of Water is required.")]
        public string BodyOfWater;
    }

    public class CalendarMetadata
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title;

        [Display(Name = "Description")]
        public string Description;

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date;

        [Display(Name = "URL")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string URL;
    }
    
    public class CasualtyTypeMetadata
    {
        [Display(Name = "Casualty Type")]
        [Required(ErrorMessage = "Casualty Type is required.")]
        public string CasualtyType1;
    }

    public class CurrentResearchMetadata
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title;

        [Display(Name = "Description")]
        public string Description;

        [Display(Name = "Image")]
        public string Image;

        [Display(Name = "Display Order")]
        public string DisplayOrder;
    }

    public class FeedbackMetadata
    {
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter your comments.")]
        public string Comments;

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email;

        [Display(Name = "Date")]
        //[DataType(DataType.Date)]
        public System.DateTime Date;
    }

    public class FeedbackRecipientMetadata
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email;
    }

    public class GlossaryMetadata
    {
        [Required(ErrorMessage = "Term is required.")]
        public string Term;

        [Required(ErrorMessage = "Definition is required.")]
        public string Definition;
    }

    public class HullMaterialMetadata
    {
        [Display(Name = "Hull Material")]
        [Required(ErrorMessage = "Hull Material is required.")]
        public string HullMaterial1;
    }

    public class LinkMetadata
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title;

        [Display(Name = "URL")]
        [Required(ErrorMessage = "URL is required.")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string URL;
    }

    public class NewsArticleMetadata
    {
        [Display(Name = "Newspaper")]
        public Nullable<int> NewspaperID;

        [Display(Name = "Object")]
        public string Object;

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name;

        [Display(Name = "Date of Article")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date;

        [Display(Name = "Page")]
        public string Page;

        [Display(Name = "Notes")]
        public string Notes;

        [Display(Name = "Other Spelling")]
        public string OtherSpelling;
    }

    public class NewspaperMetadata
    {
        [Display(Name = "Newspaper")]
        [Required(ErrorMessage = "Newspaper is required.")]
        public string Newspaper1;
    }

    public class OwnerManagerAgencyMetadata
    {
        [Display(Name = "Agency")]
        [Required(ErrorMessage = "Agency is required.")]
        public string OwnerManagerAgency1;

        [Display(Name = "Address")]
        public string Address;

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string Phone;
    }

    public class PhotoSourceMetadata
    {
        [Display(Name = "Source")]
        [Required(ErrorMessage = "Source is required.")]
        public string Source;

        [Display(Name = "URL")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string URL;
    }

    public class PhotoTypeMetadata
    {
        [Display(Name = "Photo Type")]
        [Required(ErrorMessage = "Photo Type is required.")]
        public string PhotoType1;
    }

    public class PropulsionTypeMetadata
    {
        [Display(Name = "Propulsion Type")]
        [Required(ErrorMessage = "Propulsion Type is required.")]
        public string PropulsionType1;
    }

    public class RigTypeMetadata
    {
        [Display(Name = "Rig Type")]
        [Required(ErrorMessage = "Rig Type is required.")]
        public string RigType1;
    }

    public class SturgeonBayStoneMetadata
    {
        [Display(Name = "Carried Sturgeon Bay Stone?")]
        [Required(ErrorMessage = "Option is required.")]
        public string SturgeonBayStone1;
    }

    public class TechnicalFieldReportMetadata
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title;

        [Display(Name = "File")]
        public string Filename;

        [Display(Name = "Display Order")]
        public Nullable<int> DisplayOrder;
    }

    public class TimeFrameMetadata
    {
        [Display(Name = "Time Frame")]
        public string TimeFrame1;

        [Display(Name = "Display Order")]
        public Nullable<int> DisplayOrder;
    }

    public class TrailMetadata
    {
        [Display(Name = "Trail Name")]
        [Required(ErrorMessage = "Trail Name is required.")]
        public string TrailName;
    }

    public class VesselMetadata
    {
        [Display(Name = "Vessel Type")]
        public int VesselTypeID;

        [Display(Name = "Vessel Name")]
        [Required(ErrorMessage = "Vessel Name is required.")]
        public string VesselName;

        [Display(Name = "ASI Number")]
        public string ASINumber;

        [Display(Name = "Casualty Type")]
        public int CasualtyTypeID;

        [Display(Name = "Casualty Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string CasualtyDate;

        [Display(Name = "Vessel Age")]
        [Range(0, 10000, ErrorMessage = "Enter a number.")]
        public int VesselAge;

        [Display(Name = "Owners")]
        public string Owners;

        [Display(Name = "Home Port")]
        public string HomePort;

        [Display(Name = "Master")]
        public string Master;

        [Display(Name = "Cargo Description")]
        public string CargoDescription;

        [Display(Name = "Lives Lost")]
        [Range(0, 100000000, ErrorMessage = "Enter a number.")]
        public string LivesLost;

        [Display(Name = "Former Names")]
        public string FormerNames;

        [Display(Name = "Registry Number")]
        [Range(0, 100000000000, ErrorMessage = "Enter a number.")]
        public string RegistryNumber;

        [Display(Name = "Location Built")]
        public string WhereBuilt;

        [Display(Name = "Builder")]
        public string Builder;

        [Display(Name = "Year Built")]
        [Range(0, 2100, ErrorMessage = "Enter a year.")]
        public string ContructionYear;

        [Display(Name = "Length")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int Length;

        [Display(Name = "Beam")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int Breadth;

        [Display(Name = "Depth of Hold")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int DepthOfHold;

        [Display(Name = "Gross Tonnage")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int GrossTonnage;

        [Display(Name = "Net Tonnage")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int NetTonnage;

        [Display(Name = "OM Tonnage")]
        public string OMTonnage;

        [Display(Name = "Hull Material")]
        public int HullMaterialID;

        [Display(Name = "Propulsion Type")]
        public int PropulsionTypeID;

        [Display(Name = "Number of Masts")]
        [Range(0, 100, ErrorMessage = "Enter a number.")]
        public int NumberOfMasts;

        [Display(Name = "Rig Type")]
        public int RigTypeID;

        [Display(Name = "Engines")]
        public string Engines;

        [Display(Name = "Boilers")]
        public string Boilers;

        [Display(Name = "Culture?")]
        public bool Culture;

        [Display(Name = "Cultural Material?")]
        public bool CulturalMaterial;

        [Display(Name = "Dating Methods")]
        public int DatingMethods;

        [Display(Name = "Survey Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SurveyDate;

        [Display(Name = "Survey PI")]
        public string SurveyPrincipleInvestigator;

        [Display(Name = "Excavated Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string ExcavatedDate;

        [Display(Name = "Excavation PI")]
        public string ExcavationPrincipleInvestigator;

        [Display(Name = "National Register Status")]
        public int NationalRegisterStatus;

        [Display(Name = "NR Status Notes")]
        public string NationalRegisterStatusNotes;

        [Display(Name = "Year Listed on NR")]
        [Range(0, 2100, ErrorMessage = "Enter a year.")]
        public int YearListedNationalRegister;

        [Display(Name = "Submerged?")]
        public bool Submerged;

        [Display(Name = "Water Depth")]
        [Range(0, 1000000, ErrorMessage = "Enter a number.")]
        public int WaterDepth;

        [Display(Name = "On Shoreline?")]
        public bool OnShoreline;

        [Display(Name = "Condition")]
        public string ConditionDescription;

        [Display(Name = "% Vessel Present")]
        public int PercentVesselPresent;

        [Display(Name = "Threatened?")]
        public bool WreckThreatened;

        [Display(Name = "Site Name")]
        public string SiteName;

        [Display(Name = "ID Accuracy")]
        public int IDAccuracy;

        [Display(Name = "Code Number")]
        public string CodeNumber;

        [Display(Name = "Body of Water")]
        public int BodyOfWaterID;

        [Display(Name = "Trail")]
        public int TrailID;

        [Display(Name = "County")]
        public string County;

        [Display(Name = "Nearest City")]
        public string NearestCity;

        [Display(Name = "PAC Number")]
        public int PACNumber;

        [Display(Name = "Location Potential")]
        public int LocationPotential;

        [Display(Name = "Dive Accessible?")]
        public bool DiveAccessible;

        [Display(Name = "NOAA Chart")]
        public int NOAAChart;

        [Display(Name = "TRS")]
        public string TRS;

        [Display(Name = "Quarter Sections")]
        public string QuarterSections;

        [Display(Name = "USGS Quad")]
        public string USGSQuad;

        [Display(Name = "Owner/Manager Agency")]
        public int OwnerManagerAgencyID;

        [Display(Name = "Sturgeon Bay Stone")]
        public string SturgeonBayStone;

        [Display(Name = "Mooring bouy?")]
        public bool HasWHSMooringBuoy;

        [DefaultValue(false)]
        [Display(Name = "Mooring buoy in place?")]
        public bool MooringBuoyInPlace;

        [Display(Name = "Hide location info?")]
        public bool HideLocationalInfo;

        [Display(Name = "Access Directions")]
        public string AccessDirections;

        [Display(Name = "Dive guide?")]
        public bool HasWHSDiveGuide;

        [Display(Name = "Chart Image File Name")]
        public string ChartImageFileName;

        [DefaultValue(false)]
        [Display(Name = "Location Known")]
        public bool LocationKnown;

        [Display(Name = "Latitude")]
        public string Latitude;

        [Display(Name = "Latitude (Decimal)")]
        public Nullable<double> LatitudeDecimal;

        [Display(Name = "Longitude")]
        public string Longitude;

        [Display(Name = "Longitude (Decimal)")]
        public Nullable<double> LongitudeDecimal;

        [Display(Name = "Featured?")]
        public bool Featured;

        [Display(Name = "Featured Photo")]
        public string FeaturedPhoto;

        [Display(Name = "Hide record?")]
        public bool HideRecord;

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy;

        [Display(Name = "Date Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime LastModifiedDate;
    }



    public class VesselHistoryMetadata
    {
        [Display(Name = "Vessel ID")]
        public Nullable<int> VesselID;

        [Display(Name = "Time Frame")]
        public Nullable<int> TimeFrame;

        [Display(Name = "Title")]
        public string Title;

        [Display(Name = "Subtitle")]
        public string Subtitle;
  
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description;
    }



    public class VesselPhotoMetadata
    {
        [Display(Name = "Image")]
        public string Image;

        [Display(Name = "Caption")]
        public string Caption;

        [Display(Name = "Photo Source")]
        public string PhotoSourceID;

        [Display(Name = "Photo Type")]
        public string PhotoTypeID;

        [Display(Name = "Date of Photo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfPhoto;
    }

    public class VesselTypeMetadata
    {
        [Display(Name = "Vessel Type")]
        [Required(ErrorMessage = "Vessel Type is required.")]
        public string VesselType1;
    }


    public class VesselVideoMetadata
    {
        [Display(Name = "YouTube Code")]
        [Required(ErrorMessage = "YouTube Code is required.")]
        public string YouTubeCode;

        [Display(Name = "Thumbnail Image")]
        public string Thumb;

        [Display(Name = "Caption")]
        public string Caption;

        [Display(Name = "Video Source")]
        public string VideoSourceID;

        [Display(Name = "Video Type")]
        public string VideoTypeID;

        [Display(Name = "Date of Video")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfVideo;
    }


    public class VideoSourceMetadata
    {
        [Display(Name = "Source")]
        [Required(ErrorMessage = "Source is required.")]
        public string Source;

        [Display(Name = "URL")]
        [Url(ErrorMessage = "Enter a valid URL, beginning with http://")]
        public string URL;
    }


    public class VideoTypeMetadata
    {
        [Display(Name = "Video Type")]
        [Required(ErrorMessage = "Video Type is required.")]
        public string VideoType1;
    }





    public partial class Vessel
    {
        [Display(Name = "Casualty Year")]
        public string CasualtyYear
        {
            get { return String.Format("{0:yyyy}", CasualtyDate); }
        }

    }

}



