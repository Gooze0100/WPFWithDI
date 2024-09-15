using System.Windows;
using WpfLibrary;

namespace DIInWPF;

public partial class ChildForm : Window
{
    private readonly IDataAccess _dataAccess;

    public ChildForm(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        dataAccessInfo.Text = _dataAccess.GetData();
    }
}
