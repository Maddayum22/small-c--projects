using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolver.Workers
{
    public class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudokuBoardLines = File.ReadAllLines(filename);

                int row = 0;
                foreach (var sudokuLine in sudokuBoardLines)
                {
                    string[] sudokuLineElements = sudokuLine.Split("|").Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach (var sudokuLineElement in sudokuLineElements)
                    {
                        sudokuBoard[row, col] = sudokuLineElement.Equals(" ") ? 0 : Convert.ToInt16(sudokuLineElement);
                        col++;
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong while reading the file: {ex.Message}");
            }
            return sudokuBoard;
        }
    }
}
