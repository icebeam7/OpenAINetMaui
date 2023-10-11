using OpenAINetMaui.ViewModels;

namespace OpenAINetMaui.Views;

public partial class ChatView : ContentPage
{
	public ChatView(ChatViewModel vm)
	{
		InitializeComponent();

        this.BindingContext = vm;
    }
}