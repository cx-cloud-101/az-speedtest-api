namespace SpeedtestApi.Models
{
    public class Speedtest
    {
        public string User { get; set; }
        public int Device { get; set; }
        public long Timestamp { get; set; }
        public string Data { get; set; }
    }
}
