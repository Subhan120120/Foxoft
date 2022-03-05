﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class Sysdiagrams
    {
        public int DiagramId { get; set; }
        public string Name { get; set; }
        public int PrincipalId { get; set; }
        public int? Version { get; set; }
        public byte[] Definition { get; set; }
    }
}
