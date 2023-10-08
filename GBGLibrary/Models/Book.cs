﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGLibrary.Models
{
    internal class Book : Document
    {
         public string Title {  get; set; }
        public string Author { get; set; }
        public string ISBN {  get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }    
    }
}