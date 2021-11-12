using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class VideoModel : RecordBase
    {
        [DisplayName("Yayın Adı")]
        [StringLength(100)]
        public string yayinAdi { get; set; }
        [DisplayName("Yayın Link")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        [StringLength(350)]
        public string yayinLink { get; set; }
    }
}
