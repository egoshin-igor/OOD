namespace Chart.View
{
    partial class MainForm
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
            this.HarmonicsListBox = new System.Windows.Forms.GroupBox();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.HarmonicsList = new System.Windows.Forms.ListBox();
            this.SelectedHarmonicBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PhaseInput = new System.Windows.Forms.TextBox();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyInput = new System.Windows.Forms.TextBox();
            this.CosRadioButton = new System.Windows.Forms.RadioButton();
            this.SinRadioButton = new System.Windows.Forms.RadioButton();
            this.AmplitudeLabel = new System.Windows.Forms.Label();
            this.AmplitudeInput = new System.Windows.Forms.TextBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ChartTab = new System.Windows.Forms.TabPage();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TableTab = new System.Windows.Forms.TabPage();
            this.Table = new System.Windows.Forms.DataGridView();
            this.HarmonicsListBox.SuspendLayout();
            this.SelectedHarmonicBox.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.ChartTab.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.Chart ) ).BeginInit();
            this.TableTab.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.Table ) ).BeginInit();
            this.SuspendLayout();
            // 
            // HarmonicsListBox
            // 
            this.HarmonicsListBox.Controls.Add( this.DeleteSelectedButton );
            this.HarmonicsListBox.Controls.Add( this.AddNewButton );
            this.HarmonicsListBox.Controls.Add( this.HarmonicsList );
            this.HarmonicsListBox.Location = new System.Drawing.Point( 12, 12 );
            this.HarmonicsListBox.Name = "HarmonicsListBox";
            this.HarmonicsListBox.Size = new System.Drawing.Size( 273, 197 );
            this.HarmonicsListBox.TabIndex = 0;
            this.HarmonicsListBox.TabStop = false;
            this.HarmonicsListBox.Text = "Harmonics";
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Location = new System.Drawing.Point( 149, 162 );
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size( 118, 23 );
            this.DeleteSelectedButton.TabIndex = 2;
            this.DeleteSelectedButton.Text = "Delete selected";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler( this.DeleteSelectedButton_Click );
            // 
            // AddNewButton
            // 
            this.AddNewButton.Location = new System.Drawing.Point( 6, 162 );
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size( 75, 23 );
            this.AddNewButton.TabIndex = 1;
            this.AddNewButton.Text = "Add new";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler( this.AddNewButton_Click );
            // 
            // HarmonicsList
            // 
            this.HarmonicsList.DataSource = this.HarmonicsList.CustomTabOffsets;
            this.HarmonicsList.FormattingEnabled = true;
            this.HarmonicsList.ItemHeight = 16;
            this.HarmonicsList.Location = new System.Drawing.Point( 6, 40 );
            this.HarmonicsList.Name = "HarmonicsList";
            this.HarmonicsList.Size = new System.Drawing.Size( 261, 116 );
            this.HarmonicsList.TabIndex = 0;
            this.HarmonicsList.SelectedIndexChanged += new System.EventHandler( this.HarmonicsList_SelectedIndexChanged );
            // 
            // SelectedHarmonicBox
            // 
            this.SelectedHarmonicBox.Controls.Add( this.label1 );
            this.SelectedHarmonicBox.Controls.Add( this.PhaseInput );
            this.SelectedHarmonicBox.Controls.Add( this.FrequencyLabel );
            this.SelectedHarmonicBox.Controls.Add( this.FrequencyInput );
            this.SelectedHarmonicBox.Controls.Add( this.CosRadioButton );
            this.SelectedHarmonicBox.Controls.Add( this.SinRadioButton );
            this.SelectedHarmonicBox.Controls.Add( this.AmplitudeLabel );
            this.SelectedHarmonicBox.Controls.Add( this.AmplitudeInput );
            this.SelectedHarmonicBox.Location = new System.Drawing.Point( 310, 12 );
            this.SelectedHarmonicBox.Name = "SelectedHarmonicBox";
            this.SelectedHarmonicBox.Size = new System.Drawing.Size( 229, 197 );
            this.SelectedHarmonicBox.TabIndex = 1;
            this.SelectedHarmonicBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 6, 137 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 48, 17 );
            this.label1.TabIndex = 7;
            this.label1.Text = "Phase";
            // 
            // PhaseInput
            // 
            this.PhaseInput.Location = new System.Drawing.Point( 94, 134 );
            this.PhaseInput.MaxLength = 12;
            this.PhaseInput.Name = "PhaseInput";
            this.PhaseInput.Size = new System.Drawing.Size( 129, 22 );
            this.PhaseInput.TabIndex = 6;
            this.PhaseInput.TextChanged += new System.EventHandler( this.PhaseInput_TextChanged );
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point( 6, 98 );
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size( 75, 17 );
            this.FrequencyLabel.TabIndex = 5;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // FrequencyInput
            // 
            this.FrequencyInput.Location = new System.Drawing.Point( 94, 95 );
            this.FrequencyInput.MaxLength = 12;
            this.FrequencyInput.Name = "FrequencyInput";
            this.FrequencyInput.Size = new System.Drawing.Size( 129, 22 );
            this.FrequencyInput.TabIndex = 4;
            this.FrequencyInput.TextChanged += new System.EventHandler( this.FrequencyInput_TextChanged );
            // 
            // CosRadioButton
            // 
            this.CosRadioButton.AutoSize = true;
            this.CosRadioButton.Location = new System.Drawing.Point( 170, 68 );
            this.CosRadioButton.Name = "CosRadioButton";
            this.CosRadioButton.Size = new System.Drawing.Size( 53, 21 );
            this.CosRadioButton.TabIndex = 3;
            this.CosRadioButton.TabStop = true;
            this.CosRadioButton.Text = "Cos";
            this.CosRadioButton.UseVisualStyleBackColor = true;
            this.CosRadioButton.CheckedChanged += new System.EventHandler( this.CosRadioButton_CheckedChanged );
            // 
            // SinRadioButton
            // 
            this.SinRadioButton.AutoSize = true;
            this.SinRadioButton.Location = new System.Drawing.Point( 5, 68 );
            this.SinRadioButton.Name = "SinRadioButton";
            this.SinRadioButton.Size = new System.Drawing.Size( 49, 21 );
            this.SinRadioButton.TabIndex = 2;
            this.SinRadioButton.TabStop = true;
            this.SinRadioButton.Text = "Sin";
            this.SinRadioButton.UseVisualStyleBackColor = true;
            this.SinRadioButton.CheckedChanged += new System.EventHandler( this.SinRadioButton_CheckedChanged );
            // 
            // AmplitudeLabel
            // 
            this.AmplitudeLabel.AutoSize = true;
            this.AmplitudeLabel.Location = new System.Drawing.Point( 6, 43 );
            this.AmplitudeLabel.Name = "AmplitudeLabel";
            this.AmplitudeLabel.Size = new System.Drawing.Size( 70, 17 );
            this.AmplitudeLabel.TabIndex = 1;
            this.AmplitudeLabel.Text = "Amplitude";
            // 
            // AmplitudeInput
            // 
            this.AmplitudeInput.Location = new System.Drawing.Point( 94, 40 );
            this.AmplitudeInput.MaxLength = 12;
            this.AmplitudeInput.Name = "AmplitudeInput";
            this.AmplitudeInput.Size = new System.Drawing.Size( 129, 22 );
            this.AmplitudeInput.TabIndex = 0;
            this.AmplitudeInput.TextChanged += new System.EventHandler( this.AmplitudeInput_TextChanged );
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add( this.ChartTab );
            this.Tabs.Controls.Add( this.TableTab );
            this.Tabs.Location = new System.Drawing.Point( 12, 215 );
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size( 527, 263 );
            this.Tabs.TabIndex = 2;
            // 
            // ChartTab
            // 
            this.ChartTab.Controls.Add( this.Chart );
            this.ChartTab.Location = new System.Drawing.Point( 4, 25 );
            this.ChartTab.Name = "ChartTab";
            this.ChartTab.Padding = new System.Windows.Forms.Padding( 3 );
            this.ChartTab.Size = new System.Drawing.Size( 519, 234 );
            this.ChartTab.TabIndex = 0;
            this.ChartTab.Text = "Chart";
            this.ChartTab.UseVisualStyleBackColor = true;
            // 
            // Chart
            // 
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Location = new System.Drawing.Point( 3, 3 );
            this.Chart.Name = "Chart";
            this.Chart.Size = new System.Drawing.Size( 513, 228 );
            this.Chart.TabIndex = 0;
            // 
            // TableTab
            // 
            this.TableTab.Controls.Add( this.Table );
            this.TableTab.Location = new System.Drawing.Point( 4, 25 );
            this.TableTab.Name = "TableTab";
            this.TableTab.Padding = new System.Windows.Forms.Padding( 3 );
            this.TableTab.Size = new System.Drawing.Size( 519, 234 );
            this.TableTab.TabIndex = 1;
            this.TableTab.Text = "Table";
            this.TableTab.UseVisualStyleBackColor = true;
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point( 3, 3 );
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowTemplate.Height = 24;
            this.Table.Size = new System.Drawing.Size( 513, 228 );
            this.Table.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 16F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 551, 490 );
            this.Controls.Add( this.Tabs );
            this.Controls.Add( this.SelectedHarmonicBox );
            this.Controls.Add( this.HarmonicsListBox );
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.HarmonicsListBox.ResumeLayout( false );
            this.SelectedHarmonicBox.ResumeLayout( false );
            this.SelectedHarmonicBox.PerformLayout();
            this.Tabs.ResumeLayout( false );
            this.ChartTab.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.Chart ) ).EndInit();
            this.TableTab.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.Table ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox HarmonicsListBox;
        private System.Windows.Forms.ListBox HarmonicsList;
        private System.Windows.Forms.GroupBox SelectedHarmonicBox;
        private System.Windows.Forms.Label AmplitudeLabel;
        private System.Windows.Forms.TextBox AmplitudeInput;
        private System.Windows.Forms.RadioButton CosRadioButton;
        private System.Windows.Forms.RadioButton SinRadioButton;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.TextBox FrequencyInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PhaseInput;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage ChartTab;
        private System.Windows.Forms.TabPage TableTab;
        private System.Windows.Forms.Button DeleteSelectedButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.DataGridView Table;
    }
}