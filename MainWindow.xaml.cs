using System.Windows;

namespace CustomDB_ValidationRule
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void miExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void miNew_Click(object sender, RoutedEventArgs e)
		{
			var wndÚjAdat = new wndNewData
			{
				Owner = this,
				Person =
				{
					Name = "Valaki Eduárd",
					Average = 2
				}
			};
			var res = wndÚjAdat.ShowDialog();
			if (res == true)
			{

			}
		}

	}
}
