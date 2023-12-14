namespace mis321_bonus_aevansmartinez
{
    public class ConnectionString
    {
        private string hostServer {get; set;}
        private string username {get; set;}
        private string password {get; set;}
        private string port {get; set;}
        private string database {get; set;}
        public string cs {get; set;}

        public ConnectionString(){
            hostServer = "d6rii63wp64rsfb5.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            username = "tq699nf13w7s3bht";
            password = "icjshw1qg3awoozq";
            port = "3306";
            database = "cs7rk5o2l4takmgb";
            cs = $"server={hostServer};user={username};database={database};port={port};password={password}";
        }
    }
}