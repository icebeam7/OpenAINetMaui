using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenAINetMaui.Services;

namespace OpenAINetMaui.ViewModels
{
    public partial class ImageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string prompt;

        [ObservableProperty]
        string imageUrl;

        IOpenAIService service;

        public ImageViewModel(IOpenAIService service)
        {
            this.service = service;
        }

        [RelayCommand]
        async Task GenerateImageAsync()
        {
            if (IsBusy)
                return;

            try
            {
                ImageUrl = string.Empty;

                IsBusy = true;
                ImageUrl = await service.GenerateImage(Prompt);
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
