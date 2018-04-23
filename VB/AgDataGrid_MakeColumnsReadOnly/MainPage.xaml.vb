Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.AgDataGrid
Imports DevExpress.Utils

Namespace AgDataGrid_MakeColumnsReadOnly
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
		End Sub
		Private Sub CheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim cb As CheckBox = TryCast(sender, CheckBox)
			MakeColumnReadOnly(FindColumn(cb), DefaultBoolean.False)
		End Sub
		Private Sub CheckBox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim cb As CheckBox = TryCast(sender, CheckBox)
			MakeColumnReadOnly(FindColumn(cb), DefaultBoolean.True)
		End Sub
		Private Sub MakeColumnReadOnly(ByVal col As AgDataGridColumn, ByVal isReadOnly As DefaultBoolean)
			If col IsNot Nothing Then
				col.AllowEditing = isReadOnly
			End If
		End Sub
		Private Function FindColumn(ByVal cb As CheckBox) As AgDataGridColumn
			If cb Is cbCompanyName Then
				Return grid.Columns("CompanyName")
			End If
			If cb Is cbUnitPrice Then
				Return grid.Columns("UnitPrice")
			End If
			If cb Is cbQuantity Then
				Return grid.Columns("Quantity")
			End If
			Return Nothing
		End Function
	End Class
End Namespace
