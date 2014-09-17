using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace PeriodicTable
{
    public class Element
    {
        public string Name { get; set; }
        public string AtomicWeight { get; set; }
        public int AtomicNumber { get; set; }
        public string OxidationStates { get; set; }
        public UnitValue BoilingPoint { get; set; }
        public string Symbol { get; set; }
        public UnitValue Density { get; set; }
        public string ElectronConfiguration { get; set; }
        public string Electronegativity { get; set; }
        public UnitValue AtomicRadius { get; set; }
        public UnitValue AtomicVolume { get; set; }
        public UnitValue SpecificHeatCapacity { get; set; }
        public string IonizationPotential { get; set; }
        public UnitValue ThermalConductivity { get; set; }
        public int[] Electrons { get; set; }
        public int Group { get; set; }
        public int Period { get; set; }
        public string NameOrigin { get; set; }

        public int Column
        {
            get
            {
                if (IsLanthanoid)
                {
                    return 3 + (AtomicNumber - 57);
                }
                if (IsActinoid)
                {
                    return 3 + (AtomicNumber - 89);
                }
                return Group;
            }
        }

        public int Row
        {
            get
            {
                return Period;
            }
        }

        public static List<Element> All
        {
            get
            {
                var json = File.ReadAllText(@"elements.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Element>>(json);
            }
        }

        public string GroupName
        {
            get
            {
                if (IsLanthanoid)
                    return "Lanthanoids";
                if (IsActinoid)
                    return "Actinoids";

                if (Group == 1)
                {
                    if (Period == 1)
                        return "Other Nonmetals";
                    else
                        return "Alkali Metals";
                }
                if (Group == 2)
                    return "Alkaline Earth Metals";
                if (Group >= 3 && Group <= 12)
                    return "Transition Metals";
                if (Group == 17)
                    return "Halogens";
                if (Group == 18)
                    return "Noble Gases";
                    
                var otherNonMetals = new int[] { 6, 7, 8, 15, 16, 34 };
                if (otherNonMetals.Contains(AtomicNumber))
                    return "Other Nonmetals";

                var metalloids = new int[] { 5, 14, 32, 33, 51, 52, 84 };
                if (metalloids.Contains(AtomicNumber))
                    return "Metalloids";

                var postTransitionMetals = new int[] { 13, 31, 49, 50, 81, 82, 83, 113, 114, 115, 116 };
                if (postTransitionMetals.Contains(AtomicNumber))
                    return "Post-transition Metals";

                return "Unknown";
            }
        }

        public bool IsLanthanoid
        {
            get
            {
                return AtomicNumber >= 57 && AtomicNumber <= 71;
            }
        }

        public bool IsActinoid
        {
            get
            {
                return AtomicNumber >= 89 && AtomicNumber <= 103;
            }
        }
    }

    public class UnitValue
    {
        public string Unit { get; set; }
        public string Value { get; set; }
    }
}

