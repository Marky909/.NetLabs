namespace simple_calulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double first = Convert.ToDouble(txtFirst.Text);
            double second = Convert.ToDouble(txtSecond.Text);

            double result = first + second;

            txtResult.Text = result.ToString();
        }

        private void btnSecond_Click_1(object sender, EventArgs e)
        {
            double first = Convert.ToDouble(txtFirst.Text);
            double second = Convert.ToDouble(txtSecond.Text);

            double result = first - second;

            txtResult.Text = result.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            double first = Convert.ToDouble(txtFirst.Text);
            double second = Convert.ToDouble(txtSecond.Text);

            double result = first * second;

            txtResult.Text = result.ToString();
        }

        private void btnFourth_Click(object sender, EventArgs e)
        {
            double first = Convert.ToDouble(txtFirst.Text);
            double second = Convert.ToDouble(txtSecond.Text);

            double result = first / second;

            txtResult.Text = result.ToString();
        }

       
    }
}
