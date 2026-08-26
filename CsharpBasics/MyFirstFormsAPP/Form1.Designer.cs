namespace MyFirstFormsAPP
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
            btnAdd = new Button();
            btnFourth = new Button();
            btnMultiply = new Button();
            btnSecond = new Button();
            lblResult = new Label();
            lblFisrt = new Label();
            lblSecond = new Label();
            txtFirst = new TextBox();
            txtSecond = new TextBox();
            txtResult = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(88, 186);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(43, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnFourth
            // 
            btnFourth.Location = new Point(235, 186);
            btnFourth.Name = "btnFourth";
            btnFourth.Size = new Size(43, 29);
            btnFourth.TabIndex = 5;
            btnFourth.Text = "/";
            btnFourth.UseVisualStyleBackColor = true;
            btnFourth.Click += btnFourth_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(186, 186);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(43, 29);
            btnMultiply.TabIndex = 6;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // btnSecond
            // 
            btnSecond.Location = new Point(137, 186);
            btnSecond.Name = "btnSecond";
            btnSecond.Size = new Size(43, 29);
            btnSecond.TabIndex = 7;
            btnSecond.Text = "-";
            btnSecond.UseVisualStyleBackColor = true;
            btnSecond.Click += btnSecond_Click_1;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(85, 230);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(52, 20);
            lblResult.TabIndex = 8;
            lblResult.Text = "Result:";
            lblResult.Click += label1_Click_2;
            // 
            // lblFisrt
            // 
            lblFisrt.AutoSize = true;
            lblFisrt.Location = new Point(85, 46);
            lblFisrt.Name = "lblFisrt";
            lblFisrt.Size = new Size(97, 20);
            lblFisrt.TabIndex = 10;
            lblFisrt.Text = "First Number:";
            lblFisrt.Click += label1_Click_3;
            // 
            // lblSecond
            // 
            lblSecond.AutoSize = true;
            lblSecond.Location = new Point(85, 126);
            lblSecond.Name = "lblSecond";
            lblSecond.Size = new Size(119, 20);
            lblSecond.TabIndex = 12;
            lblSecond.Text = "Second Number:";
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(85, 69);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(125, 27);
            txtFirst.TabIndex = 13;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(88, 149);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(125, 27);
            txtSecond.TabIndex = 14;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(143, 230);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(125, 27);
            txtResult.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 450);
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

        #endregion
        private Button btnAdd;
        private Button btnFourth;
        private Button btnMultiply;
        private Button btnSecond;
        private Label lblResult;
        private Label lblFisrt;
        private Label lblSecond;
        private TextBox txtFirst;
        private TextBox txtSecond;
        private TextBox txtResult;
    }
}
