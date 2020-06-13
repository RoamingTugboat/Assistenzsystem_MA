using System;

namespace Assistenzsystem_MA.Base.Data
{

	public class Mitarbeiterinformationen
	{

		// Scale from 0-5. Tells us how experienced an assembly worker is, 0 = no experience, 5 = expert
		int erfahrungsgrad = 0;
		public int Erfahrungsgrad
		{
			get
			{
				return erfahrungsgrad;
			}
			set
			{
				if (!(0 <= value && value <= 5))
				{
					throw new Exception("Erfahrungsgrad war nicht zwischen 0 und 5 und das darf nicht passieren da Rechnungen im Programm davon ausgehen");
				}
				erfahrungsgrad = value;
			}
		}

		public Mitarbeiterinformationen()
		{
			Erfahrungsgrad = 0;
		}

        public override string ToString()
        {
			return "Erfahrungsgrad:"+Erfahrungsgrad;
        }

		public void incrementErfahrungsgrad()
		{
			// Erfahrungsgrad above 10 makes no sense, we use a scale from 0-10
			if (Erfahrungsgrad == 10)
			{
				return;
			}
			Erfahrungsgrad++;
		}

		public void decrementErfahrungsgrad()
        {
			// Erfahrungsgrad below zero makes no sense, we use a scale from 0-10
			if(Erfahrungsgrad == 0)
            {
				return;
            }
			Erfahrungsgrad--;
        }

	}

}