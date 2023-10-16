namespace Task_1.Models
{
    public class ExperimentStatistics
    {
        public string Name { get; set; } = null!;
        public int AmountOfDevices { get; set; } = 0;
        public List<ExperimentOptionStatistics> OptionStatistics { get; set; } = null!;
    }
}
