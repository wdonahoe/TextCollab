using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextCollab.Models {

    public class TextSlice {
        
        public int id { get; set; }

        [ForeignKey("textID")]
        [Column("text_id")]
        public int textID { get; set; }

        public Text text { get; set; }

        public int startIndex { get; set; }

        public int length { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }

    }
}