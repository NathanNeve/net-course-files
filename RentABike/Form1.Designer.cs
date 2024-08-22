namespace RentABike
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
            textBoxSerialNumber = new TextBox();
            textBoxDescription = new TextBox();
            labelDescription = new Label();
            labelSerialNumber = new Label();
            textBox3 = new TextBox();
            buttonRentABike = new Button();
            buttonReturnRentedBike = new Button();
            SuspendLayout();
            // 
            // textBoxSerialNumber
            // 
            textBoxSerialNumber.Location = new Point(121, 63);
            textBoxSerialNumber.Name = "textBoxSerialNumber";
            textBoxSerialNumber.Size = new Size(172, 27);
            textBoxSerialNumber.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(319, 63);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(271, 27);
            textBoxDescription.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(319, 40);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(117, 20);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Description Bike";
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.AutoSize = true;
            labelSerialNumber.Location = new Point(121, 40);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(104, 20);
            labelSerialNumber.TabIndex = 3;
            labelSerialNumber.Text = "Serial Number";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(121, 151);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(399, 157);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // buttonRentABike
            // 
            buttonRentABike.Location = new Point(624, 40);
            buttonRentABike.Name = "buttonRentABike";
            buttonRentABike.Size = new Size(94, 52);
            buttonRentABike.TabIndex = 5;
            buttonRentABike.Text = "Rent A Bike";
            buttonRentABike.UseVisualStyleBackColor = true;
            // 
            // buttonReturnRentedBike
            // 
            buttonReturnRentedBike.Location = new Point(565, 172);
            buttonReturnRentedBike.Name = "buttonReturnRentedBike";
            buttonReturnRentedBike.Size = new Size(126, 84);
            buttonReturnRentedBike.TabIndex = 6;
            buttonReturnRentedBike.Text = "Return Rented Bike";
            buttonReturnRentedBike.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonReturnRentedBike);
            Controls.Add(buttonRentABike);
            Controls.Add(textBox3);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxSerialNumber);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSerialNumber;
        private TextBox textBoxDescription;
        private Label labelDescription;
        private Label labelSerialNumber;
        private TextBox textBox3;
        private Button buttonRentABike;
        private Button buttonReturnRentedBike;
    }
}
