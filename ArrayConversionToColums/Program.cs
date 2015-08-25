using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConversionToColums
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("MiddelName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("City");
            dt.Columns.Add("State");
            dt.Columns.Add("Zip");

            string[] strArray = "naveen, kumar, katara, , CA, 92606".Split(Char.Parse(","));
            string[] strArray1 = "Aadhya, , Adtya, Irvine, CA, 98623".Split(Char.Parse(","));
            string[] strArray2 = "xyz, , mno".Split(Char.Parse(","));

            var convertedTable = GetDataTable(strArray, dt);
            convertedTable = GetDataTable(strArray1, dt);
            
            //PRASHANT: This is your final table after convirsion of all array data to dataTable
            convertedTable = GetDataTable(strArray2, dt);
        }

        /// <summary>
        /// Generic method to convert array to given data table
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string[] stringArray, DataTable dataTable)
        {
            if (stringArray != null && stringArray.Length > 0 && dataTable != null)
            {
                var dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);

                foreach (string stringVal in stringArray)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][Array.IndexOf(stringArray, stringVal)] = stringVal;
                }
            }
            return dataTable;
        }
    }
}