using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acs.Readers.Pcsc;

namespace Acs
{
    public enum COMMAND_RESPONSE_CODE
    {
        CMD_OKAY,
        INVALID_PARAMETERS,
        INVALID_COMMAND_CODE,
        INVALID_COMMAND_LENGTH,
        CANNOT_EXECUTE_COMMAND,
        TIMEOUT,
        SCRIPT_ERROR,
        UNKNOWN
    }

    public class InvalidCommandResponseException : Exception
    {
        private COMMAND_RESPONSE_CODE _responseCode;
        public COMMAND_RESPONSE_CODE responseCode
        {
            get { return _responseCode; }
        }

        private byte[] _response;
        public byte[] response
        {
            get { return _response; }            
        }

        public override string Message
        {
            get
            {
                return responseCode.ToString();
            }
        }

        public InvalidCommandResponseException(byte[] response)
        {
            this._response = response;
            _responseCode = getResponseCode(response);
        }

        private COMMAND_RESPONSE_CODE getResponseCode(byte[] response)
        {
            if (response[0] == 0x00 && response[1] == 0x00)
                return COMMAND_RESPONSE_CODE.CMD_OKAY;

            if (response[0] == 0x00 && response[1] == 0x01)
                return COMMAND_RESPONSE_CODE.INVALID_PARAMETERS;

            return COMMAND_RESPONSE_CODE.UNKNOWN;

        }
    }
}
