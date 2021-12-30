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
using System.Net;
using System.Net.Http;
using MinecraftServerRCON;

namespace SimpleRCON
{
    public partial class SimpleRCON : Form
    {
        public SimpleRCON()
        {
            InitializeComponent();
        }


        public string port = String.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            using (var rcon = RCONClient.INSTANCE)
            {
                if ((ip_input.Text != "") && (port_input.Text != "") && (pass_input.Text != ""))
                {
                    rcon.setupStream(ip_input.Text, port = port_input.Text, password: pass_input.Text);
                    string answer = rcon.sendMessage(RCONMessageType.Command, input.Text);
                    Console.WriteLine(answer.RemoveColorCodes());
                    richTextBox1.Text = richTextBox1.Text + answer.RemoveColorCodes();
                }
                else
                {
                    MessageBox.Show("Не заполнены поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}