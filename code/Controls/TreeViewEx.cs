using System.Collections.Generic;
using System.Windows.Forms;

namespace Oracle.Controls
{
    public class TreeViewEx : TreeView
    {
        public readonly List<TreeNode> SelectedNodes = new List<TreeNode>();
    }
}