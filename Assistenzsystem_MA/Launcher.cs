﻿using Assistenzsystem_MA.Base;
using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA
{
    class Launcher
    {

        BackendImpl backend;

        public Launcher()
        {
            backend = new BackendImpl();
            backend.OnSendingMedia += printMedium;
            Console.WriteLine("Welcome. This program loads a default Manual (Lamellenkupplung). Available commands: listall, forward, backward, changeto <Anleitungsname>.");
            unserInputParseLoop();
        }

        void unserInputParseLoop()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "listall")
                {
                    backend.listAnleitungen();
                }
                else if (line == "forward")
                {
                    backend.flipForward();
                }
                else if (line == "backward")
                {
                    backend.flipBackward();
                }
                else if (line.StartsWith("changeto "))
                {
                    var remainingLine = line.Substring(9);
                    backend.changeAnleitung(remainingLine);
                }
                else {
                    Console.WriteLine("Can't recognize command");
                }
            }
        }

        void printMedium(object sender, MediaArgs e)
        {
            var mediaDescription = "";
            if (e.Anleitungsmedium is Text2D)
            {
                mediaDescription += (e.Anleitungsmedium as Text2D);
            }
            Console.WriteLine("Backend sent a " + e.Anleitungsmedium.GetType().Name + " Medium. " + mediaDescription);

        }

        public static void Main(string[] args)
        {
            new Launcher();
        }

    }
}
