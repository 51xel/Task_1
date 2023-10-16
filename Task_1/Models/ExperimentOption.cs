using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1.Models
{
    public class ExperimentOption
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public double Probability { get; set; }
    }
}
