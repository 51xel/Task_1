namespace Task_1.Models
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<ExperimentOption> Options { get; set; } = null!;
    }
}
