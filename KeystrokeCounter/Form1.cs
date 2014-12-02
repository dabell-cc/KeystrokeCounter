using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeystrokeCounter
{
    public partial class Form1 : Form
    {
        private Button[] screen_keys;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mynotifyicon.Visible = false;
            label1.Text = KeystrokeCounter.Program.Last();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = KeystrokeCounter.Program.Last();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private Color heatmap(double norm_val)
        {
            int blue = 0;
            int green = 0;
            int red = 0;

            if (norm_val < 0.33)
            {
                blue = 255;
                green = (int)(255 * (norm_val/0.33));
            }
            else if (norm_val < 0.67)
            {
                green = 255;
                if (norm_val <= 0.50)
                    blue = (int)(255 * (1 - (norm_val - 0.33) / (0.50 - 0.33)));
                else
                    blue = 0;
                if(norm_val > 0.50)
                    red = (int)(255 * ((norm_val - 0.50) / (0.50 - 0.33)));
                else
                    red = 0;
            }
            else if (norm_val > 0.67)
            {
                red = 255;
                green = (int)(255 * (1 - ((norm_val-0.67) / 0.33)));
            }
            else
                red = green = blue = 0;

            return Color.FromArgb(red, green, blue);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            screen_keys = new Button[256];
            screen_keys[27] = this.bt_Escape;

            //Function Keys
            screen_keys[112] = this.bt_F1;
            screen_keys[113] = this.bt_F2;
            screen_keys[114] = this.bt_F3;
            screen_keys[115] = this.bt_F4;
            screen_keys[116] = this.bt_F5;
            screen_keys[117] = this.bt_F6;
            screen_keys[118] = this.bt_F7;
            screen_keys[119] = this.bt_F8;
            screen_keys[120] = this.bt_F9;
            screen_keys[121] = this.bt_F10;
            screen_keys[122] = this.bt_F11;
            screen_keys[123] = this.bt_F12;

            //Top Row
            screen_keys[192] = this.bt_Tilde;
            screen_keys[49] = this.bt_D1;
            screen_keys[50] = this.bt_D2;
            screen_keys[51] = this.bt_D3;
            screen_keys[52] = this.bt_D4;
            screen_keys[53] = this.bt_D5;
            screen_keys[54] = this.bt_D6;
            screen_keys[55] = this.bt_D7;
            screen_keys[56] = this.bt_D8;
            screen_keys[57] = this.bt_D9;
            screen_keys[48] = this.bt_D0;
            screen_keys[189] = this.bt_Minus;
            screen_keys[187] = this.bt_Plus;
            screen_keys[8] = this.bt_Backspace;

            //Second Row
            screen_keys[9] = this.bt_Tab;
            screen_keys[219] = this.bt_OpenBracket;
            screen_keys[221] = this.bt_CloseBracket;
            screen_keys[220] = this.bt_ForwardSlash;

            //Third Row
            screen_keys[20] = this.bt_Caps;
            screen_keys[186] = this.bt_semicolon;
            screen_keys[222] = this.bt_quote;
            screen_keys[13] = this.bt_Enter;

            //Fourth Row
            screen_keys[160] = this.bt_LeftShift;
            screen_keys[188] = this.bt_Comma;
            screen_keys[190] = this.bt_Period;
            screen_keys[191] = this.bt_BackSlash;
            screen_keys[161] = this.bt_RightShift;

            //Last Row
            screen_keys[162] = this.bt_LeftControl;
            screen_keys[91] = this.bt_LeftWindows;
            screen_keys[164] = this.bt_LeftAlt;
            screen_keys[32] = this.bt_Space;
            screen_keys[165] = this.bt_RightAlt;
            screen_keys[92] = this.bt_RightWin;
            screen_keys[93] = this.bt_RightMenu;
            screen_keys[163] = this.bt_RightControl;

            //Mode Keys
            screen_keys[33] = this.bt_PageUp;
            screen_keys[34] = this.bt_PageDown;
            screen_keys[35] = this.bt_End;
            screen_keys[36] = this.bt_Home;
            screen_keys[45] = this.bt_Insert;
            screen_keys[46] = this.bt_Delete;

            //Arrow Keys
            screen_keys[37] = this.bt_Left;
            screen_keys[38] = this.bt_Up;
            screen_keys[39] = this.bt_Right;
            screen_keys[40] = this.bt_Down;

            //Numpad
            screen_keys[96] = this.bt_Num0;
            screen_keys[97] = this.bt_Num1;
            screen_keys[98] = this.bt_Num2;
            screen_keys[99] = this.bt_Num3;
            screen_keys[100] = this.bt_Num4;
            screen_keys[101] = this.bt_Num5;
            screen_keys[102] = this.bt_Num6;
            screen_keys[103] = this.bt_Num7;
            screen_keys[104] = this.bt_Num8;
            screen_keys[105] = this.bt_Num9;

            screen_keys[110] = this.bt_Decimal;
            screen_keys[107] = this.bt_Addition;
            screen_keys[144] = this.bt_NumLock;
            screen_keys[111] = this.bt_Division;
            screen_keys[106] = this.bt_Multiplication;
            screen_keys[109] = this.bt_Subtraction;
            screen_keys[44] = this.bt_PrtScn;
            screen_keys[145] = this.bt_ScrollLock;
            screen_keys[19] = this.bt_Pause;

            //Media Keys
            screen_keys[173] = this.bt_Mute;
            screen_keys[174] = this.bt_VolDown;
            screen_keys[175] = this.bt_VolUp;

            //Alphabet
            screen_keys[65] = this.bt_A;
            screen_keys[66] = this.bt_B;
            screen_keys[67] = this.bt_C;
            screen_keys[68] = this.bt_D;
            screen_keys[69] = this.bt_E;
            screen_keys[70] = this.bt_F;
            screen_keys[71] = this.bt_G;
            screen_keys[72] = this.bt_H;
            screen_keys[73] = this.bt_I;
            screen_keys[74] = this.bt_J;
            screen_keys[75] = this.bt_K;
            screen_keys[76] = this.bt_L;
            screen_keys[77] = this.bt_M;
            screen_keys[78] = this.bt_N;
            screen_keys[79] = this.bt_O;
            screen_keys[80] = this.bt_P;
            screen_keys[81] = this.bt_Q;
            screen_keys[82] = this.bt_R;
            screen_keys[83] = this.bt_S;
            screen_keys[84] = this.bt_T;
            screen_keys[85] = this.bt_U;
            screen_keys[86] = this.bt_V;
            screen_keys[87] = this.bt_W;
            screen_keys[88] = this.bt_X;
            screen_keys[89] = this.bt_Y;
            screen_keys[90] = this.bt_Z;

            int[] counts = KeystrokeCounter.Program.counts;
            //screen_keys[i].BackColor = heatmap(counts[i] / counts.Max());
            if (counts.Max() > 0)
            {
                for (int i = 0; i < screen_keys.Length; i++)
                    if (screen_keys[i] != null)
                        screen_keys[i].BackColor = heatmap((double)counts[i] / counts.Max());

                
            }
            this.bt_Calculate.BackColor = this.bt_Enter.BackColor;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                mynotifyicon.Visible = true;
                ShowInTaskbar = false;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                mynotifyicon.Visible = false;
            }
        }

        private void mynotifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            ShowInTaskbar = true;
            mynotifyicon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] counts = KeystrokeCounter.Program.counts;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\KeyboardData.csv", true))
            {
                file.WriteLine("Code Number, Number of Keypresses, KeyCode,");
                for(int i=0;i<counts.Length;i++)
                    file.WriteLine("{0},{1},{2},", i, counts[i], (Keys)i);
            }
        }

    }    
}
