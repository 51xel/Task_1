namespace Task_1.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Result> Results { get; set; } = null!;
    }
}
