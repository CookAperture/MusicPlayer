using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public class SoundControlBar : UserControl, ISoundControlBar, INotifyUI, INotifyError
    {
        private AudioMetaData ActualAudio;
        private bool Playing = false;
        private bool Paused = false;

        public event Action<AudioMetaData> onPlay;
        public event Action onPause;
        public event Action onResume;
        public event Action onNext;
        public event Action<NotificationModel> onError;

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
            onNext.Invoke();
        }

        public void Notify(NotificationModel message)
        {
            onError.Invoke(message);
        }
    }
}