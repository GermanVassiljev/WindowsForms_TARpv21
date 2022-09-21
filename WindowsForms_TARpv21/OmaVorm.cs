using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TARpv21
{
    public class OmaVorm : Form
    {
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, RadioButton Rmnupp, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            RadioButton Rmnupp = new RadioButton
            {
                Text = Rmnupp,
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.DarkRed
            };
            Rmnupp.Click += Nupp_Click;
            Label failinimi = new Label
            {
                Text = Fail,
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.DarkRed
            };
            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
        }
        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender=(Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusika kuulata?", "Küsimus", MessageBoxButtons.YesNo);
            if (vastus==DialogResult.Yes)
            {
                using (var muusika=new SoundPlayer(@"..\..\..\Undertale Megalovania Song Sound Effect.wav"))
                {
                    MessageBox.Show("Muusika Mängitakse!");
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(">:{");
            }
        }
    }
}
