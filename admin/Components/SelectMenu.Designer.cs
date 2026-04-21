using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace admin.Components;

partial class SelectMenu
{
    private ComboBox cmbValue;
    private Panel pnlUnderline;
    private void InitializeComponent()
    {
        cmbValue = new ComboBox();
        pnlUnderline = new Panel();
        SuspendLayout();
        // 
        // cmbValue
        // 
        cmbValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cmbValue.BackColor = Color.White;
        cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbValue.Font = new Font("Segoe UI", 12F);
        cmbValue.ForeColor = Color.DarkSlateBlue;
        cmbValue.Location = new Point(0, 0);
        cmbValue.Margin = new Padding(0);
        cmbValue.Name = "cmbValue";
        cmbValue.Size = new Size(300, 29);
        cmbValue.TabIndex = 0;
        cmbValue.SelectedIndexChanged += CmbValue_SelectedIndexChanged;
        // 
        // pnlUnderline
        // 
        pnlUnderline.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlUnderline.BackColor = Color.DarkSlateBlue;
        pnlUnderline.Location = new Point(0, 28);
        pnlUnderline.Name = "pnlUnderline";
        pnlUnderline.Size = new Size(300, 2);
        pnlUnderline.TabIndex = 1;
        // 
        // SelectMenu
        // 
        BackColor = Color.White;
        Controls.Add(pnlUnderline);
        Controls.Add(cmbValue);
        Margin = new Padding(4, 2, 4, 2);
        Name = "SelectMenu";
        Size = new Size(300, 30);
        ResumeLayout(false);
    }
}
