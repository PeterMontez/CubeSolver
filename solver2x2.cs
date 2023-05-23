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

                if (cubinho.cubo[i].values[2] == corBase)
                {
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i, false);
                    bottomAlg += " " + faceNome[i] + " U " + faceNome[i] + "'";
                }

                if (cubinho.cubo[i].values[3] == corBase)
                {
                    cubinho.rotate(i, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i, true);
                    bottomAlg += " " + faceNome[i] + "' U' " + faceNome[i];
                }

                if (cubinho.cubo[4].values[i] == corBase && cubinho.cubo[k].values[0] == cubinho.cubo[crr].values[2])
                {
                    switch (k - crr)
                    {
                        case 3:
                        case -1:
                            cubinho.rotate(4, true);
                            cubinho.rotate(4, true);
                            bottomAlg += " U2";
                            break;
                        case 2:
                        case -2:
                            cubinho.rotate(4, true);
                            bottomAlg += " U";
                            break;
                        case 0:
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
                    crr++;
                }

                if (cubinho.cubo[i].values[0] == corBase && cubinho.cubo[i - 1 < 0 ? 3 : i - 1].values[1] == cubinho.cubo[crr].values[2])
                {
                    switch (i - crr)
                    {
                        case 0:
                            cubinho.rotate(4, false);
                            bottomAlg += " U'";
                            break;
                        case 3:
                        case -1:
                            cubinho.rotate(4, true);
                            cubinho.rotate(4, true);
                            bottomAlg += " U2";
                            break;
                        case 2:
                        case -2:
                            cubinho.rotate(4, true);
                            bottomAlg += " U";
                            break;
                        default:
                            break;
                    }

                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(crr + 1 == 4 ? 0 : crr + 1, false);
                    bottomAlg += " " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + " U " + faceNome[crr + 1 == 4 ? 0 : crr + 1] + "'";
                    crr++;
                }

                switch (i)
                {
                    case 0: k = 3; break;
                    case 1: k = 1; break;
                    case 2: k = 0; break;
                    default: k = 2; break;
                }

                if (cubinho.cubo[i].values[1] == corBase && cubinho.cubo[4].values[k] == cubinho.cubo[crr].values[2])
                {
                    switch (i - crr)
                    {
                        case 1:
                        case -3:
                            cubinho.rotate(4, true);
                            bottomAlg += " U";
                            break;
                        case 2:
                        case -2:
                            cubinho.rotate(4, true);
                            cubinho.rotate(4, true);
                            bottomAlg += " U2";
                            break;
                        case 3:
                        case -1:
                            cubinho.rotate(4, false);
                            bottomAlg += " U'";
                            break;
                        default:
                            break;
                    }

                    cubinho.rotate(crr, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(crr, true);
                    bottomAlg += " " + faceNome[crr] + "' U' " + faceNome[crr];
                    crr++;
                }
            }
        }
        return algFixer(bottomAlg);
    }

    public string OrientTop()
    {
        byte corTopo = 0;

        switch (cubinho.cubo[5].values[0])
        {
            case 71: corTopo = 66; break;
            case 82: corTopo = 79; break;
            case 66: corTopo = 71; break;
            case 79: corTopo = 82; break;
            case 87: corTopo = 89; break;
            case 89: corTopo = 87; break;
            default: break;
        }
        string OrientTopAlg = string.Empty;
        int[] edgesIndex = new int[] { 2, 3, 1, 0 };
        bool checkTopCorners()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[4].values[i] != corTopo)
                {
                    return false;
                }
            }
            return true;
        }

        while (!checkTopCorners())
        {
            int topCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[4].values[edgesIndex[i]] == corTopo)
                {
                    topCount++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[4].values[edgesIndex[i]] == corTopo)
                {
                    switch (topCount)
                    {
                        case 1:
                            for (int j = 0; j < i; j++)
                            {
                                cubinho.rotate(4, true);
                                OrientTopAlg += " U";
                            }
                            cubinho.translateAlg("R U R' U R U2 R'");
                            OrientTopAlg += " R U R' U R U2 R'";
                            break;

                        case 2:
                            if (cubinho.cubo[4].values[edgesIndex[i + 1 == 4 ? 0 : i + 1]] == corTopo)
                            {
                                int uTurns = 0;
                                if (cubinho.cubo[i + 2 == 5 ? 1 : (i + 2 == 4 ? 0 : i + 2)].values[0] == corTopo)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            uTurns = 2;
                                            break;
                                        case 1:
                                            uTurns = 3;
                                            break;
                                        case 3:
                                            uTurns = 1;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            uTurns = 3;
                                            break;
                                        case 2:
                                            uTurns = 1;
                                            break;
                                        case 3:
                                            uTurns = 2;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                for (int j = 0; j < uTurns; j++)
                                {
                                    cubinho.rotate(4, true);
                                    OrientTopAlg += " U";
                                }
                                cubinho.translateAlg("R U R' U R U2 R'");
                                OrientTopAlg += " R U R' U R U2 R'";
                            }
                            else
                            {
                                if (cubinho.cubo[i].values[2] == corTopo)
                                {
                                    OrientTopAlg += " U'";
                                    cubinho.rotate(4, false);
                                }
                                else
                                {
                                    OrientTopAlg += " U";
                                    cubinho.rotate(4, true);
                                }
                                cubinho.translateAlg("R U R' U R U2 R'");
                                OrientTopAlg += " R U R' U R U2 R'";
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                }

                if (topCount == 0)
                {
                    cubinho.translateAlg("R U R' U R U2 R'");
                    OrientTopAlg += " R U R' U R U2 R'";
                }

            }

        }

        return algFixer(OrientTopAlg);

    }

    public string PermuteTop()
    {
        string PermuteTopAlg = string.Empty;
        bool done()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] != cubinho.cubo[i].values[1])
                    return false;
            }
            return true;
        }

        while(!done())
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] == cubinho.cubo[i].values[1])
                {
                    switch (i)
                    {
                        case 0:
                            cubinho.rotate(4, true);
                            PermuteTopAlg += " U";
                            break;
                        case 1:
                            cubinho.rotate(4, true);
                            cubinho.rotate(4, true);
                            PermuteTopAlg += " U2";
                            break;
                        case 2:
                            cubinho.rotate(4, false);
                            PermuteTopAlg += " U'";
                            break;
                        default:
                            break;
                    }

                    cubinho.translateAlg("R U R' U' R' F R2 U' R' U' R U R' F'");
                    PermuteTopAlg += " R U R' U' R' F R2 U' R' U' R U R' F'";
                }
            }

            if (!done())
            {
                cubinho.translateAlg("R U R' U' R' F R2 U' R' U' R U R' F'");
                PermuteTopAlg += " R U R' U' R' F R2 U' R' U' R U R' F'";
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (cubinho.cubo[0].values[0] == cubinho.cubo[i].values[2])
            {
                switch (i)
                {
                    case 1:
                        cubinho.rotate(4, true);
                        PermuteTopAlg += " U";
                        break;
                    case 2:
                        cubinho.rotate(4, true);
                        cubinho.rotate(4, true);
                        PermuteTopAlg += " U2";
                        break;
                    case 3:
                        cubinho.rotate(4, false);
                        PermuteTopAlg += " U'";
                        break;
                    default:
                        break;
                }
            }
        }
        return algFixer(PermuteTopAlg);
    }

    public string algFixer(string alg)
    {
        string firstMove = string.Empty;
        bool first = true;
        bool second = false;
        int count = 0;
        string[] moves = alg.TrimStart().Split(" ");
        string lastMove = string.Empty;
        bool changed = false;
        string newAlg = string.Empty;
        string anti = "'";
        string dois = "2";
        foreach (var move in moves)
        {
            count++;
            if (first && moves.Length != 1)
            {
                firstMove = move;
                first = false;
                second = true;
                lastMove = move;
                continue;
            }
            if (moves.Length == 1)
            {
                newAlg += move;
                continue;
            }
            if (changed)
            {
                newAlg += " " + move;
                continue;
            }

            if (move == lastMove)
            {
                if (!(move.Contains(dois)))
                {
                    newAlg += " " + move.Replace("'", string.Empty) + "2";
                }
                lastMove = string.Empty;
                changed = true;
            }
            else if (move.Replace("'", string.Empty).Replace("2", string.Empty) == lastMove.Replace("'", string.Empty).Replace("2", string.Empty))
            {
                if (move.Contains(dois))
                {
                    switch (lastMove.Contains(anti))
                    {
                        case true:
                            newAlg += " " + lastMove.Replace("'", string.Empty);
                            break;
                        case false:
                            newAlg += " " + lastMove + "'";
                            break;
                    }

                }
                else if (lastMove.Contains(dois))
                {
                    switch (move.Contains(anti))
                    {
                        case true:
                            newAlg += " " + move.Replace("'", string.Empty);
                            break;
                        case false:
                            newAlg += " " + move + "'";
                            break;
                    }
                }
                lastMove = string.Empty;
                changed = true;
            }
            else
            {
                if (second)
                {
                    second = false;
                    newAlg += firstMove;
                    lastMove = move;
                }
                else
                {
                    newAlg += " " + lastMove;
                    lastMove = move;
                    if (count == moves.Length)
                    {
                        newAlg += " " + move;
                    }
                }
            }
        }
        if (changed)
        {
            return(algFixer(newAlg));
        }
        else
        {
            return newAlg;
        }
    }

}