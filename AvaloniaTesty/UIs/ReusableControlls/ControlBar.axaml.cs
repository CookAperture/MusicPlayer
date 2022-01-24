using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public class SoundControlBar : UserControl, ISoundControlBar
    {
        public event ISoundControlBar.OnPlay onPlay;
        public event ISoundControlBar.OnPause onPause;
        public event ISoundControlBar.OnNext onNext;
        public event ISoundControlBar.OnResume onResume;

        AudioMetaData ActualAudio;
        bool Playing = false;
        bool Paused = false;
        ToggleButton PlayPauseButton { get; set; }

        public SoundControlBar()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;

            PlayPauseButton = this.FindControl<ToggleButton>("PlayPauseButton");
        }

        private void OnPlayPause(object sender, RoutedEventArgs args)
        {
            if (!Playing)
            {
                Playing = true;
                onPlay.Invoke(ActualAudio);
            }
            else if(!Paused)
            {
                onPause.Invoke();
                Paused = true;
            }
            else
            {
                onResume.Invoke();
                Paused = false;
            }
        }

        public void SetAudioMetaData(AudioMetaData audioMetaData)
        {
            if(Playing)
            {
                Playing = false;
                onPause.Invoke();
                PlayPauseButton.IsChecked = false;
            }
            ActualAudio = audioMetaData;
        }

        public void UpdateProgress(TimeSpan curr)
        {
            //TODO
        }

        public void IsFinished()
        {
            Playing = false;
            //onNext.Invoke();
        }
    }
}