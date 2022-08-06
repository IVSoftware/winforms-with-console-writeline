using System;
using System.IV;
using Console = System.IV.Console; // Set one time for this one file.
using System.Windows.Forms;

namespace winforms_with_console_writeline
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            textBoxSend.KeyDown += onKeyDown;

            Console.ConsoleWrite += onConsoleWrite;
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                e.Handled = e.SuppressKeyPress = true;
                Console.WriteLine(textBoxSend.Text);
                BeginInvoke((MethodInvoker)delegate { textBoxSend.Clear();  });
            }
        }

        private void onConsoleWrite(ConsoleWriteEventArgs e)
        {
            var text = e.NewLine ? $"{e.Text}{Environment.NewLine}" : e.Text;
            if(InvokeRequired) Invoke((MethodInvoker)delegate { textBoxEcho.AppendText(text); });
            else textBoxEcho.AppendText(text);
        }
    }
}
