public class Solver2x2
{
    public Cubo2x2 cubinho { get; set; }
    public string[] faceNome { get; set; } = new string[] { "F", "R", "B", "L", "U", "B" };

    public Solver2x2(Cubo2x2 cubo)
    {
        cubinho = cubo;
    }

    public void BottomLayer()
    {
        int corBase = cubinho.cubo[0].values[0];
        int crr = 0;
        bool bottomCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[0].values[i] != corBase || cubinho.cubo[i].values[2] != cubinho.cubo[i].values[3])
                    return false;
            }
            return true;
        }

        while (!bottomCheck())
        {
            for (int i = 0; i < 4; i++)
            {
                int k = 1;
                switch (i)
                {
                    case 0: k = 3; break;
                    case 1: k = 2; break;
                    case 2: k = 0; break;
                    default: break;
                }

                if (cubinho.cubo[4].values[i] == corBase && cubinho.cubo[k].values[0] == cubinho.cubo[crr].values[2])
                {
                    switch (k - crr)
                    {
                        case 0:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }

}