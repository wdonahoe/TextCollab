using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextCollab.Models {

    public class TextSlice : BaseEntity {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int id { get; set; }

        [ForeignKey("textID")]
        [Column("text_id")]
        public int textID { get; set; }

        public Text textBody { get; set; }

        public int startIndex { get; set; }

        public int length { get; set; }
        
    }
}