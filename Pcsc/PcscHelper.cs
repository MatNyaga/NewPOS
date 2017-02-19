using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acs;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Acs.Readers.Pcsc
{
    public class DriverDetails
    {
        private string _vendorName = "";
        private string _providerName = "";
        private string _name = "";
        private string _description = "";
        private DateTime _date;
        private string _version = "";

        public string vendorName
        {
            get { return _vendorName; }
            set { _vendorName = value; }
        }

        public string providerName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string version
        {
            get { return _version; }
            set { _version = value; }
        }

    }

    public class PcscHelper
    {
        public static string[] getAllReaders()
        {
            int ReaderCount = 255;
            byte[] retData;
            byte[] sReaderGroup = null;
            string readerStr = string.Empty;
            string[] readerList = null;
            int retCode;
            IntPtr hContext = new IntPtr();

            retCode = PcscProvider.SCardEstablishContext(PcscProvider.SCARD_SCOPE_USER, 0, 0, ref hContext);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                throw new PcscException(retCode);

            retCode = PcscProvider.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                throw new PcscException(retCode);

            retData = new byte[ReaderCount];

            retCode = PcscProvider.SCardListReaders(hContext, sReaderGroup, retData, ref ReaderCount);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                if (retCode != PcscProvider.SCARD_S_SUCCESS)
                    throw new PcscException(retCode);


            readerStr = System.Text.ASCIIEncoding.ASCII.GetString(retData).Trim('\0');
            readerList = readerStr.Split('\0');

            return readerList;
        }

        public static bool CardPresent(string readerName)
        {
            int retCode;
            IntPtr hContext = new IntPtr();
            retCode = PcscProvider.SCardEstablishContext(PcscProvider.SCARD_SCOPE_USER, 0, 0, ref hContext);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                throw new Exception("Unable to establish context", new Exception(PcscProvider.GetScardErrMsg(retCode)));

            PcscProvider.SCARD_READERSTATE state = new PcscProvider.SCARD_READERSTATE();
            state.szReader = readerName;

            retCode = PcscProvider.SCardGetStatusChange(hContext, 3000, ref state, 1);
            if (retCode != 0)
                throw new Exception("Unable to get status", new Exception(PcscProvider.GetScardErrMsg(retCode)));
            else
            {
                //state.dwCurrentState >>= 32;
                if (((Int32)(state.dwEventState) & PcscProvider.SCARD_STATE_PRESENT) == PcscProvider.SCARD_STATE_PRESENT)
                    return true;
                else
                    return false;
            }
        }

        public static List<string> getAllReaders(string readerNameContains)
        {
            int ReaderCount = 255;
            byte[] retData;
            byte[] sReaderGroup = null;
            string readerStr = string.Empty;
            string[] readerList = null;
            List<string> finalReaderList;
            int retCode;
            IntPtr hContext = new IntPtr();

            retCode = PcscProvider.SCardEstablishContext(PcscProvider.SCARD_SCOPE_USER, 0, 0, ref hContext);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                throw new PcscException(retCode);

            retCode = PcscProvider.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                throw new PcscException(retCode);

            retData = new byte[ReaderCount];

            retCode = PcscProvider.SCardListReaders(hContext, sReaderGroup, retData, ref ReaderCount);
            if (retCode != PcscProvider.SCARD_S_SUCCESS)
                if (retCode != PcscProvider.SCARD_S_SUCCESS)
                    throw new PcscException(retCode);


            readerStr = System.Text.ASCIIEncoding.ASCII.GetString(retData).Trim('\0');
            readerList = readerStr.Split('\0');

            finalReaderList = new List<string>();
            foreach (string rdr in readerList)
            {
                if (!rdr.Contains(readerNameContains))
                    continue;

                finalReaderList.Add(rdr);
            }

            return finalReaderList;
        }

        public string[] getAllReaders(params string[] readerNameContains)
        {
            string[] readers = getAllReaders();
            List<string> filteredReaderList = new List<string>();

            if (readers == null || readers.Length < 1)
                return new string[0];

            for (int i = 0; i < readers.Length; i++)
            {
                for (int j = 0; j < readerNameContains.Length; j++)
                {
                    if (Regex.IsMatch(readers[i], string.Format(@"{0}\b", readerNameContains[j])))
                        filteredReaderList.Add(readers[i]);
                }
            }

            return filteredReaderList.ToArray();
        }

        public static byte[] getAtr(string readerName)
        {
            byte[] atr; 
            int retCode;
            IntPtr hContext = new IntPtr();

            try
            {
                PcscProvider.SCARD_READERSTATE state = new PcscProvider.SCARD_READERSTATE();
                state.szReader = readerName;

                retCode = PcscProvider.SCardEstablishContext(PcscProvider.SCARD_SCOPE_USER, 0, 0, ref hContext);
                if (retCode != PcscProvider.SCARD_S_SUCCESS)
                    return null;

                retCode = PcscProvider.SCardGetStatusChange(hContext, 3000, ref state, 1);
                if (retCode != 0)
                {
                    atr = null;
                }
                else
                {
                    if ((state.dwEventState & PcscProvider.SCARD_STATE_PRESENT) == PcscProvider.SCARD_STATE_PRESENT)
                        atr = state.rgbAtr.Take(state.cbAtr).ToArray();
                    else
                        atr = null;
                }

                PcscProvider.SCardReleaseContext(hContext);

                return atr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DriverDetails getDriverDetails(string readerName)
        {
            RegistryKey root = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\{50DD5230-BA8A-11D1-BF5D-0000F805F530}");
            DriverDetails driverDetails = null;
            string strDateTime = "", driverDesc = "";
            string[] arrayStr;
            int tmpInt;
            DateTime driverDate;

            try
            {

                readerName = readerName.Replace("ACS", "").TrimStart(' ').TrimEnd(' ');

                arrayStr = readerName.Split(' ');
                if (arrayStr.Length > 1)
                {
                    if (int.TryParse(arrayStr[arrayStr.Length - 1], out tmpInt))
                    {
                        arrayStr = arrayStr.Take(arrayStr.Length - 1).ToArray();
                        readerName = string.Join(" ", arrayStr).Trim(' ');
                    }
                }


                foreach (string keyname in root.GetSubKeyNames())
                {
                    using (RegistryKey key = root.OpenSubKey(keyname))
                    {

                        driverDesc = key.GetValue("DriverDesc", "NotFound").ToString();
                        if (driverDesc == "NotFound")
                            continue;
                        if (!driverDesc.Contains(readerName))
                            continue;

                        driverDetails = new DriverDetails();

                        driverDetails.description = key.GetValue("DriverDesc", "").ToString();
                        driverDetails.providerName = key.GetValue("ProviderName", "").ToString();
                        driverDetails.version = key.GetValue("DriverVersion", "").ToString();
                        driverDetails.name = key.GetValue("IFDName", "").ToString();
                        strDateTime = key.GetValue("DriverDate", "").ToString();

                        if (strDateTime != "")
                        {
                            if (DateTime.TryParse(strDateTime, out driverDate))
                            {
                                driverDetails.date = driverDate;
                            }
                        }

                        break;
                    }
                }

                return driverDetails;
            }
            catch (Exception)
            {
                return null;
            }

            

        }

        
    }
}
