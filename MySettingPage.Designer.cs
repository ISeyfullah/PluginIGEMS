namespace PluginIGEMS
{
    partial class MySettingPage
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
            propertyGrid1 = new PropertyGrid();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(12, 12);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(832, 664);
            propertyGrid1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(708, 682);
            button1.Name = "button1";
            button1.Size = new Size(136, 72);
            button1.TabIndex = 1;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(566, 682);
            button2.Name = "button2";
            button2.Size = new Size(136, 72);
            button2.TabIndex = 2;
            button2.Text = "View File";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 682);
            button3.Name = "button3";
            button3.Size = new Size(136, 72);
            button3.TabIndex = 3;
            button3.Text = "Keyboard";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MySettingPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 766);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(propertyGrid1);
            Name = "MySettingPage";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}