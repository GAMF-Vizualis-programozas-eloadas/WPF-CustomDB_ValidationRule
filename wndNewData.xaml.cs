using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomDB_ValidationRule
{
	public partial class wndNewData : Window
	{
		public Person Person {get; set;}
		public wndNewData()
		{
			InitializeComponent();
			Person = new Person();
			gr.DataContext = Person;
		}

		private void btOK_Click(object sender, RoutedEventArgs e)
		{
			// Nem engedjük bezárni a párbeszédablakot, ha van 
			// valamilyen adatbeviteli hiba.
			if (!IsValid(this)) return;
			// Ha nincs hiba, akkor a párbeszédablakot bezárjuk, és 
			// true lesz a visszatérési érték.
			DialogResult = true;
		}

		/// <summary>
		/// Végrehajtja egy adott elem alatti összes DependencyObject típusú
		/// elem érvényességi állapotának ellenőrzését rekurzívan.
		/// </summary>
		/// <param name="node">Kiinduló elem./param>
		/// <returns>true - ha nem volt hiba, false - ha volt hiba.</returns>
		bool IsValid(DependencyObject doElem)
		{	// Ha (már) nincs elem, akkor nincs hiba.
			if (doElem == null) return true;
			// Ha az aktuális elemnél van bejegyzett hiba, és az elem
			// egy  adatbeviteli elem, akkor az elemre állítjuk az input fókuszt.
			if (Validation.GetHasError(doElem) && doElem is IInputElement)
			{	Keyboard.Focus((IInputElement)doElem);
				return false;
			}
			// Leellenőrizzük az elem alatti elmeket is. 
			var GyermekElemek=LogicalTreeHelper.GetChildren(doElem);
			foreach (var x in GyermekElemek)
			{	var GyermekElem=x as DependencyObject;
				if(GyermekElem==null) continue;
				// Ha az aktuális gyermekelem DependencyObject típusú, akkor ellenőrizzük.
				if(!IsValid(GyermekElem))
					// Ha volt bejegyzett hiba, akkor 
					return false;
			}
			// Egyetlen DependencyObject típusú elemnél sincs hiba bejegyezve. 
			return true;
		}

	}
}