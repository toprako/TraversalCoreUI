using EntityLayer.Concrete;

namespace TraversalCoreUI.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommad
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
