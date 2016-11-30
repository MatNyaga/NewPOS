using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    class NFCclass
    {
        private int retCode, hContext, hCard, Protocol, ReaderCount;
        private bool connActive = false;
        private byte[] SendBuff = new byte[263];
        private byte[] RecvBuff = new byte[263];
        private int SendLen, RecvLen, ReaderLen, ATRLen, dwState, dwActProtocol;
        private byte[] ATRVal = new byte[257];
        string sReaderList;
        byte[] sReaderGroup;
        private bool autoDet;
        private int nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        private ModWinsCard.SCARD_READERSTATE RdrState;
        private ModWinsCard.SCARD_IO_REQUEST pioSendRequest;
        ToolStripStatusLabel tssl = new ToolStripStatusLabel();
        Label lbl = new Label();
        public System.Windows.Forms.RichTextBox mMsg;
        public System.Windows.Forms.ProgressBar progress;
        pausethreads pause = new pausethreads();
        public string UID = string.Empty;

        public void initializereader(System.Windows.Forms.ComboBox cbReader, ToolStripStatusLabel Tssl)
        {
            tssl = Tssl;
            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";
            //Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");

                return;

            }

            // 2. List PC/SC card readers installed in the system

            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");

                return;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                tssl.Text = ("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));

                return;
            }
            else
            {
                displayOut(0, 0, " ", mMsg);
            }

            rName = "";
            indx = 0;

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {

                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                //Add reader name to list
                cbReader.Items.Add(rName);
                rName = "";
                indx = indx + 1;

            }

            if (cbReader.Items.Count > 0)
            {
                cbReader.SelectedIndex = 0;

            }
            retCode = ModWinsCard.SCardConnect(hContext, cbReader.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_SHARED,
                                             ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "", mMsg);
            }
            else
            {
                displayOut(0, 0, "Successful connection to " + cbReader.Text, mMsg);

            }
            connActive = true;
            loadkeys();
        }

        private void authenticate(string blocknumber)
        {
            int tempInt, indx;
            byte tmpLong;
            string tmpStr;
            ClearBuffers();
            SendBuff[0] = 0xFF;                             // Class
            SendBuff[1] = 0x86;                             // INS
            SendBuff[2] = 0x00;                             // P1
            SendBuff[3] = 0x00;                             // P2
            SendBuff[4] = 0x05;                             // Lc
            SendBuff[5] = 0x00;                             // Byte 1 : Version number
            SendBuff[6] = 0x00;                             // Byte 2
            SendBuff[7] = (byte)int.Parse(blocknumber);                             // Byte 3 : Block number


            SendBuff[8] = 0x61;
            SendBuff[9] = 0x01;                             // Key 5 value

            SendLen = 10;
            RecvLen = 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(0, 0, "Authentication success!", mMsg);
            }
            else
            {
                displayOut(4, 0, "Authentication failed!", mMsg);
            }



        }

        public int SendAPDU(string hexvalue)
        {
            int indx;
            string tmpStr;

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            tmpStr = "";
            for (indx = 0; indx <= SendLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);

            }
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "", mMsg);
                return retCode;

            }
            tmpStr = "";
            for (indx = 0; indx <= RecvLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

            }
            hexvalue = tmpStr.Replace(" ","").Substring(0,8);
            displayOut(3, 0, tmpStr, mMsg);
            return retCode;
        }

        public int SendAPDU()
        {
            int indx;
            string tmpStr;

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            tmpStr = "";
            for (indx = 0; indx <= SendLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);

            }
            displayOut(2, 0, tmpStr, mMsg);
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "", mMsg);
                return retCode;

            }

            tmpStr = "";
            for (indx = 0; indx <= RecvLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

            }

            displayOut(3, 0, tmpStr, mMsg);
            return retCode;

        }

        public void ClearBuffers()
        {

            long indx;

            for (indx = 0; indx <= 262; indx++)
            {

                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;

            }

        }

        private void loadkeys()
        {
            byte tmpLong;
            string tmpStr;

            ClearBuffers();
            displayOut(3, 0, "Clearing Buffers", mMsg);
            // Load Authentication Keys command
            SendBuff[0] = 0xFF;                                                                        // Class
            SendBuff[1] = 0x82;                                                                        // INS
            SendBuff[2] = 0x00;                                                                        // P1 : Key Structure
            SendBuff[3] = 0x00;
            SendBuff[4] = 0x06;                                                                        // P3 : Lc
            SendBuff[5] = 0xD3;        // Key 1 value
            SendBuff[6] = 0xF7;        // Key 2 value
            SendBuff[7] = 0xD3;        // Key 3 value
            SendBuff[8] = 0xF7;        // Key 4 value
            SendBuff[9] = 0xD3;        // Key 5 value
            SendBuff[10] = 0xF7;       // Key 6 value

            displayOut(4, 0, "Setting Key Store No:", mMsg);
            displayOut(0, 0, "Number Set to 0x00", mMsg);
            displayOut(4, 0, "Setting Key Value Input:", mMsg);
            displayOut(0, 0, "Key Value Input set to: FF FF FF FF FF FF", mMsg);
            SendLen = 11;
            RecvLen = 2;

            retCode = SendAPDU();
            displayOut(4, 0, "Sending APDU............................", mMsg);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (int indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() != "90 00")
            {
                displayOut(4, 0, "Load authentication keys error!", mMsg);
            }

        }

        public string readblock(string blocknumber)
        {

            string tmpStr;
            int indx;
            authenticate(blocknumber);
            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x00;
            SendBuff[3] = (byte)int.Parse(blocknumber);
            SendBuff[4] = (byte)int.Parse("16");

            SendLen = 5;
            RecvLen = SendBuff[4] + 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return "";
            }
            else
            {
                tmpStr = "";
                for (indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 3; indx++)
                {

                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }

                return tmpStr;
            }
            else
            {
                displayOut(4, 0, "Read block error!", mMsg);
                return "";
            }
            return "";
        }

        public List<string> readcard(ToolStripStatusLabel tssl, System.Windows.Forms.ComboBox cbReader)
        {
            List<string> nfccard = new List<string>();
            string tmpStr;
            int indx;
            getATR(cbReader);
            progress.Maximum = 29;
            for (int i = 0; i < 29; i++ ){
                ClearBuffers();
                authenticate(i.ToString());
                SendBuff[0] = 0xFF;
                SendBuff[1] = 0xB0;
                SendBuff[2] = 0x00;
                SendBuff[3] = (byte)int.Parse(i.ToString());
                SendBuff[4] = (byte)int.Parse("16");
                SendLen = 5;
                RecvLen = SendBuff[4] + 2;
                if (i == 0)
                {
                    retCode = SendAPDU(UID);
                }
                else
                {
                    retCode = SendAPDU();
                }

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                tssl.Text =  "Unable to readcard";
                    return null;
                }
                else
                {
                tmpStr = "";
                for (indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }

                }
                if (tmpStr.Trim() == "90 00")
                {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 3; indx++)
                {
                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }
                
                nfccard.Add(tmpStr);
                if (progress.Value != 29)
                {
                    progress.Value++;
                }

                pause.Pause(30);
                
            }
            else
            {
                displayOut(4, 0, "Read block error!", mMsg);
                tssl.Text = "Null Bock"; ;
            }
        }
            return nfccard;
        }

        public void writeblock(string blocknumber, string info)
        {
            string tmpStr;
            int indx, tempInt;

            tmpStr = info;
            ClearBuffers();
            authenticate(blocknumber);
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)int.Parse(blocknumber);            // P2 : Starting Block No.
            SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

            for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
            {

                SendBuff[indx + 5] = (byte)tmpStr[indx];

            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(0, 0, "SUCCESS!", mMsg);
            }
            else
            {
                displayOut(2, 0, "", mMsg);
            }
        }

        public void writeNDEFcard(ToolStripStatusLabel tssl, System.Windows.Forms.ComboBox cbReader, List<string> nfccard, string NDEFformat)
        {
            string tmpStr = string.Empty;
            int indx, tempInt;
            progress.Maximum = 29;
            for (int i = 4; i < 29; i++)
            {
                if (i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23 || i == 27 || i == 31)
                {
                    i++;
                }
                try
                {
                    tmpStr = nfccard[i];
                }
                catch (Exception ex) { }
                ClearBuffers();
                if (i == 4)
                {
                    byte[] data = FromHex("00-00-03");
                    string format = Encoding.ASCII.GetString(data);
                    tmpStr = format + "ÚÒ#´a";
                }
                authenticate(i.ToString());
                SendBuff[0] = 0xFF;                                     // CLA
                SendBuff[1] = 0xD6;                                     // INS
                SendBuff[2] = 0x00;                                     // P1
                SendBuff[3] = (byte)int.Parse(i.ToString());            // P2 : Starting Block No.
                SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

                for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
                {

                    SendBuff[indx + 5] = (byte)tmpStr[indx];

                }
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x02;

                retCode = SendAPDU();

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    tmpStr = "";
                    for (indx = 0; indx <= RecvLen - 1; indx++)
                    {

                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                        if (progress.Value != 29)
                        {
                            progress.Value++;
                        }
                        pause.Pause(75);
                    }

                }
                if (tmpStr.Trim() == "90 00")
                {
                    displayOut(0, 0, "SUCCESS!", mMsg);
                }
                else
                {
                    displayOut(2, 0, "", mMsg);
                }
            }
        }

        private static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        public void writecard(ToolStripStatusLabel tssl, System.Windows.Forms.ComboBox cbReader, List<string> nfccard)
        {
            string tmpStr = string.Empty;
            int indx, tempInt;
            progress.Maximum = 29;
            for (int i = 4; i < 29; i++)
            {
                if (i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23 || i == 27 || i == 31)
                {
                    i++;
                }
                try
                {
                    tmpStr = nfccard[i];
                }
                catch (Exception ex) { }
                ClearBuffers();
                authenticate(i.ToString());
                SendBuff[0] = 0xFF;                                     // CLA
                SendBuff[1] = 0xD6;                                     // INS
                SendBuff[2] = 0x00;                                     // P1
                SendBuff[3] = (byte)int.Parse(i.ToString());            // P2 : Starting Block No.
                SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

                for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
                {

                    SendBuff[indx + 5] = (byte)tmpStr[indx];

                }
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x02;

                retCode = SendAPDU();

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    tmpStr = "";
                    for (indx = 0; indx <= RecvLen - 1; indx++)
                    {

                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                        if (progress.Value != 29)
                        {
                            progress.Value++;
                        }
                        pause.Pause(75);
                    }

                }
                if (tmpStr.Trim() == "90 00")
                {
                    displayOut(0, 0, "SUCCESS!", mMsg);
                }
                else
                {
                    displayOut(2, 0, "", mMsg);
                }
            }
        }

       
        public void formatcard(ToolStripStatusLabel tssl, System.Windows.Forms.ComboBox cbReader)
        {
            string tmpStr;
            int indx, tempInt;
            progress.Maximum = 29;
            for (int i = 4; i < 29; i++)
            {
                if (i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23 || i == 27 || i == 31)
                {
                    i++;
                }
                tmpStr = "                ";
                ClearBuffers();
                authenticate(i.ToString());
                SendBuff[0] = 0xFF;                                     // CLA
                SendBuff[1] = 0xD6;                                     // INS
                SendBuff[2] = 0x00;                                     // P1
                SendBuff[3] = (byte)int.Parse(i.ToString());            // P2 : Starting Block No.
                SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

                for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
                {

                    SendBuff[indx + 5] = (byte)tmpStr[indx];

                }
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x02;

                retCode = SendAPDU();

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    tmpStr = "";
                    for (indx = 0; indx <= RecvLen - 1; indx++)
                    {

                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                        if (progress.Value != 29)
                        {
                            progress.Value++;
                        }
                        pause.Pause(45);
                    }

                }
                if (tmpStr.Trim() == "90 00")
                {
                    displayOut(0, 0, "SUCCESS!", mMsg);
                }
                else
                {
                    displayOut(2, 0, "", mMsg);
                }
            }
        }

        public void getATR(System.Windows.Forms.ComboBox cbReader)
        {
            string tmpStr;
            int indx;

            displayOut(0, 0, "Invoke Card Status", mMsg);
            ATRLen = 33;

            retCode = ModWinsCard.SCardStatus(hCard, cbReader.Text, ref ReaderLen, ref dwState, ref dwActProtocol, ref ATRVal[0], ref ATRLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "", mMsg);
                //System.Environment.Exit(0);

            }

            else
            {

                tmpStr = "ATR Length : " + ATRLen.ToString();
                displayOut(3, 0, tmpStr, mMsg);

                tmpStr = "ATR Value : ";

                for (indx = 0; indx <= ATRLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", ATRVal[indx]);

                }

                displayOut(3, 0, tmpStr, mMsg);

            }

            tmpStr = "Active Protocol: ";

            switch (dwActProtocol)
            {

                case 1:
                    tmpStr = tmpStr + "T=0";
                    break;
                case 2:
                    tmpStr = tmpStr + "T=1";
                    break;

                default:
                    tmpStr = "No protocol is defined.";
                    break;
            }

            displayOut(3, 1, tmpStr, mMsg);
            InterpretATR();
        }

        private void InterpretATR()
        {

            string RIDVal, cardName, sATRStr, lATRStr, tmpVal;
            int indx, indx2;

            //4. Interpret ATR and guess card
            // 4.1. Mifare cards using ISO 14443 Part 3 Supplemental Document
            if ((int)(ATRLen) > 14)
            {

                RIDVal = "";
                sATRStr = "";
                lATRStr = "";

                for (indx = 7; indx <= 11; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", ATRVal[indx]);

                }


                for (indx = 0; indx <= 4; indx++)
                {

                    //shift bit to right
                    tmpVal = ATRVal[indx].ToString();

                    for (indx2 = 1; indx2 <= 4; indx2++)
                    {

                        tmpVal = Convert.ToString(Convert.ToInt32(tmpVal) / 2);

                    }

                    if (((indx == '1') & (tmpVal == "8")))
                    {

                        lATRStr = lATRStr + "8X";
                        sATRStr = sATRStr + "8X";
                    }

                    else
                    {

                        if (indx == 4)
                        {

                            lATRStr = lATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);
                        }

                        else
                        {

                            lATRStr = lATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);
                            sATRStr = sATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);

                        }

                    }

                }

                cardName = "";

                if (RIDVal != "A0 00 00 03 06")
                {

                    switch (ATRVal[12])
                    {

                        case 0:
                            cardName = "No card information";
                            break;
                        case 1:
                            cardName = "ISO 14443 A, Part1 Card Type";
                            break;
                        case 2:
                            cardName = "ISO 14443 A, Part2 Card Type";
                            break;
                        case 3:
                            cardName = "ISO 14443 A, Part3 Card Type";
                            break;
                        case 5:
                            cardName = "ISO 14443 B, Part1 Card Type";
                            break;
                        case 6:
                            cardName = "ISO 14443 B, Part2 Card Type";
                            break;
                        case 7:
                            cardName = "ISO 14443 B, Part3 Card Type";
                            break;
                        case 9:
                            cardName = "ISO 15693, Part1 Card Type";
                            break;
                        case 10:
                            cardName = "ISO 15693, Part2 Card Type";
                            break;
                        case 11:
                            cardName = "ISO 15693, Part3 Card Type";
                            break;
                        case 12:
                            cardName = "ISO 15693, Part4 Card Type";
                            break;
                        case 13:
                            cardName = "Contact Card (7816-10) IIC Card Type";
                            break;
                        case 14:
                            cardName = "Contact Card (7816-10) Extended IIC Card Type";
                            break;
                        case 15:
                            cardName = "0Contact Card (7816-10) 2WBP Card Type";
                            break;
                        case 16:
                            cardName = "Contact Card (7816-10) 3WBP Card Type";
                            break;

                    }

                }

                // Felica and Topaz Cards
                if (ATRVal[12] == 0x03)
                {
                    if (ATRVal[13] == 0xF0)
                    {
                        switch (ATRVal[14])
                        {
                            case 0x11:
                                cardName = cardName + ": FeliCa 212K";
                                break;
                            case 0x12:
                                cardName = cardName + ": Felica 424K";
                                break;
                            case 0x04:
                                cardName = cardName + ": Topaz";
                                break;

                        }


                    }
                }


                if (ATRVal[12] == 0x03)
                {

                    if (ATRVal[13] == 0x00)
                    {

                        switch (ATRVal[14])
                        {

                            case 0x01:
                                cardName = cardName + ": Mifare Standard 1K";
                                break;
                            case 0x02:
                                cardName = cardName + ": Mifare Standard 4K";
                                break;
                            case 0x03:
                                cardName = cardName + ": Mifare Ultra light";
                                break;
                            case 0x04:
                                cardName = cardName + ": SLE55R_XXXX";
                                break;
                            case 0x06:
                                cardName = cardName + ": SR176";
                                break;
                            case 0x07:
                                cardName = cardName + ": SRI X4K";
                                break;
                            case 0x08:
                                cardName = cardName + ": AT88RF020";
                                break;
                            case 0x09:
                                cardName = cardName + ": AT88SC0204CRF";
                                break;
                            case 0x0A:
                                cardName = cardName + ": AT88SC0808CRF";
                                break;
                            case 0x0B:
                                cardName = cardName + ": AT88SC1616CRF";
                                break;
                            case 0x0C:
                                cardName = cardName + ": AT88SC3216CRF";
                                break;
                            case 0x0D:
                                cardName = cardName + ": AT88SC6416CRF";
                                break;
                            case 0x0E:
                                cardName = cardName + ": SRF55V10P";
                                break;
                            case 0xF:
                                cardName = cardName + ": SRF55V02P";
                                break;
                            case 0x10:
                                cardName = cardName + ": SRF55V10S";
                                break;
                            case 0x11:
                                cardName = cardName + ": SRF55V02S";
                                break;
                            case 0x12:
                                cardName = cardName + ": TAG IT";
                                break;
                            case 0x13:
                                cardName = cardName + ": LRI512";
                                break;
                            case 0x14:
                                cardName = cardName + ": ICODESLI";
                                break;
                            case 0x15:
                                cardName = cardName + ": TEMPSENS";
                                break;
                            case 0x16:
                                cardName = cardName + ": I.CODE1";
                                break;
                            case 0x17:
                                cardName = cardName + ": PicoPass 2K";
                                break;
                            case 0x18:
                                cardName = cardName + ": PicoPass 2KS";
                                break;
                            case 0x19:
                                cardName = cardName + ": PicoPass 16K";
                                break;
                            case 0x1A:
                                cardName = cardName + ": PicoPass 16KS";
                                break;
                            case 0x1B:
                                cardName = cardName + ": PicoPass 16K(8x2)";
                                break;
                            case 0x1C:
                                cardName = cardName + ": PicoPass 16KS(8x2)";
                                break;

                            case 0x1D:
                                cardName = cardName + ": PicoPass 32KS(16+16)";
                                break;
                            case 0x1E:
                                cardName = cardName + ": PicoPass 32KS(16+8x2)";
                                break;
                            case 0x1F:
                                cardName = cardName + ": PicoPass 32KS(8x2+16)";
                                break;
                            case 0x20:
                                cardName = cardName + ": PicoPass 32KS(8x2+8x2)";
                                break;
                            case 0x21:
                                cardName = cardName + ": LRI64";
                                break;
                            case 0x22:
                                cardName = cardName + ": I.CODE UID";
                                break;
                            case 0x23:
                                cardName = cardName + ": I.CODE EPC";
                                break;
                            case 0x24:
                                cardName = cardName + ": LRI12";
                                break;
                            case 0x25:
                                cardName = cardName + ": LRI128";
                                break;
                            case 0x26:
                                cardName = cardName + ": Mifare Mini";
                                break;


                        }
                    }

                    else
                    {

                        if (ATRVal[13] == 0xFF)
                        {

                            switch (ATRVal[14])
                            {

                                case 0x09:
                                    cardName = cardName + ": Mifare Mini";
                                    break;

                            }

                        }

                    }

                    displayOut(3, 0, cardName + " is detected.", mMsg);
                    tssl.Text = cardName;

                }

            }

            //4.2. Mifare DESFire card using ISO 14443 Part 4
            if ((int)ATRLen == 11)
            {

                RIDVal = "";

                for (indx = 4; indx <= 9; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", ATRVal[indx]);

                }

                if (RIDVal == " 06 75 77 81 02 80")
                {

                    displayOut(3, 0, "Mifare DESFire is detected.", mMsg);
                    tssl.Text = "Mifare DESFire is detected";

                }

            }

            //4.3. Other cards using ISO 14443 Part 4
            if ((int)ATRLen == 17)
            {

                RIDVal = "";

                for (indx = 4; indx <= 15; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

                if (RIDVal == "50122345561253544E3381C3")
                {

                    displayOut(3, 0, "ST19XRC8E is detected.", mMsg);
                    tssl.Text = "ST19XRC8E is detected.";
                }

            }

            //4.4. other cards using ISO 14443 Type A or B
            lATRStr = "";
            sATRStr = "";

            if (lATRStr == "3B8X800150")
            {

                displayOut(3, 0, "ISO 14443B is detected.", mMsg);
                tssl.Text = "ISO 14443B is detected.";
            }

            else
            {

                if (sATRStr == "3B8X8001")
                {

                    displayOut(3, 0, "ISO 14443A is detected.", mMsg);
                    tssl.Text = "ISO 14443A is detected.";
                }

            }


        }
        private void displayOut(int errType, int retVal, string PrintText, System.Windows.Forms.RichTextBox mMsg) 
        {

            try
            {
                switch (errType)
                {

                    case 0:
                        mMsg.SelectionColor = Color.Green;
                        break;
                    case 1:
                        mMsg.SelectionColor = Color.Red;
                        PrintText = ModWinsCard.GetScardErrMsg(retVal);
                        break;
                    case 2:
                        mMsg.SelectionColor = Color.Black;
                        PrintText = "<" + PrintText;
                        break;
                    case 3:
                        mMsg.SelectionColor = Color.Black;
                        PrintText = ">" + PrintText;
                        break;
                    case 4:
                        break;

                }
                mMsg.AppendText(PrintText);
                mMsg.AppendText("\n");
                mMsg.SelectionColor = Color.Black;
                mMsg.Focus();
            }
            catch (Exception ex) { }
        }

        internal void initializereader(ComboBox cbReader, Label Tssl)
        {
            lbl = Tssl;
            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";
            //Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");

                return;

            }

            // 2. List PC/SC card readers installed in the system

            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");

                return;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                Tssl.Text = ("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));

                return;
            }
            else
            {
                displayOut(0, 0, " ", mMsg);
            }

            rName = "";
            indx = 0;

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {

                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                //Add reader name to list
                cbReader.Items.Add(rName);
                rName = "";
                indx = indx + 1;

            }

            if (cbReader.Items.Count > 0)
            {
                cbReader.SelectedIndex = 0;

            }
            retCode = ModWinsCard.SCardConnect(hContext, cbReader.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_SHARED,
                                             ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "", mMsg);
            }
            else
            {
                displayOut(0, 0, "Successful connection to " + cbReader.Text, mMsg);

            }
            connActive = true;
            loadkeys();
        }

        internal void writecard(Label toolStripStatusLabel1, ComboBox cbReader, List<string> nfccard)
        {
            string tmpStr = string.Empty;
            int indx, tempInt;
            progress.Maximum = 29;
            for (int i = 4; i < 29; i++)
            {
                if (i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23 || i == 27 || i == 31)
                {
                    i++;
                }
                try
                {
                    tmpStr = nfccard[i];
                }
                catch (Exception ex) { }
                ClearBuffers();
                authenticate(i.ToString());
                SendBuff[0] = 0xFF;                                     // CLA
                SendBuff[1] = 0xD6;                                     // INS
                SendBuff[2] = 0x00;                                     // P1
                SendBuff[3] = (byte)int.Parse(i.ToString());            // P2 : Starting Block No.
                SendBuff[4] = (byte)int.Parse("16");            // P3 : Data length

                for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
                {

                    SendBuff[indx + 5] = (byte)tmpStr[indx];

                }
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x02;

                retCode = SendAPDU();

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    tmpStr = "";
                    for (indx = 0; indx <= RecvLen - 1; indx++)
                    {

                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                        if (progress.Value != 29)
                        {
                            progress.Value++;
                        }
                        pause.Pause(10);
                    }

                }
                if (tmpStr.Trim() == "90 00")
                {
                    displayOut(0, 0, "SUCCESS!", mMsg);
                }
                else
                {
                    displayOut(2, 0, "", mMsg);
                }
            }
        }
    }
}
