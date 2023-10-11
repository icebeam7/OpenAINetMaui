namespace OpenAINetMaui.Services
{
    public interface IOpenAIService
    {
        Task<string> AskQuestion(string question);
        Task<string> GenerateImage(string prompt);
    }
}
