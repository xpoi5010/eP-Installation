using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace eP_Install_File_Manager
{
    public partial class ScriptEditor : Form
    {
        public ScriptEditor()
        {
            InitializeComponent();
        }
        int off = 0;
        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel2.Size = new Size(49, panel1.Size.Height);
            richTextBox1.Height = panel1.Size.Height;
            richTextBox1.Width = panel1.Size.Width>49 ? panel1.Size.Width - 49:0;
            vScrollBar1.Location = new Point(panel1.Size.Width-20,0);
            vScrollBar1.Height = panel1.Height;
        }

        private void UpdateLine()
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private int getLine()
        {
            string selectT = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart);
            int a = Array.FindAll(selectT.ToArray(), x => x == '\n').Count();
            return a+1;
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyPressed[e.KeyValue] = true;
            if (e.KeyData == (Keys.V | Keys.Control))
            {
                Copy();
            }

        }

        private void Copy()
        {
            string a = Clipboard.GetText();
            if (a == "")
                return;
            richTextBox1.AppendText(a);
        }

        private bool[] KeyPressed = new bool[131072];

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //KeyPressed[e.KeyValue] = false;
        }
    }
}
