using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        IModel model;
        IController controller;
        public Form1()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            model = new Model(graphics);
            controller = new Controller(model);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Second Generetion
            //model.CreatingItemType = ItemType.Line;
            //model.Create(50, 50);
            #endregion

            controller.SetTypeCreatingItem(ItemType.Line);
        }

        private void GetColor(object sender, EventArgs e)
        {
            //using (ColorDialog colorDialog = new ColorDialog())
            //{
            //    if (colorDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        return colorDialog.Color;
            //    }
            //    else
            //    {
            //        return Color.Black;
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region First Generetion
            //DrawSystem painter = new DrawSystem(graphics);
            //PropSet propSet = new PropSet();
            //propSet.Add(new LineProps(Color.DarkGoldenrod));
            //Line line = new Line(new Frame(20, 20, 20, 100), propSet);
            //line.Draw(painter);
            #endregion
            #region Second Generetion

            model.CreatingItemType = ItemType.Line;

            model.ItemProperties.lineProperties = new LineProps(Color.Green, 5);
            model.ItemProperties.ApplyProperties();
            model.Create(200, 50);

            model.ItemProperties.lineProperties = new LineProps(Color.Red, 5);
            model.ItemProperties.ApplyProperties();
            model.Create(210, 50);


            model.CreatingItemType = ItemType.Rect;
            model.ItemProperties.lineProperties = new LineProps(Color.Blue, 2);
            model.ItemProperties.fillProperties = new FillProps(Color.HotPink);
            model.ItemProperties.ApplyProperties();
            model.Create(275, 220);

            #endregion


        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region First generetion (Group)
            //List<Item> objs = new List<Item>();

            //PropSet propSet = new PropSet();
            //propSet.Add(new LineProps(Color.Blue));
            //objs.Add(new Line(new Frame(300, 50, 350, 200), propSet) );

            //PropSet propSet1 = new PropSet();
            //propSet1.Add(new LineProps(Color.Red));
            //objs.Add(new Line(new Frame(305, 50, 355, 200), propSet1));

            //PropSet propSet2 = new PropSet();
            //propSet2.Add(new LineProps(Color.Green));
            //objs.Add(new Line(new Frame(310, 50, 360, 200), propSet2));

            //PropSet propSet3 = new PropSet();
            //propSet3.Add(new LineProps(Color.Black));
            //objs.Add(new Line(new Frame(315, 50, 365, 200), propSet3));

            //PropSet propSet4 = new PropSet();
            //propSet4.Add(new FillProps(Color.Yellow));
            //objs.Add(new Rect(new Frame(300, 220, 365, 250), propSet4));

            //Group group = new Group(objs);

            //DrawSystem painter = new DrawSystem(graphics);
            //group.Draw(painter);
            #endregion

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //MouseEventArgs cursor = (MouseEventArgs)e;

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            controller.eventHandler.LeftMouseUp(mouse.X, mouse.Y);
        }
    }
}
