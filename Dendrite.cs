﻿using System;
namespace demoapp
{
    public class Dendrite
    {
        public Pulse InputPulse { get; set; }

        public double SynapticWeight { get; set; }

        public bool Learnable { get; set; } = true;
    }
}
