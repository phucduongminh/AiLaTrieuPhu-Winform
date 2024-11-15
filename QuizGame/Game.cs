using QuizGame;
using QuizGame.DAL;
using QuizGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizGame
{
    public partial class Game : Form
    {
        GameDB db = new GameDB();
        AnswerManager answerManager = new AnswerManager();
        Counters counters = new Counters();
        DialogResult dialog = new DialogResult();
        Sound sound = new Sound();

        public Game()
        {
            InitializeComponent();
            this.Size = new Size(1630, 900);
            this.Text = "Ai La Trieu Phu";
        }

        public void UpdateLabelText()
        {
            while (true)
            {
                counters.QuestionIndex = new Random().Next(1, 50);
                if ("Easy" == answerManager.ListQuestions()[counters.QuestionIndex].ToString() && counters.QuestionCount < 6)
                {
                    if (!counters.Indices.Contains(counters.QuestionIndex))
                    {
                        MessageBox.Show("Congratulations, you answered correctly!\nProceed to the next question.");
                        counters.Indices.Add(counters.QuestionIndex);
                        answerManager.UpdateCounters(counters.QuestionIndex);
                        counters.QuestionCount++;
                        lblQuestion.Text = db.Questions.ListQuestions()[counters.QuestionIndex].ToString();
                        lblA.Text = db.Answers.ListOptionA()[counters.QuestionIndex].ToString();
                        lblB.Text = db.Answers.ListOptionB()[counters.QuestionIndex].ToString();
                        lblC.Text = db.Answers.ListOptionC()[counters.QuestionIndex].ToString();
                        lblD.Text = db.Answers.ListOptionD()[counters.QuestionIndex].ToString();
                        counters.PrizeCounter++;
                        counters.Time = 0;
                        progressBar1.Value = 0;
                        break;
                    }
                }
                if ("Hard" == answerManager.ListQuestions()[counters.QuestionIndex].ToString() && counters.QuestionCount > 5)
                {
                    counters.MaxTime = 120;
                    progressBar1.Maximum = 121;
                    if (!counters.Indices.Contains(counters.QuestionIndex))
                    {
                        MessageBox.Show("Congratulations, you answered correctly!\nProceed to the next question.");
                        counters.Indices.Add(counters.QuestionIndex);
                        answerManager.UpdateCounters(counters.QuestionIndex);
                        counters.QuestionCount++;
                        lblQuestion.Text = db.Questions.ListQuestions()[counters.QuestionIndex].ToString();
                        lblA.Text = db.Answers.ListOptionA()[counters.QuestionIndex].ToString();
                        lblB.Text = db.Answers.ListOptionB()[counters.QuestionIndex].ToString();
                        lblC.Text = db.Answers.ListOptionC()[counters.QuestionIndex].ToString();
                        lblD.Text = db.Answers.ListOptionD()[counters.QuestionIndex].ToString();
                        counters.PrizeCounter++;
                        counters.Time = 0;
                        progressBar1.Value = 0;
                        break;
                    }
                    if (counters.QuestionCount == 10)
                    {
                        MessageBox.Show("Congratulations, you won 500,000 TL!!!");
                        this.Close();
                        Form1 form = new Form1();
                        form.ShowDialog();
                        break;
                    }
                }
            }
        }

        public void UpdatePrize()
        {
            counters.Labels.Add(lblPrize1);
            counters.Labels.Add(lblPrize2);
            counters.Labels.Add(lblPrize3);
            counters.Labels.Add(lblPrize4);
            counters.Labels.Add(lblPrize5);
            counters.Labels.Add(lblPrize6);
            counters.Labels.Add(lblPrize7);
            counters.Labels.Add(lblPrize8);
            counters.Labels.Add(lblPrize9);
            counters.Labels.Add(lblPrize10);
            counters.Labels[counters.PrizeCounter].BackColor = Color.Blue;
            counters.Time = 0;
            progressBar1.Value = 0;
        }

        public void WrongAnswer()
        {
            // Stop timer and ensure progress bar resets
            timer1.Stop();
            counters.Time = 0;
            progressBar1.Value = 0;

            // Display prize won message
            if (counters.QuestionCount < 3)
            {
                MessageBox.Show("Prize Won\n0 TL", "Incorrect Answer", MessageBoxButtons.OK);
            }
            else if (counters.QuestionCount >= 3 && counters.QuestionCount < 6)
            {
                MessageBox.Show("Prize Won\n1000 TL", "Incorrect Answer", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Prize Won\n10000 TL", "Incorrect Answer", MessageBoxButtons.OK);
            }

            // Open new form asynchronously and close current form
            Task.Run(() =>
            {
                Invoke((Action)(() =>
                {
                    Form1 form = new Form1();
                    form.ShowDialog();
                    Close();
                }));
            });
        }

        private void Game_Load(object sender, EventArgs e)
        {
            lblQuestion.Text = db.Questions.ListQuestions()[counters.QuestionIndex].ToString();
            lblA.Text = db.Answers.ListOptionA()[counters.QuestionIndex].ToString();
            lblB.Text = db.Answers.ListOptionB()[counters.QuestionIndex].ToString();
            lblC.Text = db.Answers.ListOptionC()[counters.QuestionIndex].ToString();
            lblD.Text = db.Answers.ListOptionD()[counters.QuestionIndex].ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 40;
            timer1.Start();
            this.Text = "Ai La Trieu Phu";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Are you sure?", "Withdraw", MessageBoxButtons.YesNo);
            if (counters.PrizeCounter == -1 && dialog == DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
            else if (counters.PrizeCounter != -1 && dialog == DialogResult.Yes)
            {
                MessageBox.Show($"Prize Won\n{counters.Labels[counters.PrizeCounter].Text}");
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Are you sure?", "A", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("A" == answerManager.ListAnswers()[counters.QuestionIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.CorrectAnswer();
                    UpdateLabelText();
                    UpdatePrize();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.WrongAnswer();
                    WrongAnswer();
                }
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Are you sure?", "B", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("B" == answerManager.ListAnswers()[counters.QuestionIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.CorrectAnswer();
                    UpdateLabelText();
                    UpdatePrize();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.WrongAnswer();
                    WrongAnswer();
                }
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Are you sure?", "C", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("C" == answerManager.ListAnswers()[counters.QuestionIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.CorrectAnswer();
                    UpdateLabelText();
                    UpdatePrize();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.WrongAnswer();
                    WrongAnswer();
                }
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Are you sure?", "D", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("D" == answerManager.ListAnswers()[counters.QuestionIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.CorrectAnswer();
                    UpdateLabelText();
                    UpdatePrize();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.WrongAnswer();
                    WrongAnswer();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Set interval explicitly
            counters.Time++;
            progressBar1.Value++;

            // Handle time up condition
            if (counters.Time >= counters.MaxTime)
            {
                timer1.Stop();
                progressBar1.Value = 0;

                string prizeMessage = counters.PrizeCounter != -1
                    ? $"Prize Won\n{counters.Labels[counters.PrizeCounter].Text}"
                    : $"Prize Won\n0";

                MessageBox.Show(prizeMessage, "Time's Up");

                Task.Run(() =>
                {
                    Invoke((Action)(() =>
                    {
                        Form1 form = new Form1();
                        form.ShowDialog();
                        Close();
                    }));
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (counters.ButtonStatus)
            {
                MessageBox.Show($"The answer might be {answerManager.ListAnswers()[counters.QuestionIndex]}.");
                counters.ButtonStatus = false;
            }
            else
            {
                MessageBox.Show("Cannot be used twice!");
            }
        }

        private void lblPrize2_Click(object sender, EventArgs e)
        {

        }
        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void lblC_Click(object sender, EventArgs e)
        {

        }

        private void lblPrize10_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
