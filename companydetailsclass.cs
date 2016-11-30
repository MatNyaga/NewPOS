using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS
{
   public class companydetailsclass
    {
        public String merchantcode, email, role, type, phone, password;
        summaryreportTableAdapters.tblCompanyDetailsTableAdapter CompanyDetailsTableAdapter = new summaryreportTableAdapters.tblCompanyDetailsTableAdapter();
        summaryreportTableAdapters.tblUsersTableAdapter UserDetailsTableAdapter = new summaryreportTableAdapters.tblUsersTableAdapter();
        public void insertdetails(String mcode, String eml, String rle, String tpe, String phne, String pass)
        {
            merchantcode = mcode;
            email = eml;
            role = rle;
            type = tpe;
            phone = phne;
            password = pass;
        }
        public String savedetails()
        {
            try
            {
                CompanyDetailsTableAdapter.InsertCompanyDetails("N/A", email, "N/A", "N/A", phone, "N/A", "N/A", merchantcode);
                return "Success";
            }
            catch (Exception io) { return io.Message; }
            }

        public String DefaultUser()
        {
            try
            {
                UserDetailsTableAdapter.InsertNewUser(phone, password, merchantcode, type, email);
                return "Success";
            }
            catch (Exception io) { return io.Message; }
        }

    }
        
}

