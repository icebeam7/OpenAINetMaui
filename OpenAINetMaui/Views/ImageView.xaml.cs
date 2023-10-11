using OpenAINetMaui.ViewModels;

namespace OpenAINetMaui.Views;

public partial class ImageView : ContentPage
{
	public ImageView(ImageViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}