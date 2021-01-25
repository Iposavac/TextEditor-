using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt";
            ofd.Title = "Open a file...";
            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                richTextBox1.LoadFile(ofd.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (.txt)|*.txt";
            sfd.Title = "Save file...";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sfd.FileName);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

       
        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
            
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            cutToolStripMenuItem.Enabled = richTextBox1.SelectedText.Length != 0;
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.CanUndo;
        }
    }
}
