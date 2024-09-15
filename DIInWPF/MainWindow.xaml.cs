using DIInWPF.StartupHelpers;
using System.Windows;
using WpfLibrary;

namespace DIInWPF;

public partial class MainWindow : Window
{
    public readonly IDataAccess _DataAccess;
    private readonly IAbstractFactory<ChildForm> _factory;
    //private readonly ChildForm _childForm;

    public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> factory) //ChildForm childForm)
    {
        InitializeComponent();
        _DataAccess = dataAccess;
        _factory = factory;
        //_childForm = childForm;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        // text field
        data.Text = _DataAccess.GetData();
    }

    private void openChildForm_Click(object sender, RoutedEventArgs e)
    {
        //_childForm.Show();
        _factory.Create().Show();
    }
}