using NAudio.Wave;
using System;
using System.IO;

namespace QuizGame
{
    internal class Sound
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        public string FilePath { get; set; }  // Property to store the resolved file path

        private void PlaySound(string fileName)
        {
            // Resolve the full path of the audio file
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(FilePath))
            {
                // Stop and dispose of the previous playback instance
                waveOut?.Stop();
                waveOut?.Dispose();
                audioFileReader?.Dispose();

                // Create new playback instances
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader(FilePath);

                // Initialize and play the audio file
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            else
            {
                Console.WriteLine($"Error: Sound file '{fileName}' not found at {FilePath}");
            }
        }

        // Methods to play specific sounds
        public void StartIntro()
        {
            PlaySound("intro.wav");
        }

        public void StopIntro()
        {
            waveOut?.Stop();
        }

        public void CorrectAnswer()
        {
            PlaySound("correct.wav");
        }

        public void WrongAnswer()
        {
            PlaySound("wrong.wav");
        }

        public void TimeUp()
        {
            PlaySound("timesup.wav");
        }
    }
}
