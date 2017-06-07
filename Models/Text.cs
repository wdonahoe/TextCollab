using System;
using System.Collections.Generic;

namespace TextCollab.Models {

    public class Text {

        public int id { get; set; }
        public string text { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }

        public virtual ICollection<TextSlice> TextSlices { get; set; }

    }

}