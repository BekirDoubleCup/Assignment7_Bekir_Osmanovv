using System.IO;

namespace Assignment7_Bekir_Osmanovv
{
    public partial class Form1 : Form
    {
        string[] correctAnswers = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B",
            "C", "D", "A", "D", "C", "C", "B", "D", "A" };

        string[] studentAnswers = new string[20];
        public Form1()
        {
            InitializeComponent();

        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(correctAnswers);

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                path.Text = open.FileName;
            }

            StreamReader sReader = new StreamReader(open.FileName);
            int index = 0;

            while (index < correctAnswers.Length && !sReader.EndOfStream)
            {
                studentAnswers[index] = sReader.ReadLine();
                index++;
            }
            foreach (string str in studentAnswers)
            {
                listBox1.Items.Add(str);
            }

            open_btn.Enabled = false;
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            int i = 0;
            int questionNumber = 1;
            int answersCorrect = 0;
            int answersIncorrect = 0;
            do
            {
                if (studentAnswers[i] == correctAnswers[i])
                {
                    answersCorrect++;
                }
                if (studentAnswers[i] != correctAnswers[i])
                {
                    listBox3.Items.Add(questionNumber);
                    answersIncorrect++;
                }
                i++;
                questionNumber++;
            }

            while (i != 20);
            correct_lbl.Text = answersCorrect.ToString();
            incorrect_label.Text = answersIncorrect.ToString();
            if (answersCorrect >= 15)
            {
                resultbox.Text = "U passed the exam";

            }
            if (answersCorrect < 15)
            {
                resultbox.Text = "U failed the exam";

            }

            check_btn.Enabled = false;
        }
    }
}