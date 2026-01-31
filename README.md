<h1 align="center">
  Oracle
</h1>

<h4 align="center">Oracle is a lightweight personal note taking system, designed for power users</h4>

<h4 align="center">
  <a href="#features">Features</a>&nbsp;|&nbsp;
  <a href="#download">Download</a>&nbsp;|&nbsp;
  <a href="#installation">Installation</a>&nbsp;|&nbsp;
  <a href="#license">License</a>
</h4>

![Query tab screenshot](https://raw.githubusercontent.com/mayakron/oracle/main/resources/OracleMainScreenshot.png)

## Features

Oracle is a lightweight personal note taking system, designed for power users with speed of execution, effectiveness and stability as core drivers.

It separates the screen into a tree panel (on the left) and a notes panel (on the right), and uses keyboard shortcuts for all of its commands.

Global shortcuts are:

    CTRL O             Explore the current node attachments
    CTRL S             Save the tree database
    CTRL SHIFT S       Save the tree database and cleanup the node attachments directories
    CTRL 1..9          Goto bookmark
    CTRL SHIFT 1..9    Save bookmark

Tree panel shortcuts are:

    ENTER              Expand or collapse the current node
    F1                 Create a child node or move selected nodes into the current node
    F2                 Rename the current node
    F3                 Create a sibling node or move selected nodes before the current node
    F4                 Create a sibling node or move selected nodes after the current node
    F12                Sort the child nodes in ascending order
    SHIFT F12          Sort the child nodes in descending order
    SPACE              Add the current node to the selection
    SHIFT SPACE        Add the child nodes to the selection
    CTRL SPACE         Clear the selection
    CTRL DEL           Delete the current node
    CTRL B             Bold font
    CTRL D             Export the current node
    CTRL SHIFT D       Import nodes into the current node
    CTRL F             Find a node
    CTRL SHIFT F       Find a node again (repeat the previous find)
    CTRL I             Italic font
    CTRL K             Strikeout font
    CTRL T             Copy the selected node link to the clipboard
    CTRL U             Underline font
    CTRL W             Convert the node title to sentence case
    CTRL ALT 0         Black on white font
    CTRL ALT 1         Red on white font
    CTRL ALT 2         Green on white font
    CTRL ALT 3         Blue on white font
    CTRL ALT 4         Gray on white font
    CTRL ALT 5         White on black font
    CTRL ALT 6         White on red font
    CTRL ALT 7         White on green font
    CTRL ALT 8         White on blue font
    CTRL ALT 9         White on gray font

Notes panel shortcuts are:

    CTRL A             Select all
    CTRL SHIFT A       Convert to all caps
    CTRL B             Bold font
    CTRL C             Copy to clipboard
    CTRL D             Export
    CTRL SHIFT D       Import
    CTRL E             Center align paragraph
    CTRL H             Increase paragraph indentation
    CTRL SHIFT H       Decrease paragraph indentation
    CTRL I             Italic font
    CTRL J             Justify align paragraph
    CTRL K             Strikeout font
    CTRL L             Left align paragraph
    CTRL SHIFT L       Cycle through bullet styles
    CTRL M             Monospace font
    CTRL R             Right align paragraph
    CTRL U             Underline font
    CTRL V             Paste from the clipboard with formatting
    CTRL SHIFT V       Paste from the clipboard without formatting and with image optimization (might be lossy)
    CTRL X             Cut to the clipboard
    CTRL Y             Redo
    CTRL Z             Undo
    CTRL +             Subscript
    CTRL SHIFT +       Superscript
    CTRL TAB           Insert TAB
    INSERT             Toggle overwrite/insert mode
    CTRL ALT 0         Black on white font
    CTRL ALT 1         Red on white font
    CTRL ALT 2         Green on white font
    CTRL ALT 3         Blue on white font
    CTRL ALT 4         Gray on white font
    CTRL ALT 5         White on black font
    CTRL ALT 6         White on red font
    CTRL ALT 7         White on green font
    CTRL ALT 8         White on blue font
    CTRL ALT 9         White on gray font

Hyperlinks support customized behaviour using specific tags, like:

    {{NodePath}}
    gopher://Goto:NodeLink

Additional information about the RichEdit control used in the notes panel can be found [here](https://docs.microsoft.com/en-us/windows/win32/controls/about-rich-edit-controls).

## Download

All versions of Oracle can be downloaded from [here](https://github.com/mayakron/oracle/releases).

## Installation

Oracle is portable: just expand the archive to a directory of your choice and run the Oracle.exe file.

## License

[GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html)