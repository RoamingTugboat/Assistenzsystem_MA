﻿using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA
{
    class Anleitung
    {
        public string Name { get; private set; }
        public List<Anleitungsschritt> Anleitungsschritts { get; private set; }
        public int Schrittzahl
        {
            get
            {
                return Anleitungsschritts.Count;
            }
        }

        public Anleitung(string name, List<Anleitungsschritt> anleitungsschritts)
        {
            Name = name;
            Anleitungsschritts = anleitungsschritts;
        }

    }
}