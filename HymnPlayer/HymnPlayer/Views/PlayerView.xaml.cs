using System;
using System.Collections.Generic;
using System.Linq;
using HymnPlayer.Data;
using HymnPlayer.Models;
using HymnPlayer.ViewModels;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HymnPlayer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ContentPage
	{
	    private readonly ISimpleAudioPlayer _player;
	    private readonly IList<Hymn> _hymns;

	    private readonly Hymn _currentSong;

	    public PlayerView ()
		{
			InitializeComponent ();
            
            Slider.Effects.Add(Effect.Resolve("CustomEffects.BrownSliderEffect"));
		}

	    public string CurrentSong => _hymns.FirstOrDefault(x => x.HymnNumber == _currentSong.HymnNumber)?.Title;

	    public PlayerView(Hymn hymn)
	    {
	        InitializeComponent();
	        Slider.Effects.Add(Effect.Resolve("CustomEffects.BrownSliderEffect"));
            var playerViewModel = new PlayerViewModel(hymn);
	        BindingContext = playerViewModel;

	        _hymns = new HymnsRepository().GetHymns;

	        _currentSong = _hymns.FirstOrDefault(x => x.Title == hymn.Title);

	        _player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

	        _player.Load($"{_currentSong.HymnNumber}.mid");

            InitializeControls();
	    }

	    private int _icon = 1;
	    private void PlayButtonClicked(object sender, EventArgs e)
	    {
	        if (_icon == 1)
	        {
	            PlayBtn.Icon = "md-pause";
	            _player.Play();
	            Slider.Maximum = _player.Duration;
	            Slider.IsEnabled = _player.CanSeek;
	            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);
	            _player.Loop = true;
                _icon = 2;
	        }
	        else
	        {
	            PlayBtn.Icon = "md-play-arrow";
                _player.Pause();
	            _icon = 1;
	        }
	    }

	    private void InitializeControls()
	    {
	        PlayBtn.Clicked += PlayButtonClicked;
	        NextBtn.Clicked += NextButtonClicked;
	        PrevBtn.Clicked += PreviousButtonClicked;
	    }

	    private void SliderPositionValueChanged(object sender, ValueChangedEventArgs e)
	    {
            if (Slider.Value != _player.Duration)
                _player.Seek(Slider.Value);
	    }

	    private bool UpdatePosition()
	    {
	        Slider.ValueChanged -= SliderPositionValueChanged;
	        Slider.Value = _player.CurrentPosition;
	        Slider.ValueChanged += SliderPositionValueChanged;

	        return _player.IsPlaying;
	    }

	    public void NextButtonClicked(object sender, EventArgs e)
	    {
	        if (_currentSong.HymnNumber < 260)
	        {
	            _currentSong.HymnNumber++;
	        }
	        else
	        {
	            _currentSong.HymnNumber = 1;
	        }

            _player.Stop();
	        _player.Load($"{_currentSong.HymnNumber}.mid");
            _player.Play();
	    }

	    public void PreviousButtonClicked(object sender, EventArgs e)
	    {
	        if (_currentSong.HymnNumber < 2)
	        {
	            _currentSong.HymnNumber = 260;
	        }
	        else
	        {
	            _currentSong.HymnNumber--;
	        }

	        _player.Stop();
	        _player.Load($"{_currentSong.HymnNumber}.mid");
	        _player.Play();
        }

	    protected override void OnDisappearing()
	    {
            _player.Stop();
	    }
	}
}