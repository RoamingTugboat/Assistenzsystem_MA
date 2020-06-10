using System;

namespace Assistenzsystem_MA.Base.Data
{

	public class Mitarbeiterinformationen
	{

		public int Erfahrungsgrad { get; set; }

		public Mitarbeiterinformationen()
		{
			Erfahrungsgrad = 0;
		}

        public override string ToString()
        {
			return "Erfahrungsgrad:"+Erfahrungsgrad;
        }

    }

}