using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    /// <summary>
    /// table
    /// </summary>
    public class TableModel
    {
        public uint RowCount { get; set; }
        public uint ColumnCount { get; set; }
        public char[,] TableData { get; set; }
    }
}
