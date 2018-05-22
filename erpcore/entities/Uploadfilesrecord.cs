using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class Uploadfilesrecord
    {
        public int Id { get; set; }
        public string Filetype { get; set; }
        public string TitleEn { get; set; }
        public string Path { get; set; }
        public string Ebayuser { get; set; }
    }
}
