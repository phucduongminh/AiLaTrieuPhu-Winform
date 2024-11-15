using QuizGame.DAL;
using QuizGame.Model;

namespace QuizGame
{
    public partial class Form1 : Form
    {
        Sound sound = new Sound();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            sound.StartIntro();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
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
