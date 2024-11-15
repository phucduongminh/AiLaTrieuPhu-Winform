using System;
using System.Media;
using System.IO;

namespace QuizGame
{
    internal class Sound
    {
        public SoundPlayer Intro { get; set; } = new SoundPlayer();
        public string FilePath { get; set; }  // Renamed to avoid conflict with System.IO.Path

        private void PlaySound(string fileName)
        {
            FilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(FilePath))
            {
                Intro.SoundLocation = FilePath;
                Intro.Play();
            }
            else
            {
                Console.WriteLine($"Error: Sound file '{fileName}' not found at {FilePath}");
            }
        }

        public void StartIntro()
        {
            PlaySound("intro.wav");
        }

        public void StopIntro()
        {
            Intro.Stop();
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
