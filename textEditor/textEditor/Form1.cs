using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor 
{
    public partial class Form1 : Form
    {
        bool isSaved;
        string fileName = "";

        public Form1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            this.fileName = "";
            this.isSaved = true;
            exeRename();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void exeRename()
        {
            string name = "文本编辑器-";
            if (fileName.Equals(""))
            {
                name += "未命名";
            }
            else
            {
                name += fileName;
            }
            this.Text = name;
        }


        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.isSaved)
                this.Close();
            else
            {
                保存ToolStripMenuItem_Click(sender, e);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fileName.Equals(""))
            {
                另存为ToolStripMenuItem_Click(sender,e);
                
            }
            else
            {
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);

            }
            this.isSaved = true;
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "纯文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                this.exeRename();
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSaved)
            {
                this.isSaved = false;
                this.richTextBox1.Text = "";
                this.fileName = "";
                this.exeRename();
            }
            else
            {
                DialogResult dr = MessageBox.Show(this,
                                    "要保存当前更改吗？",
                                    "保存更改吗？",
                                    MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        保存ToolStripMenuItem_Click(sender, e);
                        isSaved = false;
                        this.fileName = "";
                        this.richTextBox1.Text = "";
                        this.exeRename();
                        break;
                    case DialogResult.No:
                        isSaved = false;
                        this.fileName = "";
                        this.richTextBox1.Text = "";
                        this.exeRename();
                        break;
                    case DialogResult.Cancel:
                        break;
                }


            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {

                DialogResult dr = MessageBox.Show(this,
                                    "要保存当前更改吗？",
                                    "保存更改吗？",
                                    MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        保存ToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return ;
                }
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                this.exeRename();
                this.isSaved = true;
            }


        }
        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = "";
            
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectAll();

        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text += DateTime.Now.ToString(); ;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("记事本应该没人不会用吧", "查看帮助");
        }

        private void 发送反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("6", "发送反馈");

        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("制作：沈宇辰\n学号：2004070239\n邮箱：s936123723@163.com", "关于记事本");
        }

        private void textChanged(object sender, EventArgs e)
        {
            this.isSaved = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
