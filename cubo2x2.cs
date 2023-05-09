public class Face2x2
{
    public byte[] values { get; set; }

    public Face2x2(byte[] cores)
    {
        this.values = cores;
    }

    public void cW()
    {
        byte[] newFace = new byte[4] { values[2], values[0], values[3], values[1] };
        newFace.CopyTo(values, 0);
    }

    public void AcW()
    {
        byte[] newFace = new byte[4] { values[1], values[3], values[0], values[2] };
        newFace.CopyTo(values, 0);
		//teste
    }
}

public class Cubo2x2
{
    public Face2x2[] cubo { get; set; } = new Face2x2[6];
    public int[][] relations { get; set; } = new int[6][];
    public int[] side0 { get; set; } = new int[] { 0, 1 };
    public int[] side1 { get; set; } = new int[] { 1, 3 };
    public int[] side2 { get; set; } = new int[] { 2, 3 };
    public int[] side3 { get; set; } = new int[] { 0, 2 };


    public Cubo2x2()
    {
        this.cubo[0] = new Face2x2(new byte[]{71,71,71,71});
        this.cubo[1] = new Face2x2(new byte[]{82,82,82,82});
        this.cubo[2] = new Face2x2(new byte[]{66,66,66,66});
        this.cubo[3] = new Face2x2(new byte[]{79,79,79,79});
        this.cubo[4] = new Face2x2(new byte[]{87,87,87,87});
        this.cubo[5] = new Face2x2(new byte[]{89,89,89,89});
        relations[0] = new int[4] { 4, 1, 5, 3 };
        relations[1] = new int[4] { 4, 2, 5, 0 };
        relations[2] = new int[4] { 4, 3, 5, 1 };
        relations[3] = new int[4] { 4, 0, 5, 2 };
        relations[4] = new int[4] { 2, 1, 0, 3 };
        relations[5] = new int[4] { 0, 1, 2, 3 };
    }

    public void addFace(Face2x2 face, int pos)
    {
        cubo[pos] = face;
    }

