namespace Chart.View
{
    partial class AddNewHarmonicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectedHarmonicBox = new System.Windows.Forms.GroupBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.HarmonicStringRepresentation = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PhaseInput = new System.Windows.Forms.TextBox();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyInput = new System.Windows.Forms.TextBox();
            this.CosRadioButton = new System.Windows.Forms.RadioButton();
            this.SinRadioButton = new System.Windows.Forms.RadioButton();
            this.AmplitudeLabel = new System.Windows.Forms.Label();
            this.AmplitudeInput = new System.Windows.Forms.TextBox();
            this.SelectedHarmonicBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedHarmonicBox
            // 
            this.SelectedHarmonicBox.Controls.Add(this.OkButton);
            this.SelectedHarmonicBox.Controls.Add(this.HarmonicStringRepresentation);
            this.SelectedHarmonicBox.Controls.Add(this.CancelFormButton);
            this.SelectedHarmonicBox.Controls.Add(this.label1);
            this.SelectedHarmonicBox.Controls.Add(this.PhaseInput);
            this.SelectedHarmonicBox.Controls.Add(this.FrequencyLabel);
            this.SelectedHarmonicBox.Controls.Add(this.FrequencyInput);
            this.SelectedHarmonicBox.Controls.Add(this.CosRadioButton);
            this.SelectedHarmonicBox.Controls.Add(this.SinRadioButton);
            this.SelectedHarmonicBox.Controls.Add(this.AmplitudeLabel);
            this.SelectedHarmonicBox.Controls.Add(this.AmplitudeInput);
            this.SelectedHarmonicBox.Location = new System.Drawing.Point(12, 12);
            this.SelectedHarmonicBox.Name = "SelectedHarmonicBox";
            this.SelectedHarmonicBox.Size = new System.Drawing.Size(264, 232);
            this.SelectedHarmonicBox.TabIndex = 2;
            this.SelectedHarmonicBox.TabStop = false;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(27, 192);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // HarmonicStringRepresentation
            // 
            this.HarmonicStringRepresentation.AutoSize = true;
            this.HarmonicStringRepresentation.Location = new System.Drawing.Point(24, 163);
            this.HarmonicStringRepresentation.Name = "HarmonicStringRepresentation";
            this.HarmonicStringRepresentation.Size = new System.Drawing.Size(0, 17);
            this.HarmonicStringRepresentation.TabIndex = 9;
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Location = new System.Drawing.Point(166, 192);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 8;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Phase";
            // 
            // PhaseInput
            // 
            this.PhaseInput.Location = new System.Drawing.Point(112, 119);
            this.PhaseInput.MaxLength = 12;
            this.PhaseInput.Name = "PhaseInput";
            this.PhaseInput.Size = new System.Drawing.Size(129, 22);
            this.PhaseInput.TabIndex = 6;
            this.PhaseInput.TextChanged += new System.EventHandler(this.PhaseInput_TextChanged);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(24, 83);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(75, 17);
            this.FrequencyLabel.TabIndex = 5;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // FrequencyInput
            // 
            this.FrequencyInput.Location = new System.Drawing.Point(112, 80);
            this.FrequencyInput.MaxLength = 12;
            this.FrequencyInput.Name = "FrequencyInput";
            this.FrequencyInput.Size = new System.Drawing.Size(129, 22);
            this.FrequencyInput.TabIndex = 4;
            this.FrequencyInput.TextChanged += new System.EventHandler(this.FrequencyInput_TextChanged);
            // 
            // CosRadioButton
            // 
            this.CosRadioButton.AutoSize = true;
            this.CosRadioButton.Location = new System.Drawing.Point(188, 53);
            this.CosRadioButton.Name = "CosRadioButton";
            this.CosRadioButton.Size = new System.Drawing.Size(53, 21);
            this.CosRadioButton.TabIndex = 3;
            this.CosRadioButton.TabStop = true;
            this.CosRadioButton.Text = "Cos";
            this.CosRadioButton.UseVisualStyleBackColor = true;
            this.CosRadioButton.CheckedChanged += new System.EventHandler(this.CosRadioButton_CheckedChanged);
            // 
            // SinRadioButton
            // 
            this.SinRadioButton.AutoSize = true;
            this.SinRadioButton.Location = new System.Drawing.Point(23, 53);
            this.SinRadioButton.Name = "SinRadioButton";
            this.SinRadioButton.Size = new System.Drawing.Size(49, 21);
            this.SinRadioButton.TabIndex = 2;
            this.SinRadioButton.TabStop = true;
            this.SinRadioButton.Text = "Sin";
            this.SinRadioButton.UseVisualStyleBackColor = true;
            this.SinRadioButton.CheckedChanged += new System.EventHandler(this.SinRadioButton_CheckedChanged);
            // 
            // AmplitudeLabel
            // 
            this.AmplitudeLabel.AutoSize = true;
            this.AmplitudeLabel.Location = new System.Drawing.Point(24, 28);
            this.AmplitudeLabel.Name = "AmplitudeLabel";
            this.AmplitudeLabel.Size = new System.Drawing.Size(70, 17);
            this.AmplitudeLabel.TabIndex = 1;
            this.AmplitudeLabel.Text = "Amplitude";
            // 
            // AmplitudeInput
            // 
            this.AmplitudeInput.Location = new System.Drawing.Point(112, 25);
            this.AmplitudeInput.MaxLength = 12;
            this.AmplitudeInput.Name = "AmplitudeInput";
            this.AmplitudeInput.Size = new System.Drawing.Size(129, 22);
            this.AmplitudeInput.TabIndex = 0;
            this.AmplitudeInput.TextChanged += new System.EventHandler(this.AmplitudeInput_TextChanged);
            // 
            // AddNewHarmonicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 256);
            this.Controls.Add(this.SelectedHarmonicBox);
            this.Name = "AddNewHarmonicForm";
            this.Text = "AddNewHarmonicForm";
            this.SelectedHarmonicBox.ResumeLayout(false);
            this.SelectedHarmonicBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SelectedHarmonicBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PhaseInput;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.TextBox FrequencyInput;
        private System.Windows.Forms.RadioButton CosRadioButton;
        private System.Windows.Forms.RadioButton SinRadioButton;
        private System.Windows.Forms.Label AmplitudeLabel;
        private System.Windows.Forms.TextBox AmplitudeInput;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Label HarmonicStringRepresentation;
        private System.Windows.Forms.Button OkButton;
    }
}