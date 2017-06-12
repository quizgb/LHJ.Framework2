using System;

namespace LHJ.Common.Common.Com.FTP
{
    public class FtpException : Exception
    {
        public FtpException() : base() { }
        public FtpException(string message) : base(message) { }
        public FtpException(string message, Exception innerException) : base(message, innerException) { }
    }
}