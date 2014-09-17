using System;
using System.Collections.Generic;
using System.IO;

namespace PeriodicTable
{
    public class Element
    {
        public string Name { get; set; }
        public string AtomicWeight { get; set; }
        public string AtomicNumber { get; set; }
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
    }

    public class UnitValue
    {
        public string Unit { get; set; }
        public string Value { get; set; }
    }
}

