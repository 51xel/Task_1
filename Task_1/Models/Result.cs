namespace Task_1.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Experiment Experiment { get; set; } = null!;
        public ExperimentOption ResultValue { get; set; } = null!;
    }
}
