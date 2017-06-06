namespace TextCollab.Models {

    public class Text {

        public int id { get; set; }
        public string text { get; set; }

        public Text(int id, string text) {
            this.id = id;
            this.text = text;
        }

    }

}