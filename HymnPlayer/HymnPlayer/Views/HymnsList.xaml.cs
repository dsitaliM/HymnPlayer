using System;
using HymnPlayer.Models;
using HymnPlayer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HymnPlayer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HymnsList : ContentPage
	{
	    public HymnsList ()
		{
		    InitializeComponent ();
        }

	    private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        var vm = BindingContext as HymnListViewModel;
            vm?.SearchCommand.Execute(null);
	    }

//	    private void HymnsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
//	    {
//	        var hymnDetail = e.SelectedItem as Hymn;
//	        Navigation.PushAsync(new HymnDetail(hymnDetail));
//	    }

	    private void HymnsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var hymnDetail = e.Item as Hymn;
	        Navigation.PushAsync(new HymnDetail(hymnDetail));
	    }

	    protected override void OnAppearing()
	    {
	        HymnsListView.SelectedItem = null;
	    }
    }
}