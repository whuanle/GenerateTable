using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateTableConsole
{
    /// <summary>
    /// Receiving commands from the console, creating or manipulating tables on the console
    /// </summary>
    public class UseTable
    {
        private TableModel table = new TableModel();

        public UseTable()
        {
        }

        /// <summary>
        /// run input command
        /// </summary>
        /// <param name="strCommand">Command</param>
        /// <returns>resturn responsemodel</returns>
        public ResponseModel RunCommand(string strCommand)
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
                        {
                           return new ResponseModel
                            {
                                Code = 0,
                                Result = "Range :   width < 30 and height < 10"
                            };
                        }

                        this.table.RowCount = rowCount;
                        this.table.ColumnCount = columnCount;
                        this.CreateTable();

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
                        this.InsertNumber(insert);
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
                        this.SumNumbers(sum);
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
        public void CreateTable()
        {
            uint row = this.table.RowCount + 2;
            uint column = (this.table.ColumnCount + 2) * 3;
            this.table.TableData = new char[row, column];

            for (int i = 0; i < row; i++)
            {
                if (i == 0 || i == row - 1)
                {
                    for (int j = 0; j < column; j++)
                    {
                        this.table.TableData[i, j] = '-';
                    }
                }
                else
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (j == 0 || j == column - 1)
                        {
                            this.table.TableData[i, j] = '|';
                        }
                        else
                        {
                            this.table.TableData[i, j] = ' ';
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Print table
        /// </summary>
        public void ConsoleTable()
        {
            for (int i = 0; i < this.table.RowCount + 2; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < (this.table.ColumnCount + 2) * 3; j++)
                {
                    Console.Write(this.table.TableData[i, j]);
                }

                Console.Write("\n");
            }
        }

        /// <summary>
        /// Insert Number
        /// </summary>
        /// <param name="insertnumber">inserternumbermodel</param>
        public void InsertNumber(InsertNumberModel insertnumber)
        {
            uint one = 0, ten = 0, hundred = 0;
            if (insertnumber.Number >= 100)
            {
                one = insertnumber.Number % 10;
                ten = (insertnumber.Number / 10) % 10;
                hundred = insertnumber.Number / 100;
                if (insertnumber.x > this.table.ColumnCount || insertnumber.y > this.table.RowCount)
                {
                    throw new System.IndexOutOfRangeException();
                }

                this.table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(hundred.ToString());
                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = char.Parse(ten.ToString());

                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = char.Parse(one.ToString());
            }
            else if (insertnumber.Number < 100 && insertnumber.Number >= 10)
            {
                one = insertnumber.Number % 10;
                ten = insertnumber.Number / 10;
                if (insertnumber.x > this.table.ColumnCount || insertnumber.y > this.table.RowCount)
                {
                    throw new System.IndexOutOfRangeException();
                }

                this.table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(ten.ToString());
                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = char.Parse(one.ToString());
                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = ' ';
            }
            else
            {
                one = insertnumber.Number;
                if (insertnumber.x > this.table.ColumnCount || insertnumber.y > this.table.RowCount)
                {
                    throw new System.IndexOutOfRangeException();
                }

                this.table.TableData[insertnumber.y, insertnumber.x * 3] = char.Parse(one.ToString());
                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 1] = ' ';
                this.table.TableData[insertnumber.y, (insertnumber.x * 3) + 2] = ' ';
            }
        }

        /// <summary>
        /// Find the sum of (x1, y1) and (x2, y2) and insert it into (x3, y3)
        /// </summary>
        /// <param name="sumNumber">SumNumberModel</param>
        public void SumNumbers(SumNumberModel sumNumber)
        {
            uint sum = this.GetNumber(sumNumber.x1, sumNumber.y1) + this.GetNumber(sumNumber.x2, sumNumber.y2);
            InsertNumberModel insert = new InsertNumberModel();
            insert.y = sumNumber.y3;
            insert.x = sumNumber.x3;
            insert.Number = sum;
            this.InsertNumber(insert);
        }

        /// <summary>
        /// Get a Number,form (x,y)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>uint</returns>
        public uint GetNumber(uint x, uint y)
        {
            if (y > this.table.RowCount || x > this.table.ColumnCount)
            {
                throw new System.IndexOutOfRangeException();
            }

            char a = this.table.TableData[y, x * 3], b = this.table.TableData[y, (x * 3) + 1], c = this.table.TableData[y, (x * 3) + 2];
            uint number = 0;
            if (a != ' ')
            {
                number = uint.Parse(a.ToString());
            }

            if (b != ' ')
            {
                number = (number * 10) + uint.Parse(b.ToString());
            }

            if (c != ' ')
            {
                number = (number * 10) + uint.Parse(c.ToString());
            }

            Console.WriteLine(number);
            return number;
        }
    }
}
