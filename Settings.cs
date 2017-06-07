namespace TextCollab {

    public class Settings {

        public DBSettings dbSettings { get; set; }
    }

    public class DBSettings {

        public string host { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int port { get; set; }

        public string connectionString {
            get {
                return $"Host={host};Port={port.ToString()};Database={name};Username={username};Password={password}";
            }
        }
    }

}