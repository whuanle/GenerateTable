using System;

namespace ConsoleApp4
{
    /// <summary>
    /// Receiving commands from the console, creating or manipulating tables on the console
    /// </summary>
    public class UseTable
    {
        public ResponseModel RunCommand(TableModel table, string strCommand)
        {
            string[] sArray = strCommand.Split(" ");
            if (sArray[0] == "C")
            {
                if (sArray.Length == 3)
                {
                    try
                    {
                        uint rowCount = uint.Parse(sArray[2]);
                        uint columnCount = uint.Parse(sArray[1]);
                        if (rowCount > 10 || columnCount > 30)
                            return new ResponseModel
                            {
                                Code = 0,
                                Result = "Range :   width < 30 and height < 10"
                            };
                        table.RowCount = rowCount;
                        table.ColumnCount = columnCount;
                        CreateTable(table);

                        return new ResponseModel
                        {
                            Code = 200,
                            Result = "success create table"
                        };
                    }
                    catch
                    {
                        return new ResponseModel
                        {
                            Code = 0,
                            Result = "example\nN [width] [height]\nS [x1] [y1] [value]\nS x1 y1 x2 y2 x3 y3\nQ"
                        };
                    }
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = 0,
                        Result = "invalid input，Error: " + strCommand
                    };
                }
            }
            else if (sArray[0] == "N")
            {
                if (sArray.Length == 4)
                {
                    try
                    {
                        InsertNumberModel insert = new InsertNumberModel();
                        insert.y = uint.Parse(sArray[2]);
                        insert.x = uint.Parse(sArray[1]);
                        insert.Number = uint.Parse(sArray[3]);
                        InsertNumber(table, insert);
                        return new ResponseModel
                        {
                            Code = 200,
                            Result = "success"
                        };
                    }
                    catch
                    {
                        return new ResponseModel
                        {
                            Code = 0,
                            Result = "example\nN [width] [height]\nS [x1] [y1] [value]\nS x1 y1 x2 y2 x3 y3\nQ"
                        };
                    }
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = 0,
                        Result = "invalid input，Error: " + strCommand
                    };
                }
            }
            else if (sArray[0] == "S")
            {
                if (sArray.Length == 7)
                {
                    try
                    {
                        SumNumberModel sum = new SumNumberModel();
                        sum.x1 = uint.Parse(sArray[1]);
                        sum.y1 = uint.Parse(sArray[2]);
                        sum.x2 = uint.Parse(sArray[3]);
                        sum.y2 = uint.Parse(sArray[4]);
                        sum.x3 = uint.Parse(sArray[5]);
                        sum.y3 = uint.Parse(sArray[6]);
                        SumNumbers(table, sum);
                        return new ResponseModel
                        {
                            Code = 200,
                            Result = "success"
                        };
                    }
                    catch
                    {
                        return new ResponseModel
                        {
                            Code = 0,
                            Result = "example\nN [width] [height]\nS [x1] [y1] [value]\nS x1 y1 x2 y2 x3 y3\nQ"
                        };
                    }
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = 0,
                        Result = "invalid input，Error: " + strCommand
                    };
                }

            }
            else
            {
                return new ResponseModel
                {
                    Code = 0,
                    Result = "invalid input，Error: "
                };
            }
        }

        /// <summary>
        /// Use commands to create tables
        /// </summary>
        /// <param name="table"></param>
        public void CreateTable(TableModel table)
        {
            uint row = table.RowCount + 2;
            uint column = (table.ColumnCount + 2) * 3;
            table.TableData = new char[row, column];

            for (int i = 0; i < row; i++)
            {
                if (i == 0 || i == row - 1)
                {
                    for (int j = 0; j < column; j++)
                    {
                        table.TableData[i, j] = '-';
                    }
                }
                else
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (j == 0 || j == column - 1)
                            table.TableData[i, j] = '|';
                        else table.TableData[i, j] = ' ';
                    }
                }
            }
        }
        /// <summary>
        /// Print table
        /// </summary>
        /// <param name="table"></param>
        public void ConsoleTable(TableModel table)
        {
            for (int i = 0; i < table.RowCount + 2; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < (table.ColumnCount + 2) * 3; j++)
                {
                    Console.Write(table.TableData[i, j]);
                }
                Console.Write("\n");

            }
        }
        /// <summary>
        /// Insert Number
        /// </summary>
        /// <param name="table"></param>
        /// <param name="number"></param>
        public void InsertNumber(TableModel table, InsertNumberModel insertnumber)
        {
            uint one = 0, ten = 0, hundred = 0;
            if (insertnumber.Number >= 100)
            {
                one = insertnumber.Number % 10;
                ten = insertnumber.Number / 10 % 10;
                hundred = insertnumber.Number / 100;
                if (insertnumber.x > table.ColumnCount || insertnumber.y > table.RowCount)
                    throw new System.IndexOutOfRangeException();
                table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(hundred.ToString());
                table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = char.Parse(ten.ToString());

                table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = char.Parse(one.ToString());
            }
            else if (100 > insertnumber.Number && insertnumber.Number >= 10)
            {
                one = insertnumber.Number % 10;
                ten = insertnumber.Number / 10;
                if (insertnumber.x > table.ColumnCount || insertnumber.y > table.RowCount)
                    throw new System.IndexOutOfRangeException();
                table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(ten.ToString());
                table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = char.Parse(one.ToString());
                table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = ' ';
            }
            else
            {
                one = insertnumber.Number;
                if (insertnumber.x > table.ColumnCount || insertnumber.y > table.RowCount)
                    throw new System.IndexOutOfRangeException();

                table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(one.ToString());
                table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = ' ';
                table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = ' ';
            }
        }

        /// <summary>
        /// Find the sum of (x1, y1) and (x2, y2) and insert it into (x3, y3)
        /// </summary>
        public void SumNumbers(TableModel table, SumNumberModel sumNumber)
        {
            uint sum = GetNumber(table, sumNumber.x1, sumNumber.y1) + GetNumber(table, sumNumber.x2, sumNumber.y2);
            InsertNumberModel insert = new InsertNumberModel();
            insert.y = sumNumber.y3;
            insert.x = sumNumber.x3;
            insert.Number = sum;
            InsertNumber(table, insert);
        }
        /// <summary>
        /// Get a Number,form (x,y)
        /// </summary>
        /// <param name="table"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public uint GetNumber(TableModel table, uint x, uint y)
        {
            if (y > table.RowCount || x > table.ColumnCount)
                throw new System.IndexOutOfRangeException();
            char a = table.TableData[y, x * 3], b = table.TableData[y, x * 3 + 1], c = table.TableData[y, x * 3 + 2];
            uint number = 0;
            if (a != ' ')
                number = uint.Parse(a.ToString());
            if (b != ' ')
                number = number * 10 + uint.Parse(b.ToString());
            if (c != ' ')
                number = number * 10 + uint.Parse(c.ToString());
            Console.WriteLine(number);
            return number;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please create table,Ex: C [width] [height]");
            Console.WriteLine("This a true Command : C 20 4");
            Console.WriteLine("enter command:");
            TableModel table = new TableModel();
            UseTable useTable = new UseTable();
            //start create table
            while (true)
            {
                string s = Console.ReadLine();
                var re = useTable.RunCommand(table, s);
                if (re.Code == 200)
                {
                    Console.WriteLine(re.Result);
                    break;
                }
                else
                {
                    Console.WriteLine(re.Result);
                }

            }

            while (true)
            {
                useTable.ConsoleTable(table);
                string s = Console.ReadLine();
                if (s == "Q")
                    break;

                var re = useTable.RunCommand(table, s);
                if (re.Code == 200)
                {
                    Console.WriteLine(re.Result);
                }
                else
                {
                    Console.WriteLine(re.Result);
                }
            }
        }
    }
}
