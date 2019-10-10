using System.Windows.Forms;


namespace ContactsApp
{

    public partial class AboutForm : Form
    {

        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gorecan");
        }
    }
}