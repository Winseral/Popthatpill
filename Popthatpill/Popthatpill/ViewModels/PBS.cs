using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static Popthatpill.ViewModels.PBS;
using System.Collections.ObjectModel;

namespace Popthatpill.ViewModels
{
    class PBS
    {
        public class Brands
{
    public object Brand { get; set; }
}

public class ATC1
{
    public string Code { get; set; }
}

public class ATC2
{
    public string Code { get; set; }
}

public class ATC3
{
    public string Code { get; set; }
}

public class ATC4
{
    public string Code { get; set; }
}

public class BodySystem
{
    public string Code { get; set; }
    public string Type { get; set; }
    public string PrintOption { get; set; }
    public ATC1 ATC1 { get; set; }
    public ATC2 ATC2 { get; set; }
    public ATC3 ATC3 { get; set; }
    public ATC4 ATC4 { get; set; }
}

public class BodySystems
{
    public BodySystem BodySystem { get; set; }
}

public class ListingRule
{
    public string code { get; set; }
    
}

public class ListingRules
{
    public ListingRule Rule { get; set; }
}

public class ItemFormStrengths
{
    public string FormStrength { get; set; }
}

public class ItemFormStrengthLIs
{
    public string FormStrengthLI { get; set; }
}

public class ItemDispensingFeeTypeCodes
{
    public string DispensingFeeTypeCode { get; set; }
}

public class NoteCodes
{
    public object Code { get; set; }
}

public class RestrictionCodes
{
    public object Code { get; set; }
}

public class ANSRestrictionCodes
{
    public object Code { get; set; }
}

public class PrescriberGroups
{
    public object Code { get; set; }
}

public class ItemBrandSubstitutables
{
    public string BrandSubstitutable { get; set; }
}


public class GenericDrug
{
           
            public string Code { get; set; }
            public string LIName { get; set; }

}

public class Item
{
    public string Code { get; set; }
    public string Name { get; set; }
    //public string Code { get; set; }
    //public string Schedule.Name { get; set; }
    //public string Schedule.Code { get; set; }
    public Brands Brands { get; set; }
    public BodySystems BodySystems { get; set; }
    public ListingRules Rules { get; set; }
    public object MarkupCode { get; set; }
    public ItemFormStrengths FormStrengths { get; set; }
    public ItemFormStrengthLIs FormStrengthLIs { get; set; }
    public string MannerOfAdministration { get; set; }
    public int MaxQuantity { get; set; }
    public int PackQuantity { get; set; }
    public int NumberOfRepeats { get; set; }
    public bool PrescribeAndSupplyMaximumQuantityException { get; set; }
    public int SafetyNetDays { get; set; }
    public ItemDispensingFeeTypeCodes DispensingFeeTypeCodes { get; set; }
    public NoteCodes Codes { get; set; }
    //public RestrictionCodes Codes { get; set; }
    //public bool Restriction.StreamlinedAuthority { get; set; }
    //public string Restriction.Type { get; set; }
    //public ANSRestrictionCodes Codes { get; set; }
    public PrescriberGroups PrescriberGroups { get; set; }
    public object SafetyNetCounted { get; set; }
    public ItemBrandSubstitutables BrandSubstitutables { get; set; }
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
