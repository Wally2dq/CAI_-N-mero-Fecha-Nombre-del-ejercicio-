﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaIndumentaria
{
    public class SioNoException : Exception
    {
        public SioNoException(string msg) : base(msg) { }
    }
}
