using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattagliaNavale {
    public partial class Form1 : Form {
        Random random = new Random();
        Label lbl1 = new Label(), lbl2 = new Label();
        int cntPC = 9, cntUsr = 9, b = 0;
        int[] ctrpc = new int[9], ax = new int[99];
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            for (int i = 0; i < ax.Length; ++i)
                ax[i] = -1;
            prepareField(); setBoats(null, e);
        }
        private void setBoats(object sender, EventArgs e) {
            setUserBoats(); setPCBoats();
        }
        private void setUserBoats()
        {
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("User")))
                button.BackColor = Color.FromArgb(62, 62, 62);
            int[] ctrl = new int[8];
            int n2 = random.Next(10, 59);
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("User")))
            {
                if (button.Name.Contains(n2.ToString()))
                {
                    button.BackColor = Color.FromArgb(102, 102, 153);
                    ctrl[0] = n2;
                }
                if (button.Name.Contains((n2 + 10).ToString()))
                {
                    button.BackColor = Color.FromArgb(102, 102, 153);
                    ctrl[1] = n2 + 10;
                }
                if (button.Name.Contains((n2 + 20).ToString()))
                {
                    button.BackColor = Color.FromArgb(102, 102, 153);
                    ctrl[2] = n2 + 20;
                }
                if (button.Name.Contains((n2 + 30).ToString()))
                {
                    button.BackColor = Color.FromArgb(102, 102, 153);
                    ctrl[3] = n2 + 30;
                }
                if (button.Name.Contains((n2 + 40).ToString()))
                {
                    button.BackColor = Color.FromArgb(102, 102, 153);
                    ctrl[4] = n2 + 40;
                }
            }
            int n1 = random.Next(10, 96);
            if ((n1.ToString().Contains("9") || n1.ToString().Contains("8") || n1.ToString().Contains("7")) || thereIS(n1, ctrl))
            {
                n1 = 94;
                if (thereIS(n1, ctrl)) n1 = 93;
            }
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("User")))
            {
                if (button.Name.Contains(n1.ToString()))
                {
                    button.BackColor = Color.FromArgb(179, 179, 204);
                    ctrl[5] = n1;
                }
                if (button.Name.Contains((n1 + 1).ToString()))
                {
                    button.BackColor = Color.FromArgb(179, 179, 204);
                    ctrl[6] = n1 + 1;
                }
                if (button.Name.Contains((n1 + 2).ToString()))
                {
                    button.BackColor = Color.FromArgb(179, 179, 204);
                    ctrl[7] = n1 + 2;
                }
            }
            int n = random.Next(10, 99);
            do n = random.Next(10, 99); while (thereIS(n, ctrl));
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("User")))
                if (button.Name.Contains(n.ToString())) button.BackColor = Color.FromArgb(224, 224, 235);
        }
    }
}
