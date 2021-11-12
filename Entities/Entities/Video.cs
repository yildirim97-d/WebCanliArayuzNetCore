using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Video : RecordBase
    {
        [StringLength(100)]
        public string yayinAdi { get; set; }
        [Required]
        [StringLength(350)]
        public string yayinLink { get; set; }
       
    }
}
