using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acs;
using Acs.Readers.Pcsc;
using ACR1222L_Device_Programming;

namespace NewPOS
{
    public enum LedStateSwitch
    {
        On = 0x01,
        Off = 0x00
    }   

    public enum FontSet
    {
        SetA = 0x00,
        SetB = 0x10,
        SetC = 0x20
    }

    public enum ScrollingPeriod
    {
        _1 = 0x00,
        _3 = 0x10,
        _5 = 0x20,
        _7 = 0x30,
        _17 = 0x40,
        _19 = 0x50,
        _21 = 0x60,
        _23 = 0x70,
        _129 = 0x80,
        _131 = 0x90,
        _133 = 0xA0,
        _135 = 0xB0,
        _145 = 0xC0,
        _147 = 0xD0,
        _149 = 0xE0,
        _151 = 0xF0
    }

    public enum ScrollingDirection
    {
        LeftToRight = 0x00,
        RightToLeft = 0x01,
        BottomToTop = 0x02,
        TopToBottom = 0x03
    }

    public class LedStatus
    {

        private LedStateSwitch _blue = LedStateSwitch.Off;
        private LedStateSwitch _green = LedStateSwitch.Off;

        public LedStatus()
        {

        }

        public LedStatus(byte ledStatus)
        {
            if ((ledStatus & 0x01) == 0x01)
                _blue = LedStateSwitch.On;

            if ((ledStatus & 0x02) == 0x02)
                _green = LedStateSwitch.On;
        }

        public LedStateSwitch blue
        {
            get { return _blue; }
            set { _blue = value; }
        }

        public LedStateSwitch green
        {
            get { return _green; }
            set { _green = value; }
        }

        public byte getRawLedStatus()
        {
            byte ledStatus = 0x00;

            if (blue == LedStateSwitch.On)
                ledStatus |= 0x02;

            if (green == LedStateSwitch.On)
                ledStatus |= 0x01;

            return ledStatus;
        }
    }

    public class LcdDisplayParameter
    {
        public bool boldFont = false;

        private FontSet _fontset;

        public FontSet fontSet
        {
            get { return _fontset; }
            set { _fontset = value; }
        }

        public string message = "Hello ACS!";

        public byte positionLineNumber = 1;

        public byte positionOffset = 0;

        private byte _positionAbsolute = 0;

        public byte positionAbsolute
        {
            get
            {
                if (fontSet == FontSet.SetA | fontSet == FontSet.SetB)
                {
                    if (positionLineNumber == 1)
                        _positionAbsolute = positionOffset;
                    else
                        _positionAbsolute = (byte)(0x40 + positionOffset);
                }
                else
                {
                    _positionAbsolute = (byte)(((positionLineNumber - 1) * 32) + positionOffset);
                }

                return _positionAbsolute;
            }
        }
    }

    public class DisplayLcdGBModeParameter
    {
        public bool boldFont = false;

        public string message = "Hello ACS!";

        public byte positionLineNumber = 1;
        public byte positionOffset = 0;

        private byte _positionAbsolute = 0;

        public byte positionAbsolute
        {
            get
            {
                if (positionLineNumber == 1)
                    _positionAbsolute = positionOffset;
                else
                    _positionAbsolute = (byte)(0x40 + positionOffset);

                return _positionAbsolute;
            }
        }
    }

    public class ScrollDisplayParameters
    {
        public byte posX = 0;
        public byte posY = 0;
        public byte horizontalScrollingRange = 16;
        public byte verticalScrollingRange = 0x20;
        public byte pixelMovePerScrolling = 4;
        public ScrollingPeriod refreshSpeed = ScrollingPeriod._129;
        public ScrollingDirection scrollingDirection = ScrollingDirection.LeftToRight;
    }

    public class PiccOperatingParameter
    {
        public PiccOperatingParameter()
        {

        }

        public PiccOperatingParameter(byte rawOperatingParameter)
        {
            if ((rawOperatingParameter & 0x01) == 0x01)
                iso14443TypeA = PARAMETER_OPTION.DETECT;

            if ((rawOperatingParameter & 0x02) == 0x02)
                iso14443TypeB = PARAMETER_OPTION.DETECT;
        }

