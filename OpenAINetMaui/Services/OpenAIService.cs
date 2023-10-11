using Azure;
using Azure.AI.OpenAI;
using OpenAINetMaui.Constants;

namespace OpenAINetMaui.Services
{
    public class OpenAIService : IOpenAIService
    {
        OpenAIClient client;

        public OpenAIService()
        {
            client = new OpenAIClient(
                new Uri(OpenAIConstants.AzureServer),
                new AzureKeyCredential(OpenAIConstants.AzureKey));
        }

        public async Task<string> AskQuestion(string question)
        {
            var conversationMessages = new List<ChatMessage>()
            {
                new(ChatRole.User, question),
            };

            var chatCompletionsOptions = new ChatCompletionsOptions();

            foreach (ChatMessage chatMessage in conversationMessages)
                chatCompletionsOptions.Messages.Add(chatMessage);

            var response = await client.GetChatCompletionsAsync(
                OpenAIConstants.ModelName,
                chatCompletionsOptions);

            var responses = response.Value.Choices.FirstOrDefault();
            return responses?.Message.Content;
        }

        public async Task<string> GenerateImage(string prompt)
        {
            var imageGenerationOptions =
                new ImageGenerationOptions()
                {
                    Prompt = prompt,
                    Size = ImageSize.Size256x256,
                };

            var imageGenerations = await client.GetImageGenerationsAsync(
                imageGenerationOptions);

            var imageUri = imageGenerations.Value.Data[0].Url;
            return imageUri.AbsoluteUri;
        }
    }
}
