namespace Assistenzsystem_MA.Base.Data
{
	public class Schrittbearbeitunginfos
	{
		public string Mitarbeitername { get; set; }
		public string Anleitungsname { get; set; }
		public string Anleitungsschrittname { get; set; }
		public int Versuchszahl { get; set; }
		public long ZeitSekunden { get; set; }

		public Schrittbearbeitunginfos()
		{
			// Init with minimum values so it's clear when this object has been filled in properly
			Mitarbeitername = "";
			Anleitungsname = "";
			Anleitungsschrittname = "";
			Versuchszahl = 1;
			ZeitSekunden = 0;
		}

		public bool isFilledInProperly()
		{
			return Mitarbeitername != "" && Anleitungsname != "" && Anleitungsschrittname != "" && Versuchszahl >= 1 && ZeitSekunden >= -1;
		}

        public override string ToString()
        {
            return Mitarbeitername+","+Anleitungsname + "," +Anleitungsschrittname + "," +Versuchszahl + "," +ZeitSekunden;
        }

    }

}