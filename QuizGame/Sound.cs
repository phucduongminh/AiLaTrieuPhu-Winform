using System;
using System.IO;
using NAudio.Wave;

namespace QuizGame
{
    internal class Sound
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        // Full paths for sound files
        private readonly string introSoundPath = @".\Sounds\intro.wav";
        private readonly string correctSoundPath = @".\Sounds\correct.wav";
        private readonly string wrongSoundPath = @".\Sounds\wrong.wav";
        private readonly string timeUpSoundPath = @".\Sounds\timesup.wav";

        // Method to play sound using a full file path
        private void PlaySound(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // Stop and dispose of any previous playback instances
                    waveOut?.Stop();
                    waveOut?.Dispose();
                    audioFileReader?.Dispose();

                    // Create new playback instances
                    waveOut = new WaveOutEvent();
                    audioFileReader = new AudioFileReader(filePath);

                    // Initialize and play the audio file
                    waveOut.Init(audioFileReader);
                    waveOut.Play();
                }
                else
                {
                    Console.WriteLine($"Error: Sound file not found at {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to play the sound: {ex.Message}");
            }
        }

        // Methods to play specific sounds
        public void StartIntro()
        {
            PlaySound(introSoundPath);
        }

        public void StopIntro()
        {
            waveOut?.Stop();
        }

        public void CorrectAnswer()
        {
            PlaySound(correctSoundPath);
        }

        public void WrongAnswer()
        {
            PlaySound(wrongSoundPath);
        }

        public void TimeUp()
        {
            PlaySound(timeUpSoundPath);
        }
    }
}
