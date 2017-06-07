using System;
using System.ComponentModel.DataAnnotations;

namespace TextCollab.ViewModels {

    public class TextViewModel {

        [Required]
        public string text { get; set; }

        public int length { get { return text.Length; } }

    }

}