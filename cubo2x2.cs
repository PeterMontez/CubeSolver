public class Cubo2x2
{
    public Peca2x2[] cubo { get; set; } = new Peca2x2[8];
    private int[][] relations { get; set; } = new int[6][];

    public Cubo2x2()
    {
        this.cubo[0] = new Peca2x2(new byte[]{87, 79, 66});
        this.cubo[1] = new Peca2x2(new byte[]{87, 66, 82});
        this.cubo[2] = new Peca2x2(new byte[]{87, 82, 71});
        this.cubo[3] = new Peca2x2(new byte[]{87, 71, 79});

        this.cubo[4] = new Peca2x2(new byte[]{89, 66, 79});
        this.cubo[5] = new Peca2x2(new byte[]{89, 82, 66});
        this.cubo[6] = new Peca2x2(new byte[]{89, 71, 82});
        this.cubo[7] = new Peca2x2(new byte[]{89, 79, 71});

        relations[0] = new int[4] { 2, 3, 6, 7 };
        relations[1] = new int[4] { 3, 1, 7, 5 };
        relations[2] = new int[4] { 1, 0, 5, 4 };
        relations[3] = new int[4] { 0, 2, 4, 6 };
        relations[4] = new int[4] { 0, 1, 2, 3 };
        relations[5] = new int[4] { 6, 7, 4, 5 };
    }

    public void rotate(int face, bool dir)
    {
        switch (face)
        {
            case 0:
                cubo = new Peca2x2[]{cubo[0], cubo[1], cubo[6], cubo[2], cubo[4], cubo[5], cubo[7], cubo[3]};
                foreach (var peca in relations[0])
                {
                    cubo[peca].rotate(true);
                }
                break;
            case 1:
            default:
                break;
        }
    }
}

public class Peca2x2
{
    public byte[] cores = new byte[3];

    public Peca2x2(byte[] cores)
    {
        this.cores = cores;
    }

    public void rotate(bool dir)
    {
        if (dir)
            cores = new byte[]{cores[2], cores[0], cores[1]};
        else
            cores = new byte[]{cores[1], cores[2], cores[0]};
    }

}