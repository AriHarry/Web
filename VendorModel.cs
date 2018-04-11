using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class VendorModel
    {
       [Required(ErrorMessage = "MsgId Required")]
        public int MsgId { get; set; }
        [Required(ErrorMessage = "DisplayNo Required")]
        public string DisplayNo { get; set; }
        [Required(ErrorMessage = "Msg_Title Required")]
        public string Msg_Title { get; set; }
        [Required(ErrorMessage = "Full_Message Required")]
        public string Full_Message { get; set; }
        
    }
}