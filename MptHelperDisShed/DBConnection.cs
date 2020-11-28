using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MptHelperDisShed
{
    class DBConnection
    {
        public SqlDependency Dependency = new SqlDependency();
        public static SqlConnection Connection = new SqlConnection(
            "Server = 89.179.240.226,63388; " + "Initial Catalog = Educational_institution; Persist Security Info = true; multipleactiveresultsets=True;" +
            "User ID=DmitrovDA; Password=\"$5ff3E\"");

        public DataTable dtDistribution = new DataTable("Distribution");
        public DataTable dtSchedule_NLP = new DataTable("Schedule_NLP");

        //Витины
        public DataTable dtTerritory_Аudiences = new DataTable("Territory_Аudiences");
        public DataTable dtTraning_Area = new DataTable("Traning_Area");
        //Вовы
        public DataTable dtNLP = new DataTable("NLP");
        public DataTable dtGGroup = new DataTable("GGroup");
        //Саши
        public DataTable dtEmployees = new DataTable("Employees");

        //Представления
        public DataTable dtRaspredelenie_View = new DataTable("Raspredelenie_View");

        //Представление в ЛББОХ
        public DataTable dtEmployye = new DataTable("Distribution");
        public DataTable dtNames = new DataTable("Distribution");

        public static Int32 ID_User = 0;
        public static string
        qrDistribution = "SELECT  [ID_Distribution], [Priority], [Number_Cabinet], [Date_Forming] from [dbo].[Distribution]" +
            "INNER JOIN [dbo].[Territory_Аudiences]" +
            "ON [dbo].[Distribution].[Territory_Аudiences_ID]" +
            "= [dbo].[Territory_Аudiences].[ID_Territory_Аudiences]" +

            "INNER JOIN [dbo].[NLP]" +
            "ON [dbo].[Distribution].[NLP_ID]" +
            "= [dbo].[NLP].[ID_NLP]",

        qrSchedule_NLP = "SELECT [ID_Schedule_NLP] , [Order_Week],[Day_Week],[Number_Classes],[Date_Forming] from [dbo].[Schedule_NLP]" +

            "INNER JOIN [dbo].[NLP]" +
            "ON [dbo].[Schedule_NLP].[NLPp_ID]" +
            "= [dbo].[NLP].[ID_NLP]",


        //Витины таблицы
        qrTerritory_Аudiences = "SELECT [ID_Territory_Аudiences],[Number_Cabinet],[Position_X],[Position_Y],[Width],[Height],[Color_ID],[Traning_Area_ID],[View_ID] from [dbo].[Territory_Аudiences]",
        qrTraning_Area = "SELECT [ID_Training_Area],[Full_Name],[Abbreviated_Name] from [dbo].[Traning_Area]",
        //Вовы таблицы
        qrNLP = "SELECT [ID_NLP],[Date_Forming],[Number_Of_Weeks],[Hours_Per_Week],[EU_CMK_RUP_NLP_ID],[Group_ID],[Distribution_ID] from [dbo].[NLP]",
        qrGGroup = "SELECT [ID_Group],[Name_Group],[Specialty_ID] from [dbo].[GGroup]",
        //Таблицы Саши
        qrEmployees = "SELECT [Id_Employee],[Surname],[Name],[Second_Name],[Employee_Number] from [dbo].[Employees]",

        //Представления
         qrRaspredelenie_View = "SELECT [Distribution].[ID_Distribution] ,[Employees].[Name] ,[Employees].[Surname] ,[Employees].[Second_Name]  ,[Distribution].[Priority]" +
            ",[Territory_Аudiences].[Number_Cabinet] ,[Traning_Area].[Full_Name] FROM [dbo].[Distribution]" +

                "INNER JOIN [dbo].[Territory_Аudiences] ON [Distribution].[Territory_Аudiences_ID] = [Territory_Аudiences].[ID_Territory_Аudiences]" +
                "INNER JOIN [dbo].[Traning_Area] ON [Territory_Аudiences].[Traning_Area_ID] = [Traning_Area].[ID_Training_Area] " +
                "INNER JOIN [dbo].[NLP] ON [Distribution].[NLP_ID] = [NLP].[ID_NLP]" +
                "INNER JOIN [dbo].[Distribution_CMK] ON [NLP].[Distribution_ID] = [Distribution_CMK].[ID_Distribution] " +
                "INNER JOIN [dbo].[Plurality] ON [Distribution_CMK].[Plurality_Distribution_ID] = [Plurality].[Id_Plurality]" +
                "INNER JOIN [dbo].[Employees] ON [Plurality].[EmployeeId_Employee] = [Employees].[Id_Employee]",

        qrEmployye = "SELECT [ID_Territory_Аudiences], [Number_Cabinet] + ' ' + [Abbreviated_Name] as Cabinetes FROM [dbo].[Territory_Аudiences]" +
            "INNER JOIN [dbo].[Traning_Area] ON [Territory_Аudiences].[Traning_Area_ID] = [Traning_Area].[ID_Training_Area]",

        qrNames = "SELECT [ID_NLP], [surname] + ' ' +[name] as Sotrydniki FROM [dbo].[NLP]" +
        "INNER JOIN [dbo].[Distribution_CMK] ON [NLP].[Distribution_ID] = [Distribution_CMK].[ID_Distribution]" +
        "INNER JOIN [dbo].[Plurality] ON [Distribution_CMK].[Plurality_Distribution_ID] = [Plurality].[Id_Plurality]" +
        "INNER JOIN [dbo].[Employees] ON [Plurality].[EmployeeId_Employee] = [Employees].[Id_Employee]";

        private SqlCommand command = new SqlCommand("", Connection);

        public static Int32 IDrecord, IDuser;

        private void DtFill(DataTable table, string query)
        {
            command.Notification = null;
            Dependency.AddCommandDependency(command);
            SqlDependency.Start(Connection.ConnectionString);
            command.CommandText = query;
            Connection.Open();
            table.Load(command.ExecuteReader());
            Connection.Close();
        }

        private string QR = " ";
        public void DistributionFill()
        {
            DtFill(dtDistribution, qrDistribution);
        }

        public void Schedule_NLPFill()
        {
            DtFill(dtSchedule_NLP, qrSchedule_NLP);
        }

        public void Territory_АudiencesFill()
        {
            DtFill(dtTerritory_Аudiences, qrTerritory_Аudiences);
        }

        public void Traning_AreaFill()
        {
            DtFill(dtTraning_Area, qrTraning_Area);
        }

        public void NLPFill()
        {
            DtFill(dtNLP, qrNLP);
        }
        public void GGroupFill()
        {
            DtFill(dtGGroup, qrGGroup);
        }

        public void qrEmployyeFill()
        {
            DtFill(dtEmployye, qrEmployye);
        }

        public void EmployeesFill()
        {
            DtFill(dtEmployees, qrEmployees);
        }
        public void qrNamesFIll()
        {
            DtFill(dtNames, qrNames);
        }
        public void Raspredelenie_ViewFill()
        {
            DtFill(dtRaspredelenie_View, qrRaspredelenie_View);
        }
    }
}
