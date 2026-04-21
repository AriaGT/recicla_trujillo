namespace admin.Components;

partial class Table
{
    private void InitializeComponent()
    {
        Margin = new Padding(4, 20, 4, 4);
        BackgroundColor = Color.White;
        BorderStyle = BorderStyle.None;
        CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        GridColor = Color.FromArgb(235, 235, 235);
        RowHeadersVisible = false;
        SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        MultiSelect = false;
        AllowUserToAddRows = false;
        AllowUserToResizeRows = false;
        ReadOnly = true;
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        EnableHeadersVisualStyles = false;
        DoubleBuffered = true;

        DefaultCellStyle.Font = new Font("Segoe UI", 10F);
        DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
        DefaultCellStyle.SelectionForeColor = Color.Black;
        DefaultCellStyle.BackColor = Color.White;
        RowTemplate.Height = 40;

        ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        ColumnHeadersHeight = 45;
        ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
        ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    }
}
