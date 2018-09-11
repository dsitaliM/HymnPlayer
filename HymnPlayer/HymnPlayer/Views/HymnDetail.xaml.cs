using System;
using HymnPlayer.Models;
using HymnPlayer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HymnPlayer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HymnDetail : ContentPage
	{
	    public HymnDetail ()
		{
			InitializeComponent ();
		}

	    public HymnDetail(Hymn hymn)
	    {
	        InitializeComponent();
            var hymnDetailViewModel = new HymnDetailViewModel(hymn);
	        BindingContext = hymnDetailViewModel;
	    }

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        var hymn = new Hymn
	        {
	            Title = TitleLabel.Text
	        };
	        Navigation.PushAsync(new PlayerView(hymn));
	    }

	}
}