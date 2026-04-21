using System;
using System.Collections.Generic;
using System.Text;

namespace admin.Components;

partial class Input
{
    private void InitializeComponent()
    {
        txtValue = new TextBox();
        panel1 = new Panel();
        SuspendLayout();
        // 
        // txtValue
        // 
        txtValue.BackColor = Color.White;
        txtValue.BorderStyle = BorderStyle.None;
        txtValue.Location = new Point(6, 4);
        txtValue.Margin = new Padding(6, 4, 6, 4);
        txtValue.Name = "txtValue";
        txtValue.Size = new Size(180, 16);
        txtValue.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.BackColor = Color.DarkSlateBlue;
        panel1.Location = new Point(0, 22);
        panel1.Name = "panel1";
        panel1.Size = new Size(192, 2);
        panel1.TabIndex = 1;
        // 
        // Input
        // 
        BackColor = Color.White;
        Controls.Add(panel1);
        Controls.Add(txtValue);
        Margin = new Padding(4, 2, 4, 2);
        Name = "Input";
        Size = new Size(192, 24);
        ResumeLayout(false);
        PerformLayout();

    }
}
