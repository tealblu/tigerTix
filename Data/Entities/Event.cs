namespace TigerTix.Web.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string date { get; set; }
        public string venue { get; set; }
        public string owner { get; set; }
    }
}
