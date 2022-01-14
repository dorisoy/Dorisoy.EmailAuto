using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto.Infrastructure.Helper
{
    /// <summary>
    /// Extension Helper Methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the specified contains keywords contains any.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="containsKeywords">The contains keywords.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified contains keywords contains any; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAny(this string input, IEnumerable<string> containsKeywords, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            return containsKeywords.Any(keyword => input.IndexOf(keyword, comparisonType) >= 0);
        }

        /// <summary>
        /// Enables the context menu.
        /// </summary>
        /// <param name="rtb">The RTB.</param>
        public static void EnableContextMenu(this RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                // Create a ContextMenuStrip without icons
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;

                // 1. Add the Undo option
                ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
                tsmiUndo.Click += (sender, e) => rtb.Undo();
                cms.Items.Add(tsmiUndo);

                // 2. Add the Redo option
                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
                tsmiRedo.Click += (sender, e) => rtb.Redo();
                cms.Items.Add(tsmiRedo);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 3. Add the Cut option (cuts the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);

                // 4. Add the Copy option (copies the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);

                // 5. Add the Paste option (adds the text from the clipboard into the richtextbox)
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(tsmiPaste);

                // 6. Add the Delete Option (remove the selected text in the richtextbox)
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
                cms.Items.Add(tsmiDelete);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 7. Add the Select All Option (selects all the text inside the richtextbox)
                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
                cms.Items.Add(tsmiSelectAll);

                // When opening the menu, check if the condition is fulfilled 
                // in order to enable the action
                cms.Opening += (sender, e) =>
                {
                    tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                    tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                    tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiCopy.Enabled = rtb.SelectionLength > 0;
                    tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                    tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                };

                rtb.ContextMenuStrip = cms;
            }
        }
    }
}
