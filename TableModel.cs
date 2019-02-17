using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateTableConsole
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
