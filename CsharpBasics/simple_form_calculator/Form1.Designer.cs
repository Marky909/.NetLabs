namespace simple_form_calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtResult = new TextBox();
            txtSecond = new TextBox();
            txtFirst = new TextBox();
            lblSecond = new Label();
            lblFisrt = new Label();
            lblResult = new Label();
            btnSecond = new Button();
            btnMultiply = new Button();
            btnFourth = new Button();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // txtResult
            // 
            txtResult.Location = new Point(190, 252);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(125, 27);
            txtResult.TabIndex = 25;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(135, 171);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(125, 27);
            txtSecond.TabIndex = 24;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(132, 91);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(125, 27);
            txtFirst.TabIndex = 23;
            // 
            // lblSecond
            // 
            lblSecond.AutoSize = true;
            lblSecond.Location = new Point(132, 148);
            lblSecond.Name = "lblSecond";
            lblSecond.Size = new Size(119, 20);
            lblSecond.TabIndex = 22;
            lblSecond.Text = "Second Number:";
            // 
            // lblFisrt
            // 
            lblFisrt.AutoSize = true;
            lblFisrt.Location = new Point(132, 68);
            lblFisrt.Name = "lblFisrt";
            lblFisrt.Size = new Size(97, 20);
            lblFisrt.TabIndex = 21;
            lblFisrt.Text = "First Number:";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(132, 252);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(52, 20);
            lblResult.TabIndex = 20;
            lblResult.Text = "Result:";
            // 
            // btnSecond
            // 
            btnSecond.Location = new Point(184, 208);
            btnSecond.Name = "btnSecond";
            btnSecond.Size = new Size(43, 29);
            btnSecond.TabIndex = 19;
            btnSecond.Text = "-";
            btnSecond.UseVisualStyleBackColor = true;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(233, 208);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(43, 29);
            btnMultiply.TabIndex = 18;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            // 
            // btnFourth
            // 
            btnFourth.Location = new Point(282, 208);
            btnFourth.Name = "btnFourth";
            btnFourth.Size = new Size(43, 29);
            btnFourth.TabIndex = 17;
            btnFourth.Text = "/";
            btnFourth.UseVisualStyleBackColor = true;
            btnFourth.Click += btnFourth_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(135, 208);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(43, 29);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtResult);
            Controls.Add(txtSecond);
            Controls.Add(txtFirst);
            Controls.Add(lblSecond);
            Controls.Add(lblFisrt);
            Controls.Add(lblResult);
            Controls.Add(btnSecond);
            Controls.Add(btnMultiply);
            Controls.Add(btnFourth);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnFourth_Click_1(object sender, EventArgs e)
        {
            private void btnFourth_Click_1(object sender, EventArgs e)
{
    // TODO: implement button action
}throw new NotImplementedException();
        }

        #endregion

        private TextBox txtResult;
        private TextBox txtSecond;
        private TextBox txtFirst;
        private Label lblSecond;
        private Label lblFisrt;
        private Label lblResult;
        private Button btnSecond;
        private Button btnMultiply;
        private Button btnFourth;
        private Button btnAdd;
    }
}
