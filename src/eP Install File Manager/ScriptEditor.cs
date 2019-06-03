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
using ePGameFramework.WindowsAPI.user32;
using ePGameFramework.WindowsAPI;

namespace eP_Install_File_Manager
{
    public partial class ScriptEditor : Form
    {
        public ScriptEditor()
        {
            InitializeComponent();
            hook.KeyDown += Hook_KeyDown;
            LineNum();
        }

        private void Hook_KeyDown(KeyEventArgs args)
        {
            if((hook.KeyPressed[(int)key.VK_RCONTROL]|| hook.KeyPressed[(int)key.VK_LCONTROL])&& hook.KeyPressed[(int)key.VK_V])
            {
                Paste();
            }
        }

        private void Llhook_callback_hook_event_kb(llhook.LLkeyboardProc keyboardProc)
        {
            Debug.Print(keyboardProc.GetKey().ToString());
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
        Hook hook = new Hook();
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
            

        }

        private void Paste()
        {
            string SourceText = Clipboard.GetText();
            int originalPosition = richTextBox1.SelectionStart;
            if (SourceText == "")
                return;
            string Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, SourceText);
            originalPosition +=  SourceText.Length;
            TextChange(Text);
            richTextBox1.SelectionStart = originalPosition;
        }

        private void TextChange(string changeText)
        {
            int line = richTextBox1.Lines.Length;
            int MaxLine = richTextBox1.Size.Height / 15;
            int rtfLine = line < MaxLine ? MaxLine : line;
            rtfLine *= 15 * 2;
            richTextBox1.Height = rtfLine;
            richTextBox1.Text = changeText;
            
        }

        private bool[] KeyPressed = new bool[131072];

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //KeyPressed[e.KeyValue] = faaaaalse;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = richTextBox1.Lines.Length+1;
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {

        }

        private void ScriptEditor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            int Line = getLine();
            //vScrollBar1.Value = Line+1;
            int MaxLine = (-(richTextBox1.Location.Y) + panel1.Size.Height) / 15;
            if (Line <= MaxLine)
                return;
            Line -= MaxLine;
            richTextBox1.Location = new Point(richTextBox1.Location.X, richTextBox1.Location.Y - (Line * 15));
            vScrollBar1.Value = -richTextBox1.Location.Y / 15;
            
        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            richTextBox1.Location = new Point(richTextBox1.Location.X, -(vScrollBar1.Value-1)*15);
        }

        private void richTextBox1_LocationChanged(object sender, EventArgs e)
        {
            LineNum();
        }

        private void LineNum()
        {

        }
    }
}
