namespace simple_form_calculator
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
            MessageBox.Show("Hello World!!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double First = Convert.ToDouble(txtFirst.Text);
            double Second = Convert.ToDouble(txtSecond.Text);

            double result = First + Second;
            //lblResult.Text = "Result:" + result;
            txtResult.Text = result.ToString();
        }

        private void TxtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void btnSecond_Click(object sender, EventArgs e)
        {

        }

        private void btnSecond_Click_1(object sender, EventArgs e)
        {
            double First = Convert.ToDouble(txtFirst.Text);
            double Second = Convert.ToDouble(txtSecond.Text);
            double Result = First - Second;
            txtResult.Text = Result.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            double First = Convert.ToDouble(txtFirst.Text);
            double Second = Convert.ToDouble(txtSecond.Text);
            double Result = First * Second;
            txtResult.Text = Result.ToString();
        }

        private void btnFourth_Click(object sender, EventArgs e)
        {
            double First = Convert.ToDouble(txtFirst.Text);
            double Second = Convert.ToDouble(txtSecond.Text);
            double Result = First / Second;
            txtResult.Text = Result.ToString();
        }

      
    }
}
