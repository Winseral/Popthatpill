using Newtonsoft.Json;
using Popthatpill.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace Popthatpill.ViewModels
{
    public class PBS 
    {

        public interface GenericDrug
        {
            string Name { get; set; }
            string Code { get; set; }
            string LIName { get; set; }

        }


        public class Brands
        {
            public object Brand { get; set; }
        } 


        public class Item : GenericDrug
        {
            string Code { get; set; }

            string GenericDrug.Name { get; set; }
            string GenericDrug.Code { get; set; }

            [JsonProperty(PropertyName = "GenericDrug.LIName")]
            string GenericDrug.LIName { get; set; }
            //string Mp.ID { get; set; }
            //string Schedule.Name { get; set; }
            //string Schedule.Code { get; set; }
            Brands Brands { get; set; }
            //BodySystems BodySystems { get; set; }
            //ListingRules Listing.Rules { get; set; }
           // object MarkupCode { get; set; }
            //ItemFormStrengths FormStrengths { get; set; }
            //ItemFormStrengthLIs FormStrengthLIs { get; set; }
            // string MannerOfAdministration { get; set; }
            int MaxQuantity { get; set; }
            int PackQuantity { get; set; }
            int NumberOfRepeats { get; set; }
            //bool PrescribeAndSupplyMaximumQuantityException { get; set; }
            int SafetyNetDays { get; set; }
            //ItemDispensingFeeTypeCodes DispensingFeeTypeCodes { get; set; }
            //NoteCodes Note.Codes { get; set; }
            //RestrictionCodes Restriction.Codes { get; set; }
            // bool Restriction.StreamlinedAuthority { get; set; }
            //string Restriction.Type { get; set; }
            //ANSRestrictionCodes ANSRestriction.Codes { get; set; }
            //PrescriberGroups PrescriberGroups { get; set; }
            //object SafetyNetCounted { get; set; }
            //ItemBrandSubstitutables BrandSubstitutables { get; set; }
            //string FormStrengthLI { get; set; }
        }

        public class Items
        {
            public double version { get; set; }
            public string effective { get; set; }
            public List<Item> Item { get; set; }
        }

        public class RootObject
        {
            public Items Items { get; set; }
        }

   
    }
}
