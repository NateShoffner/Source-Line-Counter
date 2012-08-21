#region

using System.Windows.Forms;

#endregion

namespace SourceLineCounter.Controls
{
    internal class TextBoxExtended : TextBox
    {
        #region Overrides of Control

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //shortcut keys don't work in multiline textboxes
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.V:
                        e.SuppressKeyPress = true;
                        Paste();
                        e.Handled = true;
                        break;
                    case Keys.C:
                        e.SuppressKeyPress = true;
                        Copy();
                        e.Handled = true;
                        break;
                    case Keys.X:
                        e.SuppressKeyPress = true;
                        Cut();
                        e.Handled = true;
                        break;
                    case Keys.A:
                        e.SuppressKeyPress = true;
                        SelectAll();
                        e.Handled = true;
                        break;
                }
            }

            base.OnKeyDown(e);
        }

        #endregion
    }
}