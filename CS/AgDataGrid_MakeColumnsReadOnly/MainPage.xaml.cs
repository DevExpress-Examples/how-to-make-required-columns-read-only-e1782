using System.Windows;
using System.Windows.Controls;
using DevExpress.AgDataGrid;
using DevExpress.Utils;

namespace AgDataGrid_MakeColumnsReadOnly {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            CheckBox cb = sender as CheckBox;
            MakeColumnReadOnly(FindColumn(cb), DefaultBoolean.False);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            CheckBox cb = sender as CheckBox;
            MakeColumnReadOnly(FindColumn(cb), DefaultBoolean.True);
        }
        private void MakeColumnReadOnly(AgDataGridColumn col, DefaultBoolean isReadOnly) {
            if (col != null)
                col.AllowEditing = isReadOnly;
        }
        private AgDataGridColumn FindColumn(CheckBox cb) {
            if (cb == cbCompanyName)
                return grid.Columns["CompanyName"];
            if (cb == cbUnitPrice)
                return grid.Columns["UnitPrice"];
            if (cb == cbQuantity)
                return grid.Columns["Quantity"];
            return null;
        }
    }
}
