using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acs
{
    public class InvalidResponseTypeException: Exception
    {
        private byte _expectedResponseType;
        public byte expectedResponseType
        {
            get { return _expectedResponseType; }
        }

        private byte _actualResponseType;
        public byte actualResponseType
        {
            get { return _actualResponseType; }
        }

        public InvalidResponseTypeException(byte expectedResponseType, byte actualResponseType)
        {
            this._expectedResponseType = expectedResponseType;
            this._actualResponseType = actualResponseType;
        }
    }
}
