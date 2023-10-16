namespace Task_1.Services.IServices
{
    public interface IExperimentService
    {
        public Task<string> TryExperimentAsync(string deviceToken, string experimentName);
    }
}
