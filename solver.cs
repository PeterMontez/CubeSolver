public class Solver
{
    public Cubo cubinho { get; set; }
    public string[] faceNome { get; set; } = new string[] {"F", "R", "B", "L", "U", "B"};
    
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
            for (int i = 1; i < 8; i = i+2)
            {
                if (!(cubinho.cubo[5].values[i] == corBase && cubinho.cubo[(i-1)/2].values[7] == cubinho.cubo[(i-1)/2].values[4]))
                {
                    return false;
                }
            }
            return true;
        }
        
        while(!crossCheck())
        {
            for (int r = 0; r < 4; r++)
            {
                // ESSE FOR TESTA AS PEÇAS DA CRUZ QUE JÁ ESTÃO NA CRUZ, MAS NO LUGAR ERRADO, E COLOCA NO LUGAR CERTO. COD0x000
                for (int k = 1; k < 8; k = k+2)
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
                        cubinho.rotate(i,true); 
                        cubinho.rotate(i,true); 
                        crossAlg += " " + faceNome[i] + "2";
                        for (int j = 0; j < 4; j++)
                        {
                            if(cubinho.cubo[j].values[4] == cubinho.cubo[i].values[1])
                            {
                                switch ((j-(i)))
                                {
                                    case 2:
                                    case -2:
                                        cubinho.rotate(4,true);
                                        cubinho.rotate(4,true);
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
                                    default:
                                        Console.WriteLine("DEU UM ERRO AQUI, FORMAÇÃO DA CRUZ, PEÇA ORIENTADA CERTA NO LUGAR ERRADO");
                                        break;
                                }
                                break;
                            }
                        }
                    }
                }
                //FIM DO FOR COD0x000
            }
            Console.WriteLine(crossAlg);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 8; j = j+2)
                {
                    if (cubinho.cubo[i].values[j] == corBase)
                    {
                        
                    }
                }
            }
        }

    }

}