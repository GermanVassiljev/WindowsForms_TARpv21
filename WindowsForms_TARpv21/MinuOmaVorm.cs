using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TARpv21
{
    public partial class MinuOmaVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        Timer aeg;
        public MinuOmaVorm()
        {
            Height = 600;
            Width = 900;
            Text = "Minu oma vorm koos elementiga";
            puu = new TreeView();//Объявление дерева
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp"));
            oksad.Nodes.Add(new TreeNode("Silt"));
            oksad.Nodes.Add(new TreeNode("Dialog MessageBox"));
            oksad.Nodes.Add(new TreeNode("Märkeruut"));
            oksad.Nodes.Add(new TreeNode("Radionupp"));
            oksad.Nodes.Add(new TreeNode("ProgressBar"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            silt = new Label
            {
                Text = "Minu esimene vorm",
                Size = new Size(200, 50),
                Location = new Point(200, 0)

            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Punane",
                Location = new Point(silt.Left + silt.Width, 0),
                Width = 100,
                Height = 25
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Sinine",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Width = 100,
                Height = 25
            };
            if (e.Node.Text=="Nupp")
            {
                nupp=new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location=new Point(200, 250);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }

            else if(e.Node.Text=="Silt")
            { 
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if(e.Node.Text == "Dialog MessageBox")
            {
                MessageBox.Show("Siia kirjuta lause", "Kõike lihtsam aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?", "Valik", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (vastus==DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Siis töötama edasi", "Vastus oli NO");
                }
            }
            else if (e.Node.Text== "Märkeruut")
            {
                mruut1.CheckedChanged += Mruut1_CheckedChanged;
                mruut2.CheckedChanged += Mruut1_CheckedChanged;
                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);

            }
            else if (e.Node.Text=="Radionupp")
            {
                rnupp1 = new RadioButton
                {
                    Text="Paremale",
                    Width=120,
                    Location=new Point(mruut2.Left+mruut2.Width,mruut1.Height+mruut2.Height),
                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 120,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height+rnupp1.Width)
                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 120,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height+ rnupp1.Width+ rnupp2.Width)
                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 120,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height+ rnupp1.Width+ rnupp2.Width+ rnupp3.Width)
                };
                pilt = new PictureBox
                {
                    Image=new Bitmap("BOMJ.jpeg"),
                    Location=new Point(300,450),
                    Size=new Size(100,100),
                    SizeMode=PictureBoxSizeMode.Zoom
                };
                rnupp1.CheckedChanged += Rnupp_CheckedChanged;
                rnupp2.CheckedChanged += Rnupp_CheckedChanged;
                rnupp3.CheckedChanged += Rnupp_CheckedChanged;
                rnupp4.CheckedChanged += Rnupp_CheckedChanged;
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text=="ProgressBar")
            {
                riba = new ProgressBar
                { 
                    Width=400,
                    Height=30,
                    Location = new Point(350, 500),
                    Value=50,
                    Minimum=0,
                    Maximum=100,
                    Step=1,
                    Dock=DockStyle.Bottom
                };
                aeg = new Timer();
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;
                this.Controls.Add(riba);
            }
    }

        private void Aeg_Tick(object sender,EventArgs e)
        {
            riba.PerformStep();

        }
        private void Rnupp_CheckedChanged(object sender, EventArgs e)
        {
            if (rnupp1.Checked == true)
            {
                pilt.Left += 10;
                rnupp1.Checked=false;
            }
            else if(rnupp2.Checked == true)
            {
                pilt.Left -= 10;
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked == true)
            {
                pilt.Top -= 10;
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked==true)
            {
                pilt.Top += 10;
                rnupp4.Checked = false;
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked==false)
            {
                this.BackColor = Color.Red;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                this.BackColor = Color.Blue;
            }
            else if (mruut1.Checked == true && mruut2.Checked == true)
            {
                this.BackColor = Color.Purple;
            }
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.ForeColor=Color.Black;
            silt.BackColor = Color.White;
        }
        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor=Color.White;
            silt.BackColor=Color.Black;
        }
        Random random = new Random();
        private void Nupp_Click(Object sender, EventArgs e)
        {
            int red, green, blue;
            red = random.Next(100,255);
            green = random.Next(100,255);
            blue = random.Next(100,255);
            this.BackColor= Color.FromArgb(red, green, blue);
        }
    }
}
