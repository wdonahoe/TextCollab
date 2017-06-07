using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextCollab.Models {

    public class Text : BaseEntity {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string textBody { get; set; }

        public virtual ICollection<TextSlice> TextSlices { get; set; }

    }

}