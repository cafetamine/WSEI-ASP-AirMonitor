namespace AirMonitor.Domain.Installation
{
    public class InstallationAddress
    {
        public long? InstallationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DisplayAddress1 { get; set; }
        public string DisplayAddress2 { get; set; }
    }
}
