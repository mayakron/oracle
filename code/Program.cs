using System;
using System.Drawing;
using System.Windows.Forms;

namespace Oracle
{
    internal static class Program
    {
        public static readonly Font StandardFont = new Font(StandardFontFamily, StandardFontSize, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        public static readonly string Title = $"Oracle (v. {Application.ProductVersion})";

        private const string StandardFontFamily = "Calibri";

        private const float StandardFontSize = 11.25F;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new MainWindow());
        }
    }
}