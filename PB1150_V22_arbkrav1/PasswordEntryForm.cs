using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PB1150_V22_arbkrav1
{
    public partial class PasswordEntryForm : Form
    {
        string password;
        FormMain parent;

        public PasswordEntryForm(FormMain parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            password = textBoxPassword.Text;
            if (password.Length < 8)
            {
                MessageBox.Show("Minimum password length is 8 characters. Please try again.");
            }
            else
            {
                this.Hide();
                parent.finishConfigWrite(password);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
