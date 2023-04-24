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

//cubinho.translateAlg("F2 L2 R B' L R' U' L B' U L R2 B' U2 B' D' L D2 L2 U F R' B D B U2 R2 U' L2 D");
Solver solucao = new Solver(cubinho);
solucao.Cross();
solucao.FirstCorners();
solucao.CenterEdges();
solucao.TopCross();
solucao.TopCorners();
solucao.PLL1();
solucao.Minerva();