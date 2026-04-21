using admin.Components;

namespace admin.Views;

public enum ModalType
{
    Information,
    Warning,
    Error,
    Success,
    Question
}

public enum ModalResult
{
    None = 0,
    OK = 1,
    Cancel = 2,
    Yes = 6,
    No = 7
}

public enum ModalButtons
{
    OK,
    OKCancel,
    YesNo,
    YesNoCancel
}

internal partial class ModalContainer : Form
{
    public ModalResult Result { get; private set; } = ModalResult.None;

    public ModalContainer(
        string title,
        string message,
        ModalType type = ModalType.Information,
        ModalButtons buttons = ModalButtons.OK)
    {
        InitializeComponent();
        SetupModal(title, message, type, buttons);
    }

    private void SetupModal(string title, string message, ModalType type, ModalButtons buttons)
    {
        Text = title;
        lblMessage.Text = message;

        SetupIcon(type);
        SetupButtons(buttons);
    }

    private void SetupIcon(ModalType type)
    {
        var iconColor = type switch
        {
            ModalType.Information => Color.DodgerBlue,
            ModalType.Warning => Color.Orange,
            ModalType.Error => Color.Red,
            ModalType.Success => Color.Green,
            ModalType.Question => Color.DarkSlateBlue,
            _ => Color.DarkSlateBlue
        };

        lblIcon.ForeColor = iconColor;
        lblIcon.Text = type switch
        {
            ModalType.Information => "ℹ",
            ModalType.Warning => "⚠",
            ModalType.Error => "✕",
            ModalType.Success => "✓",
            ModalType.Question => "?",
            _ => "●"
        };
    }

    private void SetupButtons(ModalButtons buttons)
    {
        btnPrimary.Visible = false;
        btnSecondary.Visible = false;
        btnTertiary.Visible = false;

        switch (buttons)
        {
            case ModalButtons.OK:
                btnPrimary.Text = "OK";
                btnPrimary.Click += (_, _) => { Result = ModalResult.OK; DialogResult = DialogResult.OK; Close(); };
                btnPrimary.Visible = true;
                break;

            case ModalButtons.OKCancel:
                btnPrimary.Text = "OK";
                btnSecondary.Text = "Cancelar";
                btnPrimary.Click += (_, _) => { Result = ModalResult.OK; DialogResult = DialogResult.OK; Close(); };
                btnSecondary.Click += (_, _) => { Result = ModalResult.Cancel; DialogResult = DialogResult.Cancel; Close(); };
                btnPrimary.Visible = true;
                btnSecondary.Visible = true;
                break;

            case ModalButtons.YesNo:
                btnPrimary.Text = "Sí";
                btnSecondary.Text = "No";
                btnPrimary.Click += (_, _) => { Result = ModalResult.Yes; DialogResult = DialogResult.Yes; Close(); };
                btnSecondary.Click += (_, _) => { Result = ModalResult.No; DialogResult = DialogResult.No; Close(); };
                btnPrimary.Visible = true;
                btnSecondary.Visible = true;
                break;

            case ModalButtons.YesNoCancel:
                btnPrimary.Text = "Sí";
                btnSecondary.Text = "No";
                btnTertiary.Text = "Cancelar";
                btnPrimary.Click += (_, _) => { Result = ModalResult.Yes; DialogResult = DialogResult.Yes; Close(); };
                btnSecondary.Click += (_, _) => { Result = ModalResult.No; DialogResult = DialogResult.No; Close(); };
                btnTertiary.Click += (_, _) => { Result = ModalResult.Cancel; DialogResult = DialogResult.Cancel; Close(); };
                btnPrimary.Visible = true;
                btnSecondary.Visible = true;
                btnTertiary.Visible = true;
                break;
        }

        AdjustWindowSize();
    }

    private void AdjustWindowSize()
    {
        int visibleButtons = (btnPrimary.Visible ? 1 : 0) + (btnSecondary.Visible ? 1 : 0) + (btnTertiary.Visible ? 1 : 0);
        
        if (visibleButtons == 1)
        {
            btnPrimary.Width = 120;
            btnPrimary.Location = new Point((ClientSize.Width - btnPrimary.Width) / 2, btnPrimary.Location.Y);
        }
    }
}
