using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManagementWPF
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStrip actualSender = (ToolStrip)sender;
            Console.WriteLine(actualSender.Name.ToString());
        }
        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(227, 239, 240)), 0, 17, tsMainMenu.Width, tsMainMenu.Height);
        }

        private void optClients_Click(object sender, EventArgs e)
        {
            openForm(sender);
        }

        private void openForm(object sender)
        {
            ToolStripMenuItem actualSender = (ToolStripMenuItem)sender;
            Type type = Type.GetType("LabManagement." + actualSender.Tag.ToString());
            Form form = (Form)Activator.CreateInstance(type);
            form.ShowDialog();
        }
    }
}
