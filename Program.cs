using System;

ConsoleKeyInfo cki;
Cubo cubinho = new Cubo();

byte[] validos = {87, 89, 71, 66, 79, 82};

// for (int i = 0; i < 6; i++)
// {

//     Console.WriteLine("-----------------");
//     Console.WriteLine($"FACE {i+1}");
//     Console.WriteLine("-----------------");

//     byte[] cores = new byte[9];
//     for (int j = 0; j < 9; j++)
//     {
//         while(true)
//         {
//             Console.WriteLine($"\nInsira o valor {j+1}");
//             cki = Console.ReadKey();
//             if(Array.IndexOf(validos, Convert.ToByte(cki.Key)) > -1)
//             {
//                 cores[j] = Convert.ToByte(cki.Key);
//                 break;
//             }
//             Console.WriteLine("Valor inválido");
//         }
//     }
//     Console.WriteLine("\n");

//     Face facezinha = new Face(cores);
//     cubinho.addFace(facezinha, i);

//     Console.Write("\n");
//     foreach (var item in cores)
//     {
//         Console.Write(item);
//     }
//     Console.Write("\n");
// }

cubinho.translateAlg("L2 U B2 F' L2 F2 L' F2 R D L2 R' D2 F2 L2 D2 U F U2 R' D' B' L2 F2 L R U L F L");
Solver solucao = new Solver(cubinho);
solucao.Cross();
solucao.FirstCorners();
solucao.CenterEdges();
solucao.TopCross();
solucao.TopCorners();
solucao.PLL1();
solucao.Minerva();