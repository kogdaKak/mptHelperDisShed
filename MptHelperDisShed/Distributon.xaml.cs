using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Action = System.Action;
using Window = System.Windows.Window;

namespace MptHelperDisShed
{
    /// <summary>
    /// Логика взаимодействия для Distributon.xaml
    /// </summary>
    public partial class Distributon : Window
    {
        private string QR = "";
        DBProcedures procedures = new DBProcedures();
        public Distributon()
        {
            InitializeComponent();
        }

        private void lbFill()
        {
            DBConnection connection = new DBConnection();
            connection.qrNamesFIll();
            cbTy.ItemsSource = connection.dtNames.DefaultView;
            cbTy.SelectedValuePath = "ID_NLP";
            cbTy.DisplayMemberPath = "Sotrydniki";
            connection.qrEmployyeFill();
            cbOne.ItemsSource = connection.dtEmployye.DefaultView;
            cbOne.SelectedValuePath = "ID_Territory_Аudiences";
            cbOne.DisplayMemberPath = "Cabinetes";
        }

        private void dgFill(string qr)
        {
            {
                Action action = () =>
                {
                    DBConnection connection = new DBConnection();
                    DBConnection.qrRaspredelenie_View = qr;
                    connection.Raspredelenie_ViewFill();
                    connection.Dependency.OnChange += Dependency_OnChange;
                    dgDistribution.ItemsSource = connection.dtRaspredelenie_View.DefaultView;
                    dgDistribution.Columns[0].Visibility = Visibility.Collapsed;
                };
                Dispatcher.Invoke(action);
            }
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void dgDistribution_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Surname"):
                    e.Column.Header = "Фамилия";
                    break;
                case ("Name"):
                    e.Column.Header = "Имя";
                    break;
                case ("Second_Name"):
                    e.Column.Header = "Отчество";
                    break;
                case ("Priority"):
                    e.Column.Header = "Приоритет";
                    break;
                case ("Number_Cabinet"):
                    e.Column.Header = "Номер кабинета";
                    break;
                case ("Full_Name"):
                    e.Column.Header = "Территория";
                    break;
            }
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            if (cbOne.SelectedValue == "")
            {
                System.Windows.MessageBox.Show("Ошибка1?", "Вы не выбрали значение 1", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbTy.SelectedValue == "")
            {
                System.Windows.MessageBox.Show("Ошибка2?", "Вы не выбрали значение 2 ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (tbText.Text == "")
            {
                System.Windows.MessageBox.Show("Ошибка3?", "Вы не ввели значение ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    procedures.spdistribution_insert(Convert.ToInt32(tbText.Text), Convert.ToInt32(cbOne.SelectedValue), Convert.ToInt32(cbTy.SelectedValue));
                    dgFill(QR);
                }
                catch
                {
                    MessageBox.Show("Haha");
                }
            }
        }
        private void windowWidthHeigh()
        {
            dgDistribution.Width = Window.Width;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDistribution.SelectedValue;
            try
            {
                procedures.spdistribution_Update(Convert.ToInt32(ID["ID_Distribution"]), Convert.ToInt32(tbText.Text), Convert.ToInt32(cbOne.SelectedValue), Convert.ToInt32(cbTy.SelectedValue));
                dgFill(QR);
            }
            catch
            {
                MessageBox.Show("Haha");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (System.Windows.MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID = (DataRowView)dgDistribution.SelectedItems[0];
                    try
                    {
                        procedures.spdistribution_delete(Convert.ToInt32(ID["ID_Distribution"]));
                        dgFill(QR);
                    }
                    catch
                    {
                        MessageBox.Show("Haha");
                    }
                    break;
            }
        }

        private void cbInfoGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR +
                        " where [ID_Territory_Аudiences] = "
                        + cbOne.SelectedValue.ToString();
                    dgFill(newQR);
                    break;
                case (false):
                    dgFill(QR);
                    break;
            }
        }

        private void cbInfoGroup_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR +
                        " where [ID_NLP] = "
                        + cbTy.SelectedValue.ToString();
                    dgFill(newQR);
                    break;
                case (false):
                    dgFill(QR);
                    break;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            Range range;
            Range myRange;
            for (int i = 1; i < dgDistribution.Columns.Count; i++)
            {
                range = (Range)sheet1.Cells[1, i + 1];
                sheet1.Cells[1, i + 1].Font.Bold = true;
                range.Value = dgDistribution.Columns[i].Header;

                for (int j = 0; j < dgDistribution.Items.Count; j++)
                {
                    TextBlock b = dgDistribution.Columns[i].GetCellContent(dgDistribution.Items[j]) as TextBlock;
                    myRange = sheet1.Cells[j + 2, i + 1];
                    myRange.Value = b.Text;
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrRaspredelenie_View;
            dgFill(QR);
            lbFill();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow import = new MainWindow();
            import.Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgDistribution.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == cbOne.Text ||
                    (dataRow.Row.ItemArray[2].ToString() == cbTy.Text ||
                    (dataRow.Row.ItemArray[2].ToString() == tbText.Text)))
                {
                    dgDistribution.SelectedItem = dataRow;
                }
            }
        }
    }
}
