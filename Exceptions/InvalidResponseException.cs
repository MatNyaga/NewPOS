using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acs.Readers.Pcsc;

namespace Acs
{
    public class InvalidResponseException : Exception
    {
        private byte[] _response;
        public byte[] response
        {
            get { return _response; }            
        }

        public InvalidResponseException(byte[] response)
        {
            this._response = response;
        }
    }
}
