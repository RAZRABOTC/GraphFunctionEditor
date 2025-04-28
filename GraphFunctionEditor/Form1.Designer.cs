namespace GraphFunctionEditor
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
            splitContainer1 = new SplitContainer();
            GraphFunctionsFlowLayoutPanel = new FlowLayoutPanel();
            GraphFunctionFormulaTextBox = new TextBox();
            AddGraphFunctionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer1.Panel1.Margin = new Padding(10);
            splitContainer1.Panel1.Paint += SplitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer1.Panel2.Controls.Add(GraphFunctionsFlowLayoutPanel);
            splitContainer1.Panel2.Controls.Add(GraphFunctionFormulaTextBox);
            splitContainer1.Panel2.Controls.Add(AddGraphFunctionButton);
            splitContainer1.Panel2.Margin = new Padding(10);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1000, 500);
            splitContainer1.SplitterDistance = 565;
            splitContainer1.TabIndex = 0;
            // 
            // GraphFunctionsFlowLayoutPanel
            // 
            GraphFunctionsFlowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            GraphFunctionsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            GraphFunctionsFlowLayoutPanel.Location = new Point(16, 60);
            GraphFunctionsFlowLayoutPanel.Name = "GraphFunctionsFlowLayoutPanel";
            GraphFunctionsFlowLayoutPanel.Size = new Size(249, 399);
            GraphFunctionsFlowLayoutPanel.TabIndex = 0;
            // 
            // GraphFunctionFormulaTextBox
            // 
            GraphFunctionFormulaTextBox.Location = new Point(63, 22);
            GraphFunctionFormulaTextBox.Name = "GraphFunctionFormulaTextBox";
            GraphFunctionFormulaTextBox.Size = new Size(204, 23);
            GraphFunctionFormulaTextBox.TabIndex = 2;
            // 
            // AddGraphFunctionButton
            // 
            AddGraphFunctionButton.Location = new Point(16, 22);
            AddGraphFunctionButton.Name = "AddGraphFunctionButton";
            AddGraphFunctionButton.Size = new Size(41, 23);
            AddGraphFunctionButton.TabIndex = 1;
            AddGraphFunctionButton.Text = "Add GraphFunction";
            AddGraphFunctionButton.UseVisualStyleBackColor = true;
            AddGraphFunctionButton.Click += AddGraphFunctionButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1000, 500);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button AddGraphFunctionButton;
        private TextBox GraphFunctionFormulaTextBox;
        private FlowLayoutPanel GraphFunctionsFlowLayoutPanel;
    }
}