        public enum PARAMETER_OPTION
        {
            SKIP = 0x00,
            DETECT = 0x01
        }

        private PARAMETER_OPTION _Iso14443TypeA = PARAMETER_OPTION.SKIP;
        private PARAMETER_OPTION _Iso14443TypeB = PARAMETER_OPTION.SKIP;

        public PARAMETER_OPTION iso14443TypeA
        {
            get { return _Iso14443TypeA; }
            set { _Iso14443TypeA = value; }
        }

        public PARAMETER_OPTION iso14443TypeB
        {
            get { return _Iso14443TypeB; }
            set { _Iso14443TypeB = value; }
        }

        public byte getRawOperatingParameter()
        {
            byte operatingParameter = 0x00;

            if (iso14443TypeA == PARAMETER_OPTION.DETECT)
                operatingParameter |= 0x01;

            if (iso14443TypeB == PARAMETER_OPTION.DETECT)
                operatingParameter |= 0x02;

            return operatingParameter;
        }
    }

    public class Acr1222L : PcscReader
    {
        public Acr1222L()
        {
            operationControlCode = (uint)PcscProvider.FILE_DEVICE_SMARTCARD + 3500 * 4;
        }

        public Acr1222L(string rdrName)
        {
            readerName = rdrName;
            operationControlCode = (uint)PcscProvider.FILE_DEVICE_SMARTCARD + 3500 * 4;
        }

        #region LCD

        public void clearLcd()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x60;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;
            
            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void displayLcd(LcdDisplayParameter param)
        {
            byte[] msg = ASCIIEncoding.ASCII.GetBytes(param.message);
            if (msg.Length > 16)
                Array.Resize(ref msg, 16);

            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5 + msg.Length];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x68;
            apdu.data[3] = param.positionAbsolute;
            apdu.data[4] = (byte)msg.Length;

            Array.Copy(msg, 0, apdu.data, 5, msg.Length);

            if (param.boldFont)
                apdu.data[1] |= 0x01;

            apdu.data[1] |= (byte)param.fontSet;            

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void displayLcdGBMode(DisplayLcdGBModeParameter param)
        {
            byte[] msg = Encoding.GetEncoding("GB18030").GetBytes(param.message);

            if (msg.Length > 16)
                Array.Resize(ref msg, 16);

            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5 + msg.Length];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x69;
            apdu.data[3] = param.positionAbsolute;
            apdu.data[4] = (byte)msg.Length;

            Array.Copy(msg, 0, apdu.data, 5, msg.Length);

            if (param.boldFont)
                apdu.data[1] |= 0x01;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void displayLcdGraphic(byte lineIndex, byte[] data)
        {
            if (lineIndex > 0x1F)
                throw new Exception("Line Index is invalid");

            if (data.Length == 0 || data.Length > 128)
                throw new Exception("Data has invalid length");

            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5 + data.Length];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x6A;
            apdu.data[3] = lineIndex;
            apdu.data[4] = (byte)data.Length;

            Array.Copy(data, 0, apdu.data, 5, data.Length);

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void contrast(byte contrast)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x6C;
            apdu.data[3] = contrast;
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void backlight(bool setToON)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x64;
            apdu.data[3] = (byte)((setToON) ? 0xFF : 0x00);
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        #endregion

        #region SCROLL

        public void scrollDisplay(ScrollDisplayParameters param)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[11];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x6D;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x06;

            apdu.data[5] = param.posX;
            apdu.data[6] = param.posY;
            apdu.data[7] = param.horizontalScrollingRange;
            apdu.data[8] = param.verticalScrollingRange;

            apdu.data[9] = (byte)param.refreshSpeed;
            apdu.data[9] |= param.pixelMovePerScrolling;

            apdu.data[10] = (byte)param.scrollingDirection;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void scrollPause()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x6E;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public void scrollStop()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x6F;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        #endregion     
        
        #region LED and BUZZER
        
        public void ledControl(LedStateSwitch led0, LedStateSwitch led1, LedStateSwitch led2, LedStateSwitch led3)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x44;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;

