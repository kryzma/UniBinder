using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniBinderAPI.FileManager
{
    public class ImgHandler
    {
        public string ImgBase64{ get; set; }
        public string ImgPath{ get; set; }
    }
}