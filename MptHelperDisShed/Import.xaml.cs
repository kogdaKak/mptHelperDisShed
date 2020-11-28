using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Data.SqlClient;
using Action = System.Action;

namespace MptHelperDisShed
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private string QRE = "";
        private string QRG = "";
        private string QRC = "";
        private string QRT = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        public string Form_Of_Control_ID = "";
        public string numberSpeciality = "";
        public int nameSpecialty = 4;
        public string ID_Specialty = "";


        private void btImport_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                txtFilePath.Text = openfile.FileName;
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); ;
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                int row = 9;
                int cell = 3;

                //1 страница
                int CounterLIST = xlWorkbook.Sheets.Count;
                if (CounterLIST <= 4)
                {

                    //Sotrydniki
                    int rowS = 13;
                    int cellS = 3;

                    // Создаем экземпляр Regex  
                    Regex rg = new Regex(@"[А-Я]{1}[.]{1}[А-Я]{1}[.]{1} [А-Я]{1}([а-я]{0,17})?([a-z]{0,17})?");
                    _Worksheet list_11 = (_Worksheet)xlWorkbook.Sheets[1];//Получаем 1 лист
                    Range xlRange_11 = list_11.UsedRange;//Получаем используемый сектор ячеек в листе
                    string authors;
                    while (rowS <= 13)
                    {
                        while (cellS <= 9)
                        {
                            authors = xlRange_11.Cells[rowS, cellS].Text;
                            // Получаем все совпадения  
                            MatchCollection matchedAuthors = rg.Matches(authors);
                            /// Выводим всех подходящих авторов  
                            foreach (Match match in matchedAuthors)
                            {
                                try
                                {
                                    String value = match.ToString();
                                    String Surname = value.Substring(0, 2);
                                    String Name = value.Substring(2, 2);
                                    String FirstName = value.Substring(5);
                                    queryOfTables("INSERT INTO Employees values('" + Surname + "','" + Name + "' ,'" + FirstName + "' , 1 )");
                                }
                                catch
                                {

                                }
                            }
                            cellS++;
                        }  //Sotrydniki
                        cellS = 3;
                        rowS++;

                        _Worksheet list_1 = (_Worksheet)xlWorkbook.Sheets[1];//Получаем первый лист
                        Range xlRange_1 = list_1.UsedRange;//Получаем используемый сектор ячеек в листе
                        while (cell <= 9)
                        {
                            if (cell == 3)
                            {
                                if (xlRange_1.Cells[row, cell].value == null)
                                {

                                }
                                else
                                {
                                    numberSpeciality = xlRange_1.Cells[row, cell].Text;// Таблица специальность
                                    string[] wordss = numberSpeciality.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int Counter = wordss.Count();
                                    if (Counter == 2)
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                            string numberSpecialitysecondd = wordss[1];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                        }
                                        catch
                                        {

                                        }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            if (cell == 6)
                            {
                                if (xlRange_1.Cells[row, cell].value == null)
                                {
                                }
                                else
                                {
                                    numberSpeciality = xlRange_1.Cells[row, cell].Text;// Таблица специальность
                                    string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                    // new char[] - массив символов-разделителей. Как меня поправили в 
                                    // комментариях, в данном случае достаточно написать text.Split(':')
                                    int Counter = wordss.Count();
                                    if (Counter == 2)
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                            string numberSpecialitysecondd = wordss[1];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            if (cell == 9)
                            {
                                if (xlRange_1.Cells[row, cell].value == null)
                                {
                                }
                                else
                                {
                                    numberSpeciality = xlRange_1.Cells[row, cell].Text;// Таблица специальность
                                    string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                    // new char[] - массив символов-разделителей. Как меня поправили в 
                                    // комментариях, в данном случае достаточно написать text.Split(':')

                                    int Counter = wordss.Count();
                                    if (Counter == 2)
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                            string numberSpecialitysecondd = wordss[1];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            string numberSpecialityfirstt = wordss[0];
                                            queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            cell++;
                        }
                        cell = 3;
                    }
                }
                else
                {
                }

                //2 страница
                if (CounterLIST <= 4)
                {
                    //Sotrydniki
                    int rowS = 13;
                    int cellS = 3;

                    // Создаем экземпляр Regex  
                    Regex rg = new Regex(@"[А-Я]{1}[.]{1}[А-Я]{1}[.]{1} [А-Я]{1}([а-я]{0,17})?([a-z]{0,17})?");
                    _Worksheet list_11 = (_Worksheet)xlWorkbook.Sheets[2];//Получаем 2 лист
                    Range xlRange_11 = list_11.UsedRange;//Получаем используемый сектор ячеек в листе
                    string authors;
                    while (rowS <= 13)
                    {
                        while (cellS <= 9)
                        {
                            authors = xlRange_11.Cells[rowS, cellS].Text;
                            // Получаем все совпадения  
                            MatchCollection matchedAuthors = rg.Matches(authors);
                            /// Выводим всех подходящих авторов  
                            foreach (Match match in matchedAuthors)
                            {
                                try
                                {
                                    String value = match.ToString();
                                    String Surname = value.Substring(0, 2);
                                    String Name = value.Substring(2, 2);
                                    String FirstName = value.Substring(5);
                                    queryOfTables("INSERT INTO Employees values('" + Surname + "','" + Name + "' ,'" + FirstName + "' , 1 )");
                                }
                                catch
                                {

                                }
                            }
                            cellS++;
                        }
                        cellS = 3;
                        rowS++;
                    }  //Sotrydniki

                    _Worksheet list_2 = (_Worksheet)xlWorkbook.Sheets[2];//Получаем 2 лист
                    Range xlRange_2 = list_2.UsedRange;//Получаем используемый сектор ячеек в листе
                    while (cell <= 9)
                    {
                        if (cell == 3)
                        {
                            if (xlRange_2.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_2.Cells[row, cell].Text;// Таблица специальность
                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 6)
                        {
                            if (xlRange_2.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_2.Cells[row, cell].Text;// Таблица специальность
                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 9)
                        {
                            if (xlRange_2.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_2.Cells[row, cell].Text;// Таблица специальность
                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        cell++;
                    }
                    cell = 3;
                }
                else
                {
                }
                //3 страница
                if (CounterLIST <= 4)
                {
                    //Sotrydniki
                    int rowS = 13;
                    int cellS = 3;

                    // Создаем экземпляр Regex  
                    Regex rg = new Regex(@"[А-Я]{1}[.]{1}[А-Я]{1}[.]{1} [А-Я]{1}([а-я]{0,17})?([a-z]{0,17})?");
                    _Worksheet list_11 = (_Worksheet)xlWorkbook.Sheets[3];//Получаем 3 лист
                    Range xlRange_11 = list_11.UsedRange;//Получаем используемый сектор ячеек в листе
                    string authors;
                    while (rowS <= 13)
                    {
                        while (cellS <= 9)
                        {
                            authors = xlRange_11.Cells[rowS, cellS].Text;
                            // Получаем все совпадения  
                            MatchCollection matchedAuthors = rg.Matches(authors);
                            /// Выводим всех подходящих авторов  
                            foreach (Match match in matchedAuthors)
                            {
                                try
                                {
                                    String value = match.ToString();
                                    String Surname = value.Substring(0, 2);
                                    String Name = value.Substring(2, 2);
                                    String FirstName = value.Substring(5);
                                    queryOfTables("INSERT INTO Employees values('" + Surname + "','" + Name + "' ,'" + FirstName + "' , 1 )");
                                }
                                catch
                                {

                                }
                            }
                            cellS++;
                        }
                        cellS = 3;
                        rowS++;
                    }  //Sotrydniki

                    //читаем данные из Excel c 3 листа
                    _Worksheet list_3 = (_Worksheet)xlWorkbook.Sheets[3];//Получаем 3 лист
                    Range xlRange_3 = list_3.UsedRange;//Получаем используемый сектор ячеек в листе
                    while (cell <= 9)
                    {
                        if (cell == 3)
                        {
                            if (xlRange_3.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_3.Cells[row, cell].Text;// Таблица специальность
                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 6)
                        {
                            if (xlRange_3.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_3.Cells[row, cell].Text;// Таблица специальность
                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 9)
                        {
                            if (xlRange_3.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_3.Cells[row, cell].Text;// Таблица специальность

                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        cell++;
                    }
                    cell = 3;

                }
                else
                {
                }

                //4 страница
                if (CounterLIST == 4)
                {
                    //Sotrydniki
                    int rowS = 13;
                    int cellS = 3;

                    // Создаем экземпляр Regex  
                    Regex rg = new Regex(@"[А-Я]{1}[.]{1}[А-Я]{1}[.]{1} [А-Я]{1}([а-я]{0,17})?([a-z]{0,17})?");
                    _Worksheet list_11 = (_Worksheet)xlWorkbook.Sheets[4];//Получаем 4 лист
                    Range xlRange_11 = list_11.UsedRange;//Получаем используемый сектор ячеек в листе
                    string authors;
                    while (rowS <= 13)
                    {
                        while (cellS <= 9)
                        {
                            authors = xlRange_11.Cells[rowS, cellS].Text;
                            // Получаем все совпадения  
                            MatchCollection matchedAuthors = rg.Matches(authors);
                            /// Выводим всех подходящих авторов  
                            foreach (Match match in matchedAuthors)
                            {
                                try
                                {
                                    String value = match.ToString();
                                    String Surname = value.Substring(0, 2);
                                    String Name = value.Substring(2, 2);
                                    String FirstName = value.Substring(5);
                                    queryOfTables("INSERT INTO Employees values('" + Surname + "','" + Name + "' ,'" + FirstName + "' , 1 )");
                                }
                                catch
                                {

                                }
                            }
                            cellS++;
                        }
                        cellS = 3;
                        rowS++;
                    }  //Sotrydniki

                    //читаем данные из Excel c 4 листа
                    _Worksheet list_4 = (_Worksheet)xlWorkbook.Sheets[4];//Получаем 4 лист
                    Range xlRange_4 = list_4.UsedRange;//Получаем используемый сектор ячеек в листе
                    while (cell <= 9)
                    {
                        if (cell == 3)
                        {
                            if (xlRange_4.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_4.Cells[row, cell].Text;// Таблица специальность

                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 6)
                        {
                            if (xlRange_4.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_4.Cells[row, cell].Text;// Таблица специальность

                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        if (cell == 9)
                        {
                            if (xlRange_4.Cells[row, cell].value == null)
                            {
                            }
                            else
                            {
                                numberSpeciality = xlRange_4.Cells[row, cell].Text;// Таблица специальность

                                string[] wordss = numberSpeciality.Split(new char[] { ',' });
                                // new char[] - массив символов-разделителей. Как меня поправили в 
                                // комментариях, в данном случае достаточно написать text.Split(':')

                                int Counter = wordss.Count();
                                if (Counter == 2)
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");

                                        string numberSpecialitysecondd = wordss[1];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialitysecondd + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string numberSpecialityfirstt = wordss[0];
                                        queryOfTables("INSERT INTO GGroup values('" + numberSpecialityfirstt + "', '" + nameSpecialty + "' )");
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                        cell++;
                    }
                }
                else
                {
                }
            }
            dgEmployes(QRE);
            dgGroup(QRG);
            dgCabinetes(QRC);
            dgTerritory(QRT);
        }

        private void queryOfTables(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Data Source = 89.179.240.226,63388;" +
            "Initial Catalog = Educational_institution; Persist Security Info=True; User ID = DmitrovDA; Password = $5ff3E");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteScalar();
            connection.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgEmployes(string qr)
        {
            {
                Action action = () =>
                {
                    DBConnection connection = new DBConnection();
                    DBConnection.qrEmployees = qr;
                    connection.EmployeesFill();
                    connection.Dependency.OnChange += Dependency_OnChangeEmploye;
                    Employe.ItemsSource = connection.dtEmployees.DefaultView;
                    Employe.Columns[0].Visibility = Visibility.Collapsed;
                    Employe.Columns[4].Visibility = Visibility.Collapsed;
                };
                Dispatcher.Invoke(action);
            }
        }

        private void Dependency_OnChangeEmploye(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgEmployes(QRE);
            dgGroup(QRG);
            dgCabinetes(QRC);
            dgTerritory(QRT);
        }

        private void dgGroup(string qr)
        {
            {
                Action action = () =>
                {
                    DBConnection connection = new DBConnection();
                    DBConnection.qrGGroup = qr;
                    connection.GGroupFill();
                    connection.Dependency.OnChange += Dependency_OnChangeEmploye;
                    Group.ItemsSource = connection.dtGGroup.DefaultView;
                    Group.Columns[0].Visibility = Visibility.Collapsed;
                    Group.Columns[2].Visibility = Visibility.Collapsed;
                };
                Dispatcher.Invoke(action);
            }
        }

        private void dgCabinetes(string qr)
        {
            {
                Action action = () =>
                {
                    DBConnection connection = new DBConnection();
                    DBConnection.qrTerritory_Аudiences = qr;
                    connection.Territory_АudiencesFill();
                    connection.Dependency.OnChange += Dependency_OnChangeEmploye;
                    Cabinetes.ItemsSource = connection.dtTerritory_Аudiences.DefaultView;
                    Cabinetes.Columns[0].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[2].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[3].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[4].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[5].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[6].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[7].Visibility = Visibility.Collapsed;
                    Cabinetes.Columns[8].Visibility = Visibility.Collapsed;
                };
                Dispatcher.Invoke(action);
            }
        }

        private void dgTerritory(string qr)
        {
            {
                Action action = () =>
                {
                    DBConnection connection = new DBConnection();
                    DBConnection.qrTraning_Area = qr;
                    connection.Traning_AreaFill();
                    connection.Dependency.OnChange += Dependency_OnChangeEmploye;
                    Territory.ItemsSource = connection.dtTraning_Area.DefaultView;
                    Territory.Columns[0].Visibility = Visibility.Collapsed;
                };
                Dispatcher.Invoke(action);
            }
        }

        private void Employe_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
            }
        }

        private void Group_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Group"):
                    e.Column.Header = "Название группы";
                    break;
            }
        }

        private void Cabinetes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Number_Cabinet"):
                    e.Column.Header = "Номер кабинета";
                    break;
            }
        }

        private void Territory_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Full_Name"):
                    e.Column.Header = "Полное наименование";
                    break;
                case ("Abbreviated_Name"):
                    e.Column.Header = "Аббревиатура";
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QRE = DBConnection.qrEmployees;
            QRG = DBConnection.qrGGroup;
            QRC = DBConnection.qrTerritory_Аudiences;
            QRT = DBConnection.qrTraning_Area;
            dgEmployes(QRE);
            dgGroup(QRG);
            dgCabinetes(QRC);
            dgTerritory(QRT);
        }
    }
}

