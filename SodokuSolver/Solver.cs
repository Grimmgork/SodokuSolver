using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
	public class Solver
	{
		public static SodokuBoard Solve(SodokuBoard board)
		{
			while(true){
				
				List<byte>[,] possibilities = GetPossibilities(board);
				Tuple<int,int> lowestEntropyPosition = FindShortestPositionNotNull(possibilities);
				if (lowestEntropyPosition == null)
					break;
				int x = lowestEntropyPosition.Item1;
				int y = lowestEntropyPosition.Item2;

				board[x, y] = possibilities[x, y][0];
			}

			return board;
		}

		private static List<byte>[,] GetPossibilities(SodokuBoard board){
			List<byte>[,] result = new List<byte>[9, 9];
			for (int y = 0; y < 9; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					if (board[x, y] != 0)
						continue;

					result[x, y] = new List<byte>();
					for(byte i = 1; i <= 9; i++){
						
						if (board.GetRow(y).Contains(i) || board.GetColumn(x).Contains(i) || board.GetQuadrant(x/3,y/3).Any(column => column.Contains(i)))
							continue;
						result[x, y].Add(i);
					}
				}
			}
			return result;
		}

		private static Tuple<int, int> FindShortestPositionNotNull(List<byte>[,] grid)
		{
			int length = int.MaxValue;
			Tuple<int, int> result = null;
			for (int y = 0; y < 9; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					List<byte> list = grid[x, y];
					if (list == null || list.Count == 0)
						continue;

					if (list.Count <= length)
					{
						length = list.Count;
						result = new Tuple<int, int>(x, y);
					}
				}
			}

			return result;
		}
	}
}