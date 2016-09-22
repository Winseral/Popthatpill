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
            Brands Brands { get; set; }
            int MaxQuantity { get; set; }
            int PackQuantity { get; set; }
            int NumberOfRepeats { get; set; }
            int SafetyNetDays { get; set; }

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
