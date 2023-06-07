using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattagliaNavale {
    public partial class Form1 : Form {
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
        private void generateField()
        {
            Button btn; Label lbl;
            int x=0, y=0;

            /*campo pc*/
            lbl = new Label();
            lbl.Name = "LblIntPc";
            lbl.Text = naviPC.ToString() + " Navi residue PC";
            lbl.BackColor = Color.Gainsboro;
            lbl.Location = new Point(20, 20);
            lblHeaders[0] = lbl;
            for(int i=0; i<campo; i++)
            {
                for(int j=0; j<campo; i++)
                {
                    m[i, j] = btn;
                }
            }
        }
        private void locateNavi(int[,] x)
        {
            Random rnd = new Random();
            int i = 0, j = 0, cnt=0;
            do
            {
                i = rnd.Next(0, campo);
                j = rnd.Next(0, campo);
                if (x[i, j] == 0)
                {
                    m[i, j] = 1;
                    cnt++;
                }      
            } while (cnt!=navi1);
            cnt = 0;
            do
            {
                i = rnd.Next(0, campo-2);
                j = rnd.Next(0, campo);
                if (x[i, j] == 0 && x[i+1, j]==0 && x[i+2,j]==0)
                {
                    m[i, j] = 1;
                    m[i+1, j] = 1;
                    m[i+2, j] = 1;
                    cnt++;
                }
            } while (cnt != navi3);
            cnt = 0;
            do
            {
                i = rnd.Next(0, campo);
                j = rnd.Next(0, campo-4);
                if (x[i, j] == 0 && x[i, j+1] == 0 && x[i, j+2] == 0 && x[i, j+3] == 0 && x[i, j + 4] == 0)
                {
                    m[i, j] = 1;
                    m[i, j + 1] = 1;
                    m[i, j + 2] = 1;
                    m[i, j + 3] = 1;
                    m[i, j + 4] = 1;
                    cnt++;
                }
            } while (cnt != navi5);
        }
    }
}
