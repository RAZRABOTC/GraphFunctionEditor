using System.Diagnostics;
using System.Diagnostics.SymbolStore;

namespace GraphFunctionEditor
{
    public partial class Form1 : Form
    {
        private Scene scene;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(0.1f, 20, splitContainer1.Panel1.Width / 20);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void OnChangeColorButtonClick(object sender, EventArgs e)
        {
            Button selected = sender as Button;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine((selected.Parent as FlowLayoutPanel).Controls[1].Text.TrimStart('I', 'D', ':', ' '));
                scene.GraphFunctions[(selected.Parent as FlowLayoutPanel).Controls[1].Text.TrimStart('I', 'D', ':', ' ')].Color = colorDialog.Color;
                selected.BackColor = colorDialog.Color;
                splitContainer1.Panel1.Invalidate();
            }
        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            scene.DrawScene(e.Graphics, new Pen(Color.FromArgb(45, 34, 64)));
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GraphFunctionFormulaTextBox.Text))
            {
                scene.AddGraphFunction(GraphFunctionFormulaTextBox.Text, GraphFunctionsFlowLayoutPanel);
                splitContainer1.Panel1.Invalidate();
            }
        }

        private void AddLabelText_Click(object sender, EventArgs e)
        {
            AddButtonClick(AddButton, e);
        }
    }
}
