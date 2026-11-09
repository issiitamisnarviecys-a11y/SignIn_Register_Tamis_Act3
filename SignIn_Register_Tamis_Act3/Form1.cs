
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SignIn_Register_Tamis_Act3
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();

            // Hide password characters
            txtPassword.UseSystemPasswordChar = true;
        }

        // SIGN IN BUTTON
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show(
                    "Please enter your username and password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (UserAccountStore.Login(username, password))
            {
                MessageBox.Show(
                    "Welcome, " + username + "!",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Dashboard will be connected here later.
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password!",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // REGISTER LINK
        private void linkRegister_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm reg = new RegisterForm();

            reg.FormClosed += (s, args) =>
            {
                this.Show();
            };

            reg.Show();
            this.Hide();
        }

        // USERNAME TEXTBOX
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // PASSWORD TEXTBOX
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        // LABEL EVENTS
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}
