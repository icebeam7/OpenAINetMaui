using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenAINetMaui.Services;

namespace OpenAINetMaui.ViewModels
{
    public partial class ChatViewModel : BaseViewModel
    {
        [ObservableProperty]
        string prompt;

        [ObservableProperty]
        string answer;

        IOpenAIService service;

        public ChatViewModel(IOpenAIService service)
        {
            this.service = service;
        }

        [RelayCommand]
        async Task AskQuestionAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Answer = string.Empty;

                IsBusy = true;
                Answer = await service.AskQuestion(Prompt);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
