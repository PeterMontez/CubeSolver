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
                case 2: case 4: case 5:
                    cubo[relations[face][0]].values[];

                default:
                    break;
            }
            cubo[relations[face][0]].values[];
        }
    }

}