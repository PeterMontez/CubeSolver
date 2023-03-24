public class Face
{
    public byte[] values { get; set; }

    public Face(byte[] cores)
    {
        this.values = cores;
    }

    public void cW()
    {
        byte[] newFace = new byte[9] { values[6], values[3], values[0], values[7], values[4], values[1], values[8], values[5], values[2] };
        newFace.CopyTo(values, 0);
    }

    public void AcW()
    {
        byte[] newFace = new byte[9] { values[2], values[5], values[8], values[1], values[4], values[7], values[0], values[3], values[6] };
        newFace.CopyTo(values, 0);
    }
}

public class Cubo
{
    public Face[] cubo { get; set; } = new Face[6];
    public int[][] relations { get; set; } = new int[6][];
    public int[] side0 { get; set; } = new int[] {0, 1, 2};
    public int[] side1 { get; set; } = new int[] {2, 5, 8};
    public int[] side2 { get; set; } = new int[] {6, 7, 8};
    public int[] side3 { get; set; } = new int[] {0, 3, 6};
    

    public Cubo()
    {
        relations[0] = new int[4] {4, 1, 5, 3};
        relations[1] = new int[4] {4, 2, 5, 0};
        relations[2] = new int[4] {4, 3, 5, 1};
        relations[3] = new int[4] {4, 0, 5, 2};
        relations[4] = new int[4] {2, 1, 0, 3};
        relations[5] = new int[4] {0, 1, 2, 3};
    }

    public void addFace(Face face, int pos)
    {
        cubo[pos] = face;
    }

    public void rotate(int face, bool dir)
    {
        if (dir)
        {
            cubo[face].cW();
            int[] tempFace = new int[3];
            switch (face)
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side2[i]];
                        cubo[relations[face][0]].values[side2[i]] = cubo[relations[face][3]].values[side1[Math.Abs(i-2)]];
                        cubo[relations[face][3]].values[side1[Math.Abs(i-2)]] = cubo[relations[face][2]].values[side0[Math.Abs(i-2)]];
                        cubo[relations[face][2]].values[side0[Math.Abs(i-2)]] = cubo[relations[face][1]].values[side3[i]];
                        cubo[relations[face][1]].values[side3[i]] = (byte)tempFace[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side1[i]];
                        cubo[relations[face][0]].values[side1[i]] = cubo[relations[face][3]].values[side1[i]];
                        cubo[relations[face][3]].values[side2[i]] = cubo[relations[face][2]].values[side1[i]];
                        cubo[relations[face][2]].values[side1[i]] = cubo[relations[face][1]].values[side3[Math.Abs(i-2)]];
                        cubo[relations[face][1]].values[side3[Math.Abs(i-2)]] = (byte)tempFace[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side0[i]];
                        cubo[relations[face][0]].values[side0[i]] = cubo[relations[face][3]].values[side1[i]];
                        cubo[relations[face][3]].values[side1[i]] = cubo[relations[face][2]].values[side2[Math.Abs(i-2)]];
                        cubo[relations[face][2]].values[side2[Math.Abs(i-2)]] = cubo[relations[face][1]].values[side3[Math.Abs(i-2)]];
                        cubo[relations[face][1]].values[side3[Math.Abs(i-2)]] = (byte)tempFace[i];
                    }
                    break;
                case 3: //TODO - TA TOTALMENTE ERRADO, SÓ COPIADO E COLADO AQUI
                    for (int i = 0; i < 3; i++)
                    {
                        tempFace[i] = cubo[relations[face][0]].values[side0[i]];
                        cubo[relations[face][0]].values[side0[i]] = cubo[relations[face][3]].values[side1[i]];
                        cubo[relations[face][3]].values[side2[i]] = cubo[relations[face][2]].values[side1[i]];
                        cubo[relations[face][2]].values[side1[i]] = cubo[relations[face][1]].values[side3[Math.Abs(i-2)]];
                        cubo[relations[face][1]].values[side3[Math.Abs(i-2)]] = (byte)tempFace[i];
                    }
                    break;
                case 4: //TODO
                    break;


                default:
                    break;
            }
        }
    }

    public void showFace(int face)
    {
        for (int i = 0; i < 9; i++)
        {
            if (cubo[face].values[i] == 87)
                Console.BackgroundColor = ConsoleColor.White;
            else if (cubo[face].values[i] == 89)
                Console.BackgroundColor = ConsoleColor.Yellow;
            if (cubo[face].values[i] == 66)
                Console.BackgroundColor = ConsoleColor.Blue;
            if (cubo[face].values[i] == 79)
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write()
        }
        Console.WriteLine($"{cubo[face].values[0]}, {cubo[face].values[1]}, {cubo[face].values[2]}");
        Console.WriteLine($"{cubo[face].values[3]}, {cubo[face].values[4]}, {cubo[face].values[5]}");
        Console.WriteLine($"{cubo[face].values[6]}, {cubo[face].values[7]}, {cubo[face].values[8]}");
    }

}