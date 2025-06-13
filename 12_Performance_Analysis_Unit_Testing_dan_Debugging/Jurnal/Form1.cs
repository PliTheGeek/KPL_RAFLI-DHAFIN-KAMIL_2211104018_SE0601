namespace Modul12_2211104018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
            {
                int hasil = CariNilaiPangkat(a, b);
                label1.Text = $"Hasil: {hasil}";
            }
            else
            {
                label1.Text = "Input tidak valid!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private int CariNilaiPangkat(int a, int b)
        {
            if (b == 0)
                return 1;
            if (b < 0)
                return -1;
            if (b > 10 || a > 100)
                return -2;

            int result = 1;
            try
            {
                checked
                {
                    for (int i = 0; i < b; i++)
                    {
                        result *= a;
                    }
                }
            }
            catch (OverflowException)
            {
                return -3;
            }
            return result;
        }
    }
}
