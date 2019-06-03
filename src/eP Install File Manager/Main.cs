using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eP_Install_File_Manager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            for(int i =0;i< listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = listView1.Width / listView1.Columns.Count;
            }
        }

        private void scriptEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptEditor se = new ScriptEditor();
            se.Show();
        }
    }
}
