using Assistenzsystem_MA.Base.Args;
using System;
using System.Xml.Serialization;

namespace Assistenzsystem_MA.Base.Data
{
	[XmlRoot("Schrittbearbeitungsinfos")]
	[XmlInclude(typeof(Text2D))]
	[XmlInclude(typeof(Bild2D))]
	public class Schrittbearbeitunginfos
	{
		public DateTime Timestamp { get; set; }
		public Mitarbeiter Mitarbeiter { get; set; }
		public Anleitung Anleitung { get; set; }
		public Anleitungsschritt Anleitungsschritt { get; set; }
		public int Versuchszahl { get; set; }
		public long ZeitSekunden { get; set; }

		public Schrittbearbeitunginfos()
		{
			// Init with minimum values so it's clear when this object has been filled in properly
			Timestamp = new DateTime();
			Mitarbeiter = null;
			Anleitung = null;
			Anleitungsschritt = null;
			Versuchszahl = 1;
			ZeitSekunden = 0;
		}

		public bool isFilledInProperly()
		{
			return Timestamp != null && Mitarbeiter != null && Anleitung != null && Anleitungsschritt != null && Versuchszahl >= 1 && ZeitSekunden >= -1;
		}

        public override string ToString()
        {
			return Timestamp.ToString()+": "+Mitarbeiter+","+Anleitung + "," +Anleitungsschritt + "," +Versuchszahl + "," +ZeitSekunden;
        }

		public Schrittbearbeitunginfos Copy()
        {
			var clone = new Schrittbearbeitunginfos();
			clone.Timestamp = this.Timestamp;
			clone.Mitarbeiter = this.Mitarbeiter;
			clone.Anleitung = this.Anleitung;
			clone.Anleitungsschritt = this.Anleitungsschritt;
			clone.Versuchszahl = this.Versuchszahl;
			clone.ZeitSekunden = this.ZeitSekunden;
			return clone;
        }

    }

}