    public void rotate(int face, bool dir)
    {
        int[] tempFace = new int[2];
        int rotAmount = dir == true ? 1 : 3;
        for (int j = 0; j < rotAmount; j++)
        {
            cubo[face].cW();
            switch (face)
            {
                case 0:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side2[i]];
                        cubo[relations[face][0]].values[side2[i]] = cubo[relations[face][3]].values[side1[Math.Abs(i - 1)]];
                        cubo[relations[face][3]].values[side1[Math.Abs(i - 1)]] = cubo[relations[face][2]].values[side0[Math.Abs(i - 1)]];
                        cubo[relations[face][2]].values[side0[Math.Abs(i - 1)]] = cubo[relations[face][1]].values[side3[i]];
                        cubo[relations[face][1]].values[side3[i]] = (byte)tempFace[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side1[i]];
                        cubo[relations[face][0]].values[side1[i]] = cubo[relations[face][3]].values[side1[i]];
                        cubo[relations[face][3]].values[side1[i]] = cubo[relations[face][2]].values[side1[i]];
                        cubo[relations[face][2]].values[side1[i]] = cubo[relations[face][1]].values[side3[Math.Abs(i - 1)]];
                        cubo[relations[face][1]].values[side3[Math.Abs(i - 1)]] = (byte)tempFace[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side0[i]];
                        cubo[relations[face][0]].values[side0[i]] = cubo[relations[face][3]].values[side1[i]];
                        cubo[relations[face][3]].values[side1[i]] = cubo[relations[face][2]].values[side2[Math.Abs(i - 1)]];
                        cubo[relations[face][2]].values[side2[Math.Abs(i - 1)]] = cubo[relations[face][1]].values[side3[Math.Abs(i - 1)]];
                        cubo[relations[face][1]].values[side3[Math.Abs(i - 1)]] = (byte)tempFace[i];
                    }
                    break;
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side3[i]];
                        cubo[relations[face][0]].values[side3[i]] = cubo[relations[face][3]].values[side1[Math.Abs(i - 1)]];
                        cubo[relations[face][3]].values[side1[Math.Abs(i - 1)]] = cubo[relations[face][2]].values[side3[i]];
                        cubo[relations[face][2]].values[side3[i]] = cubo[relations[face][1]].values[side3[i]];
                        cubo[relations[face][1]].values[side3[i]] = (byte)tempFace[i];
                    }
                    break;
                case 4:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side0[i]];
                        cubo[relations[face][0]].values[side0[i]] = cubo[relations[face][3]].values[side0[i]];
                        cubo[relations[face][3]].values[side0[i]] = cubo[relations[face][2]].values[side0[i]];
                        cubo[relations[face][2]].values[side0[i]] = cubo[relations[face][1]].values[side0[i]];
                        cubo[relations[face][1]].values[side0[i]] = (byte)tempFace[i];
                    }
                    break;
                case 5:
                    for (int i = 0; i < 2; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side2[i]];
                        cubo[relations[face][0]].values[side2[i]] = cubo[relations[face][3]].values[side2[i]];
                        cubo[relations[face][3]].values[side2[i]] = cubo[relations[face][2]].values[side2[i]];
                        cubo[relations[face][2]].values[side2[i]] = cubo[relations[face][1]].values[side2[i]];
                        cubo[relations[face][1]].values[side2[i]] = (byte)tempFace[i];
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void detailedTranslate(string alg, int face)
    {
        string[] moves = alg.Split(' ');
        foreach (var move in moves)
        {
            bool dir = move.Contains("'") ? false : true;
            int doubleMove = move.Contains("2") ? 2 : 1;
            string newMove = move.Replace("'", string.Empty).Replace("2", string.Empty);
            for (int i = 0; i < doubleMove; i++)
            {
                switch (newMove)
                {
                    case "F":
                        rotate(0, dir);
                        break;
                    case "R":
                        rotate(1, dir);
                        break;
                    case "B":
                        rotate(2, dir);
                        break;
                    case "L":
                        rotate(3, dir);
                        break;
                    case "U":
                        rotate(4, dir);
                        break;
                    case "D":
                        rotate(5, dir);
                        break;
                    default:
                        break;
                }
            }
            showFace(face);
            Console.Write(move);
            Console.Write("\n");
        }
    }

    public void translateAlg(string alg)
    {
        string[] moves = alg.Split(' ');
        foreach (var move in moves)
        {
            bool dir = move.Contains("'") ? false : true;
            int doubleMove = move.Contains("2") ? 2 : 1;
            string newMove = move.Replace("'", string.Empty).Replace("2", string.Empty);
            for (int i = 0; i < doubleMove; i++)
            {
                switch (newMove)
                {
                    case "F":
                        rotate(0, dir);
                        break;
                    case "R":
                        rotate(1, dir);
                        break;
                    case "B":
                        rotate(2, dir);
                        break;
                    case "L":
                        rotate(3, dir);
                        break;
                    case "U":
                        rotate(4, dir);
                        break;
                    case "D":
                        rotate(5, dir);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void showFace(int face)
    {
        for (int i = 0; i < 4; i++)
        {
            if (cubo[face].values[i] == 87)
                Console.BackgroundColor = ConsoleColor.White;
            if (cubo[face].values[i] == 89)
                Console.BackgroundColor = ConsoleColor.Yellow;
            if (cubo[face].values[i] == 66)
                Console.BackgroundColor = ConsoleColor.Blue;
            if (cubo[face].values[i] == 79)
                Console.BackgroundColor = ConsoleColor.Magenta;
            if (cubo[face].values[i] == 71)
                Console.BackgroundColor = ConsoleColor.Green;
            if (cubo[face].values[i] == 82)
                Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("|-|");
            if ((i + 1) % 2 == 0)
            {
                Console.ResetColor();
                Console.Write("\n");
            }
            else
                Console.Write(" ");
            Console.ResetColor();

        }
        Console.ResetColor();
    }

}