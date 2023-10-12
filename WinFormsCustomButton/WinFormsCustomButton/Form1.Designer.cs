namespace WinFormsCustomButton
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
            myButton1 = new MyButton();
            SuspendLayout();
            // 
            // myButton1
            // 
            myButton1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            myButton1.Location = new Point(77, 177);
            myButton1.Margin = new Padding(6, 6, 6, 6);
            myButton1.Name = "myButton1";
            myButton1.Size = new Size(578, 281);
            myButton1.TabIndex = 0;
            myButton1.Text = "myButton1";
            myButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(27F, 65F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1662, 914);
            Controls.Add(myButton1);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private MyButton myButton1;
    }
}
