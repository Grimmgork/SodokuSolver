using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
	public class SodokuBoard
	{
		byte[,] values;

		public SodokuBoard(byte[,] values){
			if (values.GetLength(0) != 9 || values.GetLength(1) != 9)
				throw new ArgumentException("Invalid sodoku-board!");

			this.values = values;
		}

		public byte this[int x, int y]
		{
			get{
				return values[x, y];
			}
			set{
				values[x, y] = value;
			}
		}

		public byte[][] GetQuadrant(int x, int y){
			byte[][] result = new byte[3][];

			int xr = 0, yr = 0;
			for (int xx = x * 3; xx < x * 3 + 3; xx++){
				yr = 0;
				result[xr] = new byte[3]; 
				for (int yy = y*3; yy < y*3+3; yy++)
				{
					result[xr][yr] = values[xx, yy];
					yr++;
				}
				xr++;
			}
			return result;
		}

		public byte[] GetRow(int y){
			byte[] result = new byte[9];
			for (int x = 0; x < 9; x++){
				result[x] = values[x,y];
			}
			return result;
		}

		public byte[] GetColumn(int x)
		{
			byte[] result = new byte[9];
			for(int y = 0; y < 9; y++){
				result[y] = values[x, y];	
			}
			return result;
		}

		public override string ToString()
		{
			string result = "";
			for (int y = 0; y < values.GetLength(0); y++)
			{
				for (int x = 0; x < values.GetLength(1); x++)
				{
					byte value = values[x, y];
					if (value == 0)
						result += ".";
					else
						result += values[x, y].ToString();
				}
				result += "\n";
			}
			return result;
		}
	}
}
