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
        private void setPCBoats()
        {
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("PC"))) button.BackColor = Color.FromArgb(62, 62, 62);

            int n2 = random.Next(10, 59);
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("PC")))
            {
                if (button.Name.Contains(n2.ToString()))
                    ctrpc[0] = n2;
                if (button.Name.Contains((n2 + 10).ToString()))
                    ctrpc[1] = n2 + 10;
                if (button.Name.Contains((n2 + 20).ToString()))
                    ctrpc[2] = n2 + 20;
                if (button.Name.Contains((n2 + 30).ToString()))
                    ctrpc[3] = n2 + 30;
                if (button.Name.Contains((n2 + 40).ToString()))
                    ctrpc[4] = n2 + 40;
            }
            int n1 = random.Next(10, 96);
            if ((n1.ToString().Contains("9") || n1.ToString().Contains("8") || n1.ToString().Contains("7")) || thereIS(n1, ctrpc))
            {
                n1 = 94;
                if (thereIS(n1, ctrpc)) n1 = 93;
            }
            foreach (var button in Controls.OfType<Button>().Where(b => b.Name.Contains("PC")))
            {
                if (button.Name.Contains(n1.ToString()))
                    ctrpc[5] = n1;
                if (button.Name.Contains((n1 + 1).ToString()))
                    ctrpc[6] = n1 + 1;
                if (button.Name.Contains((n1 + 2).ToString()))
                    ctrpc[7] = n1 + 2;
            }
            int n = random.Next(10, 99);
            do n = random.Next(10, 99); while (thereIS(n, ctrpc));
            ctrpc[8] = n;
        }
        private bool thereIS(int n1, int[] ctrl)
        {
            foreach (int elemento in ctrl) if (elemento == n1) return true;
            return false;
        }
        private void prepareField()
        {
            lbl1.Text = "User Boats = " + cntUsr; lbl2.Text = "PC Boats = " + cntPC;
            lbl1.Location = new Point(20, 20); lbl2.Location = new Point(450, 20);
            lbl1.ForeColor = Color.White; lbl2.ForeColor = Color.White;
            Controls.Add(lbl1); Controls.Add(lbl2);
            int x = 20, y = 50, l = 0;
            for (int i = 0; i < 10; i++)
            {
                l = i; y = 50;
                for (int j = 0; j < 10; j++)
                {
                    Button but = new Button();
                    but.Location = new Point(x, y); but.Size = new Size(38, 38);
                    but.BackColor = Color.FromArgb(62, 62, 62); but.ForeColor = Color.White;
                    but.FlatStyle = FlatStyle.Popup; but.Name = "User" + l.ToString();
                    if (l < 10) but.Name = "PC0" + l.ToString();
                    l += 10; Controls.Add(but); y += 38;
                }
                x += 38;
            }
            x = 450; l = 99;
            for (int i = 0; i < 10; i++)
            {
                l = 99 - i; y = 50;
                for (int j = 0; j < 10; j++)
                {
                    Button but = new Button();
                    but.Location = new Point(x, y);
                    but.Size = new Size(38, 38);
                    but.BackColor = Color.FromArgb(62, 62, 62);
                    but.ForeColor = Color.White;
                    but.FlatStyle = FlatStyle.Popup;
                    but.Name = "PC" + l.ToString();
                    but.Cursor = Cursors.Hand;
                    if (l < 10)
                        but.Name = "PC0" + l.ToString();
                    //but.Click += new EventHandler(debugName);
                    l -= 10; Controls.Add(but); y += 38;
                }
                x += 38;
            }
            foreach (Button btn in Controls.OfType<Button>().Where(b => b.Name.Contains("PC"))) btn.Click += new EventHandler(game);
        }
        private void game(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (thereIS(Convert.ToInt16(button.Name.Substring(2, 2)), ctrpc))
            {
                cntPC--;
                button.BackColor = Color.FromArgb(255, 255, 204);
                lbl2.Text = "PC Boats = " + cntPC;
            }
            else button.BackColor = Color.FromArgb(32, 32, 32);
            Random rnd = new Random(); int n;
            do n = rnd.Next(0, 99); while (thereIS(n, ax));
            ax[b] = n; b++;
            foreach (var btn in Controls.OfType<Button>().Where(b => b.Name.Contains("User")))
            {
                if (btn.Name.Substring(4, 2) == n.ToString())
                    if (btn.BackColor != Color.FromArgb(62, 62, 62))
                    {
                        cntUsr--;
                        btn.BackColor = Color.FromArgb(255, 255, 204);
                        lbl1.Text = "User Boats = " + cntUsr;
                    }
                    else btn.BackColor = Color.FromArgb(32,32,32);
            }
            if (cntPC == 0) MessageBox.Show("HAI VINTO");
            else if (cntUsr == 0) MessageBox.Show("HAI PERSO");
        }
    }
}
