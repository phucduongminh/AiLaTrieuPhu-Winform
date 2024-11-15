using QuizGame.DAL;
using QuizGame.Model;

namespace QuizGame
{
    public partial class Form1 : Form
    {
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            Sound sound = new Sound();
            sound.StartIntro();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            Sound sound = new Sound();
            sound.StopIntro();
            timer1.Stop();
            Game game = new Game();
            this.Hide();
            game.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Sound sound = new Sound();
            timer1.Interval = 1000;
            counter++;
            if (counter == 33)
            {
                sound.StopIntro();
                timer1.Stop();
            }
        }
    }
}
