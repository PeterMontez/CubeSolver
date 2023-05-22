public class Solver2x2
{
    public Cubo2x2 cubinho { get; set; }
    public string[] faceNome { get; set; } = new string[] { "F", "R", "B", "L", "U", "B" };

    public Solver2x2(Cubo2x2 cubo)
    {
        cubinho = cubo;
    }

    public string BottomLayer()
    {
        int corBase = cubinho.cubo[5].values[0];
        int crr = 0;
        string bottomAlg = string.Empty;
        bool bottomCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[5].values[i] != corBase || cubinho.cubo[i].values[2] != cubinho.cubo[i].values[3])
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
                        case 3: case -1:
                            cubinho.rotate(4, true);
                            cubinho.rotate(4, true);
                            bottomAlg += " U2";
                            break;
                        case 2: case -2:
                            cubinho.rotate(4, true);
                            bottomAlg += " U";
                            break;
                        case 1: case -3:
                            cubinho.rotate(4, false);
                            bottomAlg += " U'";
                            break;
                        default:
                            break;
                    }

                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, false);
                    bottomAlg += " " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + " U2 " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + "' U' " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + " U " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + "'";
                }
            }
            System.Console.WriteLine(bottomAlg);
        }
        return bottomAlg;

    }

}