using Oracle.Utilities;
using System.Windows.Forms;

namespace Oracle.Controls
{
    public class RichTextBoxEx : RichTextBox
    {
        static RichTextBoxEx()
        {
            Kernel32Utility.LoadLibrary("Msftedit.dll");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams; createParams.ClassName = "RichEdit50W"; return createParams;
            }
        }
    }
}