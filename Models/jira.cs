using System;
namespace ApiGTT.Models
{
    public class Jira
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string proyecto { get; set; }
        public string url { get; set; }
        public string componente { get; set; }
    

        public Jira()
        {
        }
    }
}



