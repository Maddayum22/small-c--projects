using SudokuSolver.Strategies;
using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper mapper = new SudokuMapper();
                SudokuBoardStateManager boardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(boardStateManager, mapper);
                SudokuFileReader reader = new SudokuFileReader();
                SudokuDisplayer displayer = new SudokuDisplayer();

                Console.WriteLine("Please enter the filename containing the Sudoku Puzzle: ");
                var fileName = Console.ReadLine();

                var sudokuBoard = reader.ReadFile(fileName);
                displayer.Display("Initial State", sudokuBoard);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                displayer.Display("Final State", sudokuBoard);

                Console.WriteLine(isSudokuSolved ? "You have succesfully solved this Sudoku puzzle." : 
                    "Unfortunatly, current algorithm(s) were not enough to solve this Sudoku puzzle.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex.Message);
            }
        }
    }
}