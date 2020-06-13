using System;
using System.Xml.Serialization;

namespace Assistenzsystem_MA.Base.Data
{
	// XmlRoot seems unnecessary:
	//[XmlRoot("XMLRootAttribute")]

	// These following XMLIncludes are necessary so XMLSerializers can serialize and deserialize Schrittbearbeitungsinfos.
	// Without them, the serializer wouldn't understand Text2D and Bild2D datastructures.
	// Working theory: XMLSerializer doesn't understand what an abstract class is, so derivates of abstract Anleitungsmedium must be included manually.
	[XmlInclude(typeof(Text2D))]
	[XmlInclude(typeof(Bild2D))]
	public class Schrittbearbeitunginfos
	{
		public DateTime Timestamp { get; set; }
		public Mitarbeiter Mitarbeiter { get; set; }
		public Anleitung Anleitung { get; set; }
		public Anleitungsschritt Anleitungsschritt { get; set; }
		public bool VersuchErfolgreich { get; set; }
		public long ZeitSekunden { get; set; }

		public Schrittbearbeitunginfos()
		{
			// Init with minimum and null values so it's clear when this object has been filled in properly:
			Timestamp = new DateTime();
			Mitarbeiter = null;
			Anleitung = null;
			Anleitungsschritt = null;
			VersuchErfolgreich = false;
			ZeitSekunden = 0;
		}

		public bool isFilledInProperly()
		{
			return Timestamp != null && Mitarbeiter != null && Anleitung != null && Anleitungsschritt != null && ZeitSekunden >= -1;
		}

        public override string ToString()
        {
			return Timestamp+": "+Mitarbeiter+","+Anleitung + "," +Anleitungsschritt + "," + VersuchErfolgreich + "," +ZeitSekunden;
        }

		public Schrittbearbeitunginfos Copy()
        {
			var clone = new Schrittbearbeitunginfos();
			clone.Timestamp = this.Timestamp;
			clone.Mitarbeiter = this.Mitarbeiter;
			clone.Anleitung = this.Anleitung;
			clone.Anleitungsschritt = this.Anleitungsschritt;
			clone.VersuchErfolgreich = this.VersuchErfolgreich;
			clone.ZeitSekunden = this.ZeitSekunden;
			return clone;
        }

    }

}