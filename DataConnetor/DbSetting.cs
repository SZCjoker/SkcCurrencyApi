﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataConnector
{
 public  class DbSetting
    {
        public string Connection { get; set; }
        public string DbProvider { get; set; }
        public int Timeout { get; set; } = 30;
    }
}
