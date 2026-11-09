
using System;
using System.Windows.Forms;

namespace SignIn_Register_Tamis_Act3
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            btnRegister.Click += btnRegister_Click;
            lblSignIn.Click += lblSignIn_Click;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check empty fields
            if (fullName == "" || username == "" ||
                password == "" || confirmPassword == "")
            {
                MessageBox.Show(
                    "Please complete all fields.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Check password length
            if (password.Length < 6)
            {
                MessageBox.Show(
                    "Password must be at least 6 characters."
                );
                return;
            }

            // Check password confirmation
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Password does not match!",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Save account
            bool success = UserAccountStore.Register(
                fullName,
                username,
                password
            );

            if (success)
            {
                MessageBox.Show(
                    "Account created successfully!\nYou can now sign in.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtFullName.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Username already exists. Please use another username.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
