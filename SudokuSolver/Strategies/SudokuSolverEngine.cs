using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _stateManager;
        private readonly SudokuMapper _mapper;

        public SudokuSolverEngine(SudokuBoardStateManager stateManager, SudokuMapper mapper)
        {
            _stateManager = stateManager;
            _mapper = mapper;
        }

        public bool Solve(int[,] sudokuBoard)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>()
            {
                
            };

            var currentState = _stateManager.GenerateState(sudokuBoard);
            var nextState = _stateManager.GenerateState(strategies.First().Solve(sudokuBoard));

            while (!_stateManager.IsSolved(sudokuBoard) && currentState != nextState) 
            {
                currentState = nextState;
                foreach (var strategy in strategies) nextState = _stateManager.GenerateState(strategy.Solve(sudokuBoard));
            }

            return _stateManager.IsSolved(sudokuBoard);
        }
    }
}
