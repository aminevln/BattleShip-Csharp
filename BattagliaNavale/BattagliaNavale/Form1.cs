using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int campo = 10;
        int[,] a, m; //matrice giocatore | matrice PC
        int naviPC=0, naviUser=0, navi1=1, navi3=1, navi5=1; //totale residuo blocchi di navi da affondare
        Button[,] btnUser; //matrice di bottoni
        Label[] lblHeaders;
        private void Form1_Load(object sender, EventArgs e)
        {
            a = new int[campo, campo];
            naviPC = (navi1 * 1) + (navi3 * 3) + (navi5 * 5); 
            naviUser= (navi1 * 1) + (navi3 * 3) + (navi5 * 5);

            btnUser = new Button[campo, campo];
            lblHeaders = new Label[2];

            locateNavi(m);
            locateNavi(a);
            generateField();
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
