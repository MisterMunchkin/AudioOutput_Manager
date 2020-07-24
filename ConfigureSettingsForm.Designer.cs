namespace AudioOutput_Manager
{
    partial class ConfigureSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AudioOutput_ListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.CycledAudioOutput_ListView = new System.Windows.Forms.ListView();
            this.AddToCycleButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AudioOutput_ListView
            // 
            this.AudioOutput_ListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.AudioOutput_ListView.HideSelection = false;
            this.AudioOutput_ListView.Location = new System.Drawing.Point(32, 37);
            this.AudioOutput_ListView.Name = "AudioOutput_ListView";
            this.AudioOutput_ListView.Size = new System.Drawing.Size(238, 376);
            this.AudioOutput_ListView.TabIndex = 0;
            this.AudioOutput_ListView.UseCompatibleStateImageBehavior = false;
            this.AudioOutput_ListView.View = System.Windows.Forms.View.List;
            this.AudioOutput_ListView.SelectedIndexChanged += new System.EventHandler(this.AudioOutput_ListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All audio playback devices";
            // 
            // CycledAudioOutput_ListView
            // 
            this.CycledAudioOutput_ListView.HideSelection = false;
            this.CycledAudioOutput_ListView.Location = new System.Drawing.Point(390, 37);
            this.CycledAudioOutput_ListView.Name = "CycledAudioOutput_ListView";
            this.CycledAudioOutput_ListView.Size = new System.Drawing.Size(217, 376);
            this.CycledAudioOutput_ListView.TabIndex = 2;
            this.CycledAudioOutput_ListView.UseCompatibleStateImageBehavior = false;
            this.CycledAudioOutput_ListView.View = System.Windows.Forms.View.List;
            // 
            // AddToCycleButton
            // 
            this.AddToCycleButton.Location = new System.Drawing.Point(293, 232);
            this.AddToCycleButton.Name = "AddToCycleButton";
            this.AddToCycleButton.Size = new System.Drawing.Size(75, 23);
            this.AddToCycleButton.TabIndex = 4;
            this.AddToCycleButton.Text = "Add to Cycle";
            this.AddToCycleButton.UseVisualStyleBackColor = true;
            this.AddToCycleButton.Click += new System.EventHandler(this.AddToCycleButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cycled audio playback devices";
            // 
            // SaveChanges
            // 
            this.SaveChanges.Location = new System.Drawing.Point(390, 420);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(145, 23);
            this.SaveChanges.TabIndex = 6;
            this.SaveChanges.Text = "Save Changes";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // ConfigureSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddToCycleButton);
            this.Controls.Add(this.CycledAudioOutput_ListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AudioOutput_ListView);
            this.Name = "ConfigureSettingsForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView AudioOutput_ListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView CycledAudioOutput_ListView;
        private System.Windows.Forms.Button AddToCycleButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveChanges;
    }
}