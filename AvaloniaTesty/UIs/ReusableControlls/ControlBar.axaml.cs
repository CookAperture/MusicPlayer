﻿using Avalonia.Controls;
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

        public SoundControlBar()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnPlayPause(object sender, RoutedEventArgs args)
        {
            //onPlay?.Invoke();
            //TODO
        }

        public void SetAudioMetaData(AudioMetaData audioMetaData)
        {
            throw new System.NotImplementedException();
        }
    }
}