            if (led0 == LedStateSwitch.On)
                apdu.data[3] |= 0x01;

            if (led1 == LedStateSwitch.On)
                apdu.data[3] |= 0x02;

            if (led2 == LedStateSwitch.On)
                apdu.data[3] |= 0x04;

            if (led3 == LedStateSwitch.On)
                apdu.data[3] |= 0x08;

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public LedStatus redGreenLedControl(LedStatus ledStatus)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 6;
            apdu.data = new byte[6];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x29;
            apdu.data[4] = 0x01;
            apdu.data[5] = ledStatus.getRawLedStatus();

            apduCommand = apdu;
            sendCardControl();

            return new LedStatus(apduCommand.response[5]);
        }

        public void buzzerControl(byte onDuration)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 6;
            apdu.data = new byte[6];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x28;
            apdu.data[4] = 0x01;
            apdu.data[5] = onDuration;
          
            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        #endregion

        #region READER MEMORY

        public void storeDataToReaderEeprom(byte memorySlot, byte[] data)
        {
            if (memorySlot > 1)
                throw new Exception("Memory slot is invalid");

            if (data == null || data.Length > 256)
                throw new Exception("Data has invalid length");

            byte[] tmpArray = Helper.intToByte(data.Length);

            Apdu apdu = new Apdu();
            apdu.lengthExpected = 2;
            apdu.data = new byte[7 + data.Length];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = (byte)((memorySlot == 1) ? 0x4A : 0x4B);
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;
            apdu.data[5] = tmpArray[2];
            apdu.data[6] = tmpArray[3];

            Array.Copy(data, 0, apdu.data, 7, data.Length);

            apduCommand = apdu;
            sendCardControl();

            //if (apduCommand.statusWord[0] != 0x90)
            //    throw new ContactlessException("Operation failed", Contactless_ErrorCodes.OPERATION_FAILED);
        }

        public byte[] readDataFromReaderEeprom(byte memorySlot)
        {
            if (memorySlot > 1)
                throw new Exception("Memory slot is invalid");

            Apdu apdu = new Apdu();
            apdu.lengthExpected = 256;
            apdu.data = new byte[7];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0x00;
            apdu.data[2] = (byte)((memorySlot == 1) ? 0x4C : 0x4D);
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00;
            apdu.data[5] = 0x01;
            apdu.data[6] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            return apduCommand.response;
        }

        #endregion

        #region DEVICE INFORMATION

        public override byte[] getFirmwareVersion()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 256;
            apdu.data = new byte[5];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x18;
            apdu.data[4] = 0x00;

            apduCommand = apdu;            
            sendCardControl();

            return apduCommand.response;
        }

        public String getTagUID()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 256;
            apdu.data = new byte[5];

            apdu.data[0] = 0xFF;
            apdu.data[1] = 0xCA;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x00;
            apdu.data[4] = 0x00; 
                                         
            apduCommand = apdu;
            sendCardControl();

            byte[] response = apduCommand.response;

            return ByteArrayToString(response);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public byte[] getReaderSerialNumber()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 21;
            apdu.data = new byte[5];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x33;
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            return apduCommand.response;
        }

        #endregion

        #region PICC OPERATING PARAMETER

        public PiccOperatingParameter readPiccOperatingParameter()
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 6;
            apdu.data = new byte[5];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x20;
            apdu.data[4] = 0x00;

            apduCommand = apdu;
            sendCardControl();

            return new PiccOperatingParameter (apduCommand.response[5]);
        }

        public PiccOperatingParameter setPiccOperatingParameter(PiccOperatingParameter operatingParameter)
        {
            Apdu apdu = new Apdu();
            apdu.lengthExpected = 6;
            apdu.data = new byte[6];

            apdu.data[0] = 0xE0;
            apdu.data[1] = 0x00;
            apdu.data[2] = 0x00;
            apdu.data[3] = 0x20;
            apdu.data[4] = 0x01;
            apdu.data[5] = operatingParameter.getRawOperatingParameter();

            apduCommand = apdu;
            sendCardControl();

            return new PiccOperatingParameter(apduCommand.response[5]);
           
        }

        #endregion
        
    }
}

