using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class ResponseModel
    {
        /// <summary>
        /// <para>if Code=200, Success </para>
        /// <para>if Code=0, failure or error</para>
        /// </summary>
        public int Code { get; set; }
        public string Result { get; set; }
    }
}
