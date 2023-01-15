using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class Form1 : Form
    {
        readonly Graphics graphics;
        readonly IModel model;
        readonly IController controller;
        public Form1()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            model = new Model(graphics);
            controller = new Controller(model);
            controller.EventHandler.ActiveState = controller.EventHandler.States[StateType.EmptyState];
        }
        private Color GetColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog.Color;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                controller.EventHandler.CtrlAndMouseDown(e.X, e.Y);
            }
            else
            {
                controller.EventHandler.LeftMouseDown(e.X, e.Y);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            controller.EventHandler.LeftMouseUp(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            controller.EventHandler.MouseMove(e.X, e.Y);
        }
        private void SetLineType(object sender, EventArgs e)
        {
            controller.SetTypeCreatingItem(ItemType.Line);
            controller.EventHandler.ActiveState = controller.EventHandler.States[StateType.CreateState];
        }
        private void SetRectType(object sender, EventArgs e)
        {
            controller.SetTypeCreatingItem(ItemType.Rect);
            controller.EventHandler.ActiveState = controller.EventHandler.States[StateType.CreateState];
        }
        private void MinusLineWidth(object sender, EventArgs e)
        {
            if (controller.Model.ItemProperties.lineProperties.Width > 1)
            {
                controller.Model.ItemProperties.lineProperties.Width -= 1;
                controller.Model.ItemProperties.ApplyProperties();
            }
        }
        private void PlusLineWidth(object sender, EventArgs e)
        {
            controller.Model.ItemProperties.lineProperties.Width += 1;
            controller.Model.ItemProperties.ApplyProperties();
        }
        private void SetFillColor(object sender, EventArgs e)
        {
            controller.Model.ItemProperties.fillProperties.Color = GetColor();
            controller.Model.ItemProperties.ApplyProperties();
        }
        private void SetLineColor(object sender, EventArgs e)
        {
            controller.Model.ItemProperties.lineProperties.Color = GetColor();
            controller.Model.ItemProperties.ApplyProperties();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    controller.EventHandler.Escape();
                    break;
                case Keys.Delete:
                    controller.EventHandler.Delite();
                    break;
            }
        }
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    controller.EventHandler.Escape();
                    break;
                case Keys.Delete:
                    controller.EventHandler.Delite();
                    break;
            }
        }

        private void GroupButt_Click(object sender, EventArgs e)
        {
            controller.EventHandler.Group();
        }
    }
}
