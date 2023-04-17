public class Solver
{
    public Cubo cubinho { get; set; }
    public string[] faceNome { get; set; } = new string[] { "F", "R", "B", "L", "U", "B" };

    public Solver(Cubo cubo)
    {
        cubinho = cubo;
    }

    public void Cross()
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
        Console.WriteLine(crossAlg);

    } 

    public void FirstCorners()
    {
        string firstCornersAlg = string.Empty;
        byte corBase = cubinho.cubo[5].values[4];
        int[] rightWhite = new int[] {6, 8, 2, 0};
        int[] leftWhite = new int[] {8, 2, 0, 6};
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
            Console.WriteLine(firstCornersAlg);
    }

    public void CenterEdges()
    {
        
    }

}