using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public class stockitem
    {

        public int amountsold, currentstock;

        summaryreportTableAdapters.tblProductTableAdapter ProductTableAdapter = new summaryreportTableAdapters.tblProductTableAdapter();

        public String OpeningStock(int ProductId)
        {
            DataTable products =  ProductTableAdapter.GetData();

            foreach (DataRow row in products.Rows)
            {
                foreach (DataColumn column in products.Columns)
                {
                    if (row[column].ToString() == ProductId.ToString())
                    {
                        return (row["openingstock"].ToString());
                    }
                }
            }
            return "";
        }

        public String AmountSold(int ProductId)
        {
            DataTable products = ProductTableAdapter.GetData();

            foreach (DataRow row in products.Rows)
            {
                foreach (DataColumn column in products.Columns)
                {
                    if (row[column].ToString() == ProductId.ToString())
                    {
                        return (row["amountsold"].ToString());
                    }
                }
            }
            return "";
        }

        public void UpdateStock(int Productid, int number)
        {
            try
            {
                amountsold = Convert.ToInt32(AmountSold(Productid));
                currentstock = Convert.ToInt32(OpeningStock(Productid));
                amountsold = amountsold + number;
                currentstock = currentstock - number;
            }
            catch (Exception io) { }            
        }
        public void SaveStock(int Productid)
        {
            ProductTableAdapter.UpdateStockQuery(currentstock, amountsold, Productid);

        }
    }

    
}
