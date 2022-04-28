// See https://aka.ms/new-console-template for more information
using SodokuSolver;

Console.WriteLine("Hello, World!");

List<byte[,]> boards = LoadBoardsFromDirectory(@"c:\users\eric\desktop\samples");
Console.WriteLine($"Loadet {boards.Count} boards ...");
Console.WriteLine();

int i = 1;
foreach(byte[,] board in boards){
	Console.WriteLine($"- Board {i}:");
	Console.WriteLine("--------------");
	SolveBoard(new SodokuBoard(board));
	i++;
}

static void SolveBoard(SodokuBoard board){
	Console.WriteLine(board.ToString());
	Solver.Solve(board);
	Console.WriteLine(board.ToString());
	Console.WriteLine();
}

static List<byte[,]> LoadBoardsFromDirectory(string path, string pattern = "*.dat"){
	string[] files = Directory.GetFiles(path, pattern);
	List<byte[,]> boards = new List<byte[,]>();

	foreach (string file in files)
	{
		byte[,] board = new byte[9,9];
		string[] rows = File.ReadAllLines(file);

		rows = rows.Skip(2).ToArray();
		for (int y = 0; y < board.GetLength(1); y++) {
			string[] row = rows[y].Split(" ");
			for (int x = 0; x < board.GetLength(0); x++) {
				board[x, y] = byte.Parse(row[x]);
			} 
		}
		boards.Add(board);
	}

	return boards;
}