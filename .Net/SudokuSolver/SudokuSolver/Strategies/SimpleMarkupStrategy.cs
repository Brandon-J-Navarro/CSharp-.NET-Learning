using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class SimpleMarkupStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkupStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitesInRowAndCol = GetPossibiliesInRowAndCol(sudokuBoard, row, col);
                        var possibilitesInBlock = GetPossibiliesInBlock(sudokuBoard, row, col);
                        sudokuBoard[row, col] = GetPossibilityIntersection(possibilitesInRowAndCol, possibilitesInBlock);
                    }
                }
            }
            return sudokuBoard;
        }

        private object GetPossibiliesInRowAndCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilites = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col = 0; col < 9; col++) if (IsValidSingle(sudokuBoard[givenRow, col])) possibilites[sudokuBoard[givenRow, col] - 1] = 0;
            for (int row = 0; row < 9; row++) if (IsValidSingle(sudokuBoard[row, givenCol])) possibilites[sudokuBoard[row, givenCol] - 1] = 0;

            return Convert.ToInt32(string.Join(string.Empty, possibilites.Select(p => p).Where(p => p != 0)));
        }

        private object GetPossibiliesInBlock(int[,] sudokuBoard, int row, int col)
        {
            throw new NotImplementedException();
        }

        private int GetPossibilityIntersection(object possibilitesInRowAndCol, object possibilitesInBlock)
        {
            throw new NotImplementedException();
        }

        private bool IsValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length < 2;
        }
    }
}
