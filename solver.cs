public class Solver
{
    public Cubo cubinho { get; set; }
    public string[] faceNome { get; set; } = new string[] { "F", "R", "B", "L", "U", "B" };

    public Solver(Cubo cubo)
    {
        cubinho = cubo;
    }

    public string Cross()
    {
        string crossAlg = string.Empty;
        byte corBase = cubinho.cubo[5].values[4];
        bool crossCheck()
        {
            for (int i = 1; i < 8; i = i + 2)
            {
                if (!(cubinho.cubo[5].values[i] == corBase && cubinho.cubo[(i - 1) / 2].values[7] == cubinho.cubo[(i - 1) / 2].values[4]))
                {
                    return false;
                }
            }
            return true;
        }

        void whiteOnTop()
        {
            // ESSE FOR TESTA AS PEÇAS DA CRUZ QUE ESTÃO NA CAMADA DE CIMA, COM O BRANCO PRA CIMA, E COLOCA NO LUGAR CERTO.
            for (int k = 1; k < 8; k = k + 2)
            {
                int i;
                switch (k)
                {
                    case 1:
                        i = 2;
                        break;
                    case 5:
                        i = 1;
                        break;
                    case 7:
                        i = 0;
                        break;
                    default:
                        i = k;
                        break;
                }
                if (cubinho.cubo[4].values[k] == corBase)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cubinho.cubo[j].values[4] == cubinho.cubo[i].values[1])
                        {
                            switch ((j - (i)))
                            {
                                case 2:
                                case -2:
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(4, true);
                                    crossAlg += " U2";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(j, true);
                                    crossAlg += " " + faceNome[j] + "2";
                                    break;
                                case 1:
                                case -3:
                                    cubinho.rotate(4, false);
                                    crossAlg += " U'";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(j, true);
                                    crossAlg += " " + faceNome[j] + "2";
                                    break;
                                case -1:
                                case 3:
                                    cubinho.rotate(4, true);
                                    crossAlg += " U";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(j, true);
                                    crossAlg += " " + faceNome[j] + "2";
                                    break;
                                case 0:
                                    cubinho.rotate(i, true);
                                    cubinho.rotate(i, true);
                                    crossAlg += " " + faceNome[i] + "2";
                                    break;
                                default:
                                    Console.WriteLine("DEU UM ERRO AQUI, FORMAÇÃO DA CRUZ, PEÇA ORIENTADA CERTA NO LUGAR ERRADO");
                                    break;
                            }
                            break;
                        }
                    }
                }
            }
        }

        while (!crossCheck())
        {
            // ESSE FOR TESTA AS PEÇAS DA CRUZ QUE JÁ ESTÃO NA CRUZ, MAS NO LUGAR ERRADO, E COLOCA NO LUGAR CERTO. COD0x000
            for (int k = 1; k < 8; k = k + 2)
            {
                int i;
                switch (k)
                {
                    case 1:
                        i = 0;
                        break;
                    case 5:
                        i = 1;
                        break;
                    case 7:
                        i = 2;
                        break;
                    default:
                        i = k;
                        break;
                }
                if (cubinho.cubo[5].values[k] == corBase && cubinho.cubo[i].values[7] != cubinho.cubo[i].values[4])
                {
                    cubinho.rotate(i, true);
                    cubinho.rotate(i, true);
                    crossAlg += " " + faceNome[i] + "2";
                    whiteOnTop();
                }
            }
            //FIM DO FOR COD0x000

            // ESSE FOR ARRUMA AS PEÇAS QUE ESTÃO NA CAMADA DO MEIO E COLOCA NA CRUZ COD0x003
            for (int k = 3; k < 6; k = k + 2)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (cubinho.cubo[y].values[k] == corBase)
                    {
                        cubinho.rotate(k == 5 ? (y + 1 == 4 ? 0 : y + 1) : (y - 1 == -1 ? 3 : y - 1), k == 5 ? true : false);
                        cubinho.rotate(4, true);
                        cubinho.rotate(k == 5 ? (y + 1 == 4 ? 0 : y + 1) : (y - 1 == -1 ? 3 : y - 1), k == 5 ? false : true);
                        crossAlg += " " + faceNome[k == 5 ? (y + 1 == 4 ? 0 : y + 1) : (y - 1 == -1 ? 3 : y - 1)] + (k == 5 ? "" : "'");
                        crossAlg += " U " + faceNome[k == 5 ? (y + 1 == 4 ? 0 : y + 1) : (y - 1 == -1 ? 3 : y - 1)] + (k == 5 ? "'" : "");
                        whiteOnTop();
                    }
                }
            }
            //FIM DO FOR COD0x003

            //ESSE FOR PEGA AS PEÇAS DA CAMADA DE BAIXO OU DE CIMA ORIENTADAS ERRADAS E COLOCA ORIENTADA PRA CIMA
            for (int k = 0; k < 4; k++)
            {
                if (cubinho.cubo[k].values[1] == corBase)
                {
                    cubinho.rotate(k, true);
                    cubinho.rotate(k + 1 == 4 ? 0 : k + 1, true);
                    cubinho.rotate(4, false);
                    cubinho.rotate(k + 1 == 4 ? 0 : k + 1, false);
                    cubinho.rotate(k, false);
                    crossAlg += " " + faceNome[k] + " " + faceNome[k + 1 == 4 ? 0 : k + 1] + " U' " + faceNome[k + 1 == 4 ? 0 : k + 1] + "' " + faceNome[k] + "'";
                    whiteOnTop();
                }
            }
            //FIM DO FOR COD0x004

            for (int k = 0; k < 4; k++)
            {
                if (cubinho.cubo[k].values[7] == corBase)
                {
                    cubinho.rotate(k, true);
                    cubinho.rotate(k, true);
                    crossAlg += " " + faceNome[k] + "2";
                    whiteOnTop();
                }
            }
            whiteOnTop();
        }
        return algFixer(crossAlg);

    }

    public string FirstCorners()
    {
        string firstCornersAlg = string.Empty;
        byte corBase = cubinho.cubo[5].values[4];
        int[] rightWhite = new int[] { 6, 8, 2, 0 };
        int[] leftWhite = new int[] { 8, 2, 0, 6 };
        bool cornersCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[6] != cubinho.cubo[i].values[4] || cubinho.cubo[i].values[8] != cubinho.cubo[i].values[4])
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i = i + 2)
            {
                if (cubinho.cubo[5].values[i] != cubinho.cubo[5].values[4])
                {
                    return false;
                }
            }
            return true;
        }

        void cornerOnSide()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] == corBase)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cubinho.cubo[j].values[4] == cubinho.cubo[4].values[rightWhite[i]])
                        {
                            switch (j - i)
                            {
                                case 0:
                                    cubinho.rotate(i, true);
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(i, false);
                                    firstCornersAlg += " " + faceNome[j] + " U " + faceNome[j] + "'";
                                    break;
                                case 2:
                                case -2:
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(4, true);
                                    firstCornersAlg += " U2";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(j, false);
                                    firstCornersAlg += " " + faceNome[j] + " U " + faceNome[j] + "'";
                                    break;
                                case 1:
                                case -3:
                                    cubinho.rotate(4, false);
                                    firstCornersAlg += " U'";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(j, false);
                                    firstCornersAlg += " " + faceNome[j] + " U " + faceNome[j] + "'";
                                    break;
                                case -1:
                                case 3:
                                    cubinho.rotate(4, true);
                                    firstCornersAlg += " U";
                                    cubinho.rotate(j, true);
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(j, false);
                                    firstCornersAlg += " " + faceNome[j] + " U " + faceNome[j] + "'";
                                    break;
                                default:
                                    Console.WriteLine("DEU UM ERRO AQUI, COLOCACAO DAS QUINAS INFERIORES DIREITAS");
                                    break;
                            }
                        }
                    }
                }

                if (cubinho.cubo[i].values[2] == corBase)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cubinho.cubo[j].values[4] == cubinho.cubo[4].values[leftWhite[i]])
                        {
                            switch (j - i)
                            {
                                case 0:
                                    cubinho.rotate(j, false);
                                    cubinho.rotate(4, false);
                                    cubinho.rotate(j, true);
                                    firstCornersAlg += " " + faceNome[j] + "' U' " + faceNome[j];
                                    break;
                                case 2:
                                case -2:
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(4, true);
                                    firstCornersAlg += " U2";
                                    cubinho.rotate(j, false);
                                    cubinho.rotate(4, false);
                                    cubinho.rotate(j, true);
                                    firstCornersAlg += " " + faceNome[j] + "' U' " + faceNome[j];
                                    break;
                                case 1:
                                case -3:
                                    cubinho.rotate(4, false);
                                    firstCornersAlg += " U'";
                                    cubinho.rotate(j, false);
                                    cubinho.rotate(4, false);
                                    cubinho.rotate(j, true);
                                    firstCornersAlg += " " + faceNome[j] + "' U' " + faceNome[j];
                                    break;
                                case -1:
                                case 3:
                                    cubinho.rotate(4, true);
                                    firstCornersAlg += " U";
                                    cubinho.rotate(j, false);
                                    cubinho.rotate(4, false);
                                    cubinho.rotate(j, true);
                                    firstCornersAlg += " " + faceNome[j] + "' U' " + faceNome[j];
                                    break;
                                default:
                                    Console.WriteLine("DEU UM ERRO AQUI, COLOCACAO DAS QUINAS INFERIORES DIREITAS");
                                    break;
                            }
                        }
                    }
                }
            }
        }

        while (!cornersCheck())
        {
            cornerOnSide();
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[6] == corBase)
                {
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i, false);
                    firstCornersAlg += " " + faceNome[i] + " U " + faceNome[i] + "'";
                    cornerOnSide();
                }
                if (cubinho.cubo[i].values[8] == corBase)
                {
                    cubinho.rotate(i, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i, true);
                    firstCornersAlg += " " + faceNome[i] + "' U' " + faceNome[i];
                    cornerOnSide();
                }
            }

            for (int i = 0; i < 9; i = i + 2)
            {
                if (cubinho.cubo[4].values[i] == corBase && i != 4)
                {
                    int k = i;
                    switch (i)
                    {
                        case 0:
                            k = 3;
                            break;
                        case 6:
                            k = 0;
                            break;
                        case 8:
                            k = 1;
                            break;
                        default:
                            break;
                    }
                    cubinho.rotate(k, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(k, false);
                    firstCornersAlg += " " + faceNome[k] + " U2 " + faceNome[k] + "'";
                    cornerOnSide();
                }
            }

            for (int i = 0; i < 4; i++)
            {

            }
        }
        return algFixer(firstCornersAlg);
    }

    public string CenterEdges()
    {
        string edgesAlg = string.Empty;
        bool edgesCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[3] != cubinho.cubo[i].values[4] || cubinho.cubo[i].values[5] != cubinho.cubo[i].values[4])
                {
                    return false;
                }
            }
            return true;
        }
        byte corTopo = cubinho.cubo[4].values[4];

        void edgeOnTop()
        {
            for (int i = 0; i < 4; i++)
            {
                int[] topEdges = new int[] { 7, 5, 1, 3 };
                int k = topEdges[i];
                if (cubinho.cubo[i].values[1] != corTopo && cubinho.cubo[4].values[k] != corTopo)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cubinho.cubo[i].values[1] == cubinho.cubo[j].values[4])
                        {
                            switch (j - i)
                            {
                                case 2:
                                case -2:
                                    cubinho.rotate(4, true);
                                    cubinho.rotate(4, true);
                                    edgesAlg += " U2";
                                    k = topEdges[j];
                                    break;
                                case 1:
                                case -3:
                                    cubinho.rotate(4, false);
                                    edgesAlg += " U'";
                                    k = topEdges[j];
                                    break;
                                case -1:
                                case 3:
                                    cubinho.rotate(4, true);
                                    edgesAlg += " U";
                                    k = topEdges[j];
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("DEU UM ERRO AQUI, FORMAÇÃO DA CRUZ, PEÇA ORIENTADA CERTA NO LUGAR ERRADO");
                                    break;

                            }

                            if (cubinho.cubo[4].values[k] == cubinho.cubo[j + 1 == 4 ? 0 : j + 1].values[4])
                            {
                                cubinho.rotate(4, true);
                                cubinho.rotate(j + 1 == 4 ? 0 : j + 1, true);
                                cubinho.rotate(4, true);
                                cubinho.rotate(j + 1 == 4 ? 0 : j + 1, false);
                                cubinho.rotate(4, false);
                                cubinho.rotate(j, false);
                                cubinho.rotate(4, false);
                                cubinho.rotate(j, true);
                                edgesAlg += " U " + faceNome[j + 1 == 4 ? 0 : j + 1] + " U " + faceNome[j + 1 == 4 ? 0 : j + 1] + "' U' " + faceNome[j] + "' U' " + faceNome[j];
                                break;
                            }
                            else
                            {
                                cubinho.rotate(4, false);
                                cubinho.rotate(j - 1 == -1 ? 3 : j - 1, false);
                                cubinho.rotate(4, false);
                                cubinho.rotate(j - 1 == -1 ? 3 : j - 1, true);
                                cubinho.rotate(4, true);
                                cubinho.rotate(j, true);
                                cubinho.rotate(4, true);
                                cubinho.rotate(j, false);
                                edgesAlg += " U' " + faceNome[j - 1 == -1 ? 3 : j - 1] + "' U' " + faceNome[j - 1 == -1 ? 3 : j - 1] + " U " + faceNome[j] + " U " + faceNome[j] + "'";
                                break;
                            }

                        }
                    }
                }
            }
        }

        while (!edgesCheck())
        {
            edgeOnTop();
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[3] != cubinho.cubo[i].values[4] && cubinho.cubo[i].values[3] != corTopo && cubinho.cubo[i - 1 == -1 ? 3 : i - 1].values[5] != cubinho.cubo[i - 1 == -1 ? 3 : i - 1].values[4] && cubinho.cubo[i - 1 == -1 ? 3 : i - 1].values[5] != corTopo)
                {
                    cubinho.rotate(i - 1 == -1 ? 3 : i - 1, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i - 1 == -1 ? 3 : i - 1, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i, false);
                    edgesAlg += " " + faceNome[i - 1 == -1 ? 3 : i - 1] + "' U' " + faceNome[i - 1 == -1 ? 3 : i - 1] + " U " + faceNome[i] + " U " + faceNome[i] + "'";
                }
            }
        }
        return algFixer(edgesAlg);
    }

    public string TopCross()
    {
        string topCrossAlg = string.Empty;
        byte corTopo = cubinho.cubo[4].values[4];
        int[] crossPieces = new int[] { 1, 3, 7, 5 };
        bool topCrossCheck()
        {
            for (int i = 1; i < 8; i = i + 2)
            {
                if (cubinho.cubo[4].values[i] != cubinho.cubo[4].values[4])
                {
                    return false;
                }
            }
            return true;
        }

        while (!topCrossCheck())
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[4].values[crossPieces[i]] == cubinho.cubo[4].values[crossPieces[i + 2 == 4 ? 0 : (i + 2 == 5 ? 1 : i + 2)]] && cubinho.cubo[4].values[crossPieces[i]] == corTopo)
                {
                    cubinho.rotate(i - 1 == -1 ? 3 : i - 1, true);
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i, false);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i - 1 == -1 ? 3 : i - 1, false);
                    topCrossAlg += " " + faceNome[i - 1 == -1 ? 3 : i - 1] + " " + faceNome[i] + " U " + faceNome[i] + "' U' " + faceNome[i - 1 == -1 ? 3 : i - 1] + "'";
                    break;
                }
                if (cubinho.cubo[4].values[crossPieces[i]] == cubinho.cubo[4].values[crossPieces[i + 1 == 4 ? 0 : i + 1]] && cubinho.cubo[4].values[crossPieces[i]] == corTopo)
                {
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i + 1 == 4 ? 0 : i + 1, true);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i + 1 == 4 ? 0 : i + 1, false);
                    cubinho.rotate(i, false);
                    topCrossAlg += " " + faceNome[i] + " U " + faceNome[i + 1 == 4 ? 0 : i + 1] + " U' " + faceNome[i + 1 == 4 ? 0 : i + 1] + "' " + faceNome[i] + "'";
                    break;
                }
                else if (i == 3)
                {
                    cubinho.rotate(i, true);
                    cubinho.rotate(4, true);
                    cubinho.rotate(i + 1 == 4 ? 0 : i + 1, true);
                    cubinho.rotate(4, false);
                    cubinho.rotate(i + 1 == 4 ? 0 : i + 1, false);
                    cubinho.rotate(i, false);
                    topCrossAlg += " " + faceNome[i] + " U " + faceNome[i + 1 == 4 ? 0 : i + 1] + " U' " + faceNome[i + 1 == 4 ? 0 : i + 1] + "' " + faceNome[i] + "'";
                    break;
                }

            }
        }
        return algFixer(topCrossAlg);
    }

    public string TopCorners()
    {
        string TopCornersAlg = string.Empty;
        byte corTopo = cubinho.cubo[4].values[4];
        int[] edgesIndex = new int[] { 6, 8, 2, 0 };
        bool checkTopCorners()
        {
            for (int i = 0; i < 9; i = i + 2)
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
                                TopCornersAlg += " U";
                            }
                            cubinho.translateAlg("R U R' U R U2 R'");
                            TopCornersAlg += " R U R' U R U2 R'";
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
                                    TopCornersAlg += " U";
                                }
                                cubinho.translateAlg("R U R' U R U2 R'");
                                TopCornersAlg += " R U R' U R U2 R'";
                            }
                            else
                            {
                                if (cubinho.cubo[i].values[2] == corTopo)
                                {
                                    TopCornersAlg += " U'";
                                    cubinho.rotate(4, false);
                                }
                                else
                                {
                                    TopCornersAlg += " U";
                                    cubinho.rotate(4, true);
                                }
                                cubinho.translateAlg("R U R' U R U2 R'");
                                TopCornersAlg += " R U R' U R U2 R'";
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
                    TopCornersAlg += " R U R' U R U2 R'";
                }

            }

        }

        return algFixer(TopCornersAlg);

    }

    public string PLL1()
    {
        string PLL1Alg = string.Empty;
        bool isMinerva()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] != cubinho.cubo[i].values[2])
                {
                    return false;
                }
            }
            return true;
        }

        while (!isMinerva())
        {
            int uTurns = 0;
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] == cubinho.cubo[i].values[2])
                {
                    switch (i)
                    {
                        case 0: uTurns = 2; break;
                        case 1: uTurns = 3; break;
                        case 3: uTurns = 1; break;
                        default: break;
                    }
                    for (int j = 0; j < uTurns; j++)
                    {
                        cubinho.rotate(4, true);
                        PLL1Alg += " U";
                    }
                    cubinho.translateAlg("R' F R' B2 R F' R' B2 R2");
                    PLL1Alg += " R' F R' B2 R F' R' B2 R2";
                    break;
                }
                else if (i == 3)
                {
                    cubinho.translateAlg("R' F R' B2 R F' R' B2 R2");
                    PLL1Alg += " R' F R' B2 R F' R' B2 R2";
                }
            }
        }
        return algFixer(PLL1Alg);
    }

    public string Minerva()
    {
        string minervaAlg = string.Empty;
        bool minervaCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubinho.cubo[i].values[0] != cubinho.cubo[i].values[1] || cubinho.cubo[i].values[1] != cubinho.cubo[i].values[2])
                {
                    return false;
                }
            }
            return true;
        }

        while (!minervaCheck())
        {
            for (int i = 0; i < 4; i++)
            {
                int uTurns = 0;
                if (cubinho.cubo[i].values[0] == cubinho.cubo[i].values[1] && cubinho.cubo[i].values[1] == cubinho.cubo[i].values[2])
                {
                    switch (i)
                    {
                        case 0: uTurns = 2; break;
                        case 1: uTurns = 3; break;
                        case 3: uTurns = 1; break;
                        default: break;
                    }
                    for (int j = 0; j < uTurns; j++)
                    {
                        cubinho.rotate(4, true);
                        minervaAlg += " U";
                    }
                    cubinho.rotate(0, true);
                    cubinho.rotate(0, true);
                    minervaAlg += " F2";
                    if (cubinho.cubo[1].values[1] == cubinho.cubo[0].values[1])
                    {
                        cubinho.translateAlg("U R' L F2 R L' U F2");
                        minervaAlg += " U R' L F2 R L' U F2";
                    }
                    else
                    {
                        cubinho.translateAlg("U' R' L F2 R L' U' F2");
                        minervaAlg += " U' R' L F2 R L' U' F2";
                    }
                    break;
                }
                if (i == 3)
                {
                    cubinho.translateAlg("F2 U R' L F2 R L' U F2");
                    minervaAlg += " F2 U R' L F2 R L' U F2";
                }
            }

            if (minervaCheck())
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cubinho.cubo[0].values[1] == cubinho.cubo[i].values[4])
                    {
                        switch (i)
                        {
                            case 1:
                                cubinho.rotate(4, false);
                                minervaAlg += " U'";
                                break;
                            case 2:
                                cubinho.rotate(4, true);
                                cubinho.rotate(4, true);
                                minervaAlg += " U2";
                                break;
                            case 3:
                                cubinho.rotate(4, true);
                                minervaAlg += " U";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }
        return algFixer(minervaAlg);
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