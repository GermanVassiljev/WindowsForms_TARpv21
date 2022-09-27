using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TARpv21
{
    public partial class OmaVorm : Form
    {
        RadioButton Rmnupp1, Rmnupp2, Rmnupp3;
        PictureBox pilt1;
        Label failinimi;
        public string Rmnupp_vastus = "Fail nimi";
        public OmaVorm() { }
        public OmaVorm(string Pealkiri)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Rmnupp1 = new RadioButton
            {
                Text = "Megalovania",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightBlue
            };
            Rmnupp2 = new RadioButton
            {
                Text = "Papyrus theme",
                Location = new System.Drawing.Point(50,100),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightBlue
            };
            Rmnupp3 = new RadioButton
            {
                Text = "Kazah music",
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightBlue
            }; 
            failinimi = new Label
            {
                Text = Rmnupp_vastus,
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightBlue
            };
            pilt1 = new PictureBox
            {
                Image = new Bitmap("sans.jpg"),
                Location = new Point(50, 250),
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Rmnupp1.CheckedChanged += Rmnupp_Checked;
            Rmnupp2.CheckedChanged += Rmnupp_Checked;
            Rmnupp3.CheckedChanged += Rmnupp_Checked;
            this.Controls.Add(Rmnupp1);
            this.Controls.Add(Rmnupp2);
            this.Controls.Add(Rmnupp3);
            this.Controls.Add(failinimi);
        }
        private void Rmnupp_Checked(object sender, EventArgs e)
        {
            if (Rmnupp1.Checked == true)
            {
                Rmnupp_vastus = "Megalovania";
                failinimi.Text = Rmnupp_vastus;
                this.Controls.Add(pilt1);
                using (var muusika = new SoundPlayer(@"..\..\Undertale Megalovania Song Sound Effect.wav"))
                {
                    muusika.Stop();
                    muusika.Play();
                }
            }
            else if (Rmnupp2.Checked == true)
            {
                Rmnupp_vastus = "Papyrus theme";
                failinimi.Text = Rmnupp_vastus;
                using (var muusika = new SoundPlayer(@"..\..\Undertale-Papyrus.wav"))
                {
                    muusika.Stop();
                    muusika.Play();
                }
            }
            else if (Rmnupp3.Checked == true)
            {
                Rmnupp_vastus = "Kazah music";
                failinimi.Text = Rmnupp_vastus;
                using (var muusika = new SoundPlayer(@"..\..\kazahstan.wav"))
                {
                    muusika.Stop();
                    muusika.Play();
                }
            }
        }
    }
}
