using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NumLockSharp
{
    public partial class Form1 : Form
    {
        const byte VK_NUMLOCK = 0x90;
        const byte VK_CAPSLOCK = 0x14;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                listBox1.Items.Add("Num Lock key is ON.");
            }
            else
            {
               listBox1.Items.Add("NUM Lock key is OFF.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //on
            if (Control.IsKeyLocked(Keys.NumLock))
            { listBox1.Items.Add("Num Lock key is ON."); }
            else
            {
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                listBox1.Items.Add("Num Lock key set to ON.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //off
            if (Control.IsKeyLocked(Keys.NumLock))
            { 
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                listBox1.Items.Add("Num Lock key set to OFF.");
            }
            else
            {

                listBox1.Items.Add("Num Lock key is OFF");
            }
        }
    }
}
