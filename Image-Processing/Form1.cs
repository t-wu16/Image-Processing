using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        int picWidth, picHeight;
        string curFileName; //文件名
        Bitmap curBitmap;    //图像对象

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //保存图片
        private void savePic_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap save_pic = new Bitmap(pictureBox1.Image);
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "BMP文件(*.bmp)|*.bmp|" + "JPEG文件(*.jpg)|*.jpg|" + "PNG文件(*.png)|*.png";
                saveDlg.FilterIndex = 1;
                saveDlg.RestoreDirectory = true;
                saveDlg.OverwritePrompt = true;
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    string savename = saveDlg.FileName;
                    string strfilextn = savename.Remove(0, savename.Length - 3);
                    switch (strfilextn)
                    {
                        case "bmp":
                            save_pic.Save(savename, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            save_pic.Save(savename, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "png":
                            save_pic.Save(savename, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("无法保存图片");
                return;
            }
        }

        //打开图片
        private void openPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            opnDlg.Title = "打开图像文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                curFileName = opnDlg.FileName;
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                    if (curBitmap.Height * curBitmap.Width > 400000)
                    {
                        DialogResult dr = MessageBox.Show("图片过大，是否压缩？", "是否压缩图片", MessageBoxButtons.YesNoCancel);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            curBitmap = new Bitmap(curBitmap, 400, 400);
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                pictureBox1.Image = curBitmap;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
