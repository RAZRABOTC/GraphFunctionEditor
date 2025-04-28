using Dimension;
using GraphFunctions;
using System.Diagnostics;

namespace GraphFunctionEditor
{
    public class Scene
    {
        public Dictionary<string, GraphFunctionLine> GraphFunctions { get; private set; }
        private int currentId = 0;
        /// <summary>
        /// Pixel size - that is pixel size like unit, if its one then it's one as world metric
        /// </summary>
        private readonly float pixelSize;
        /// <summary>
        /// AmountOfPixelsInOneCell
        /// </summary>
        private readonly int gridCellSize;
        /// <summary>
        /// Grid cells length on x and y axises
        /// </summary>
        private readonly int gridCellsAmount;

        public Scene(float pixelSize, int gridCellSize, int gridCellsAmount)
        {
            GraphFunctions = new();
            this.pixelSize = pixelSize;
            this.gridCellsAmount = gridCellsAmount;
            this.gridCellSize = gridCellSize;
        }

        private void DrawGrid(Graphics graphics, Pen gridPen)
        {
            float length = gridCellSize * gridCellsAmount;
            for(int y = 0; y <= gridCellsAmount;y++)
            {
                graphics.DrawLine(gridPen, 0, gridCellSize * y, length, gridCellSize * y);
            }
            for (int x = 0; x <= gridCellsAmount; x++)
            {
                graphics.DrawLine(gridPen, gridCellSize * x, 0, gridCellSize *x, length);
            }
            Pen axisPen = new Pen(Color.AliceBlue, 3);
            graphics.DrawLine(axisPen, 0, length / 2, length, length / 2);
            graphics.DrawLine(axisPen, length/2, 0, length / 2, length);
        }

        public void DrawScene(Graphics graphics, Pen gridPen)
        {
            DrawGrid(graphics, gridPen);
            DrawGraphFunctions(graphics);
        }

        public void DrawGraphFunctions(Graphics graphics)
        {
            foreach (var line in GraphFunctions.Values)
            {
                line.Draw(graphics, pixelSize, gridCellSize, gridCellsAmount);
            }
        }

        public int GetId()
        {
            while (GraphFunctions.ContainsKey(currentId.ToString())) currentId++;
            return currentId;
        }

        public void AddGraphFunction(string formula, FlowLayoutPanel flowLayoutPanel)
        {
            int id = GetId();
            GraphFunctions.Add(id.ToString(), new GraphFunctionLine(new GraphFunction(formula, -gridCellSize*gridCellsAmount/20,gridCellsAmount*gridCellSize/20, 300), flowLayoutPanel, id));
        }
    }

    public class GraphFunctionLine
    {
        private GraphFunction graphFunction {get; init; }
        public Color Color { get; set; }

        public GraphFunctionLine(GraphFunction graphFunction, FlowLayoutPanel flowLayoutPanel, int id)
        {
            Color = GetRandomColor();
            this.graphFunction = graphFunction;
            flowLayoutPanel.Controls.Add(GetGraphFunctionPanel(flowLayoutPanel, id));
        }

        private Color GetRandomColor()
        {
            var random = new Random();
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        FlowLayoutPanel GetGraphFunctionPanel(FlowLayoutPanel flowLayoutPanel, int id)
        {
            Button colorButton = new Button();
            Label formulaLabel = new Label();
            Label idLabel = new Label();
            colorButton.Text = "";
            idLabel.AutoSize = true;

            idLabel.Text = "ID : " + id;
            idLabel.ForeColor = Color.FromArgb(39, 41, 54);
            formulaLabel.AutoSize = true;
            formulaLabel.Text = "Formula : " + graphFunction.Formula;
            formulaLabel.ForeColor = Color.FromArgb(39, 41, 54);
            colorButton.BackColor = Color;
            colorButton.ForeColor = Color.FromArgb(39, 41, 54);
            colorButton.Size = new(20, 20);
            colorButton.Click += (flowLayoutPanel.Parent.Parent.Parent as Form1).OnChangeColorButtonClick;
            FlowLayoutPanel graphFunctionPanel = new();
            graphFunctionPanel.FlowDirection = FlowDirection.LeftToRight;
            graphFunctionPanel.BorderStyle = BorderStyle.FixedSingle;
            graphFunctionPanel.Size = new(flowLayoutPanel.Width - 10, 30);
            graphFunctionPanel.BackColor = Color.FromArgb(219, 138, 15);
            idLabel.Margin = new Padding(graphFunctionPanel.Height - idLabel.Height);
            formulaLabel.Margin = new Padding(graphFunctionPanel.Height - formulaLabel.Height);
            colorButton.Margin = new Padding((graphFunctionPanel.Height - colorButton.Height) / 2);
            graphFunctionPanel.Controls.Add(formulaLabel);
            graphFunctionPanel.Controls.Add(idLabel);
            graphFunctionPanel.Controls.Add(colorButton);
            return graphFunctionPanel;
        }

        public void Draw(Graphics graphics, float pixelSize, int gridCellSize, int gridCellsAmount)
        {
            Debug.WriteLine(graphFunction.Points[graphFunction.Points.Length - 1]);
            Pen drawPen = new Pen(Color);
            for (int i = 1;i < graphFunction.Points.Length;i++)
            {
                Vector2 first = GetVectorPointOnGrid(graphFunction.Points[i - 1], pixelSize, gridCellSize * gridCellsAmount);
                Vector2 second = GetVectorPointOnGrid(graphFunction.Points[i], pixelSize, gridCellSize * gridCellsAmount);
                graphics.DrawLine(drawPen, first.X, first.Y, second.X, second.Y);
            }
        }

        private Vector2 GetVectorPointOnGrid(Vector2 vector, float pixelSize, int gridSize)
        {
            Vector2 temp = vector*(1/pixelSize);
            if (float.IsNaN(temp.Y)) temp.Y = 0;
            temp.Y = Math.Clamp(temp.Y, gridSize / -2, gridSize / 2);
            return new Vector2(gridSize/2 + temp.X, gridSize/2 - temp.Y);
        }
    }

}
