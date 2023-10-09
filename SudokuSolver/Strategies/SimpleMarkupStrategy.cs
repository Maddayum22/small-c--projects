using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class SimpleMarkupStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _mapper;

        public SimpleMarkupStrategy (SudokuMapper mapper)
        {
            _mapper = mapper;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitesInRowAndCol = GetPossibilitesInRowAndCol(sudokuBoard, row, col);
                        var possibilitesInBlock = GetPossibilitesInBlock(sudokuBoard, row, col);
                        sudokuBoard[row, col] = GetPossibiltyIntersection(possibilitesInRowAndCol, possibilitesInBlock);
                    }
                }
            }

            return sudokuBoard;
        }

        private int GetPossibilitesInRowAndCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilites = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            for (int col = 0; col < 9; col++) if (isValidSingle(sudokuBoard[givenRow, col])) possibilites[sudokuBoard[givenRow, col] - 1] = 0;
            for (int row = 0; row < 9; row++) if (isValidSingle(sudokuBoard[row, givenCol])) possibilites[sudokuBoard[row, givenCol] - 1] = 0;

            return Convert.ToInt32(String.Join(string.Empty, possibilites.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilitesInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilites = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _mapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col <= sudokuMap.StartCol + 2; col++)
                {
                    if (isValidSingle(sudokuBoard[row, col])) possibilites[sudokuBoard[row, col] -1 ] = 0;

                }
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilites.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibiltyIntersection(int possibilitesInRowAndCol, int possibilitesInBlock)
        {
            var possibilitiesInRowAndColCharArray = possibilitesInRowAndCol.ToString().ToCharArray();
            var possibilitiesInBlockCharArray = possibilitesInBlock.ToString().ToCharArray();
            var possibilitiesSubset = possibilitiesInRowAndColCharArray.Intersect(possibilitiesInBlockCharArray);

            return Convert.ToInt32(String.Join(string.Empty, possibilitiesSubset));
        }


        private bool isValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length == 1;
        }
    }
}
