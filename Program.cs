using System;

ConsoleKeyInfo cki;
Cubo cubinho = new Cubo();

Cubo2x2 cubomenor = new Cubo2x2();

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

cubomenor.translateAlg("R U R' U' R U2 R' U");
cubomenor.showFace(0);
Solver2x2 solvemenor = new Solver2x2(cubomenor);
Console.WriteLine(solvemenor.BottomLayer());

// cubinho.translateAlg("R'");
// Solver solucao = new Solver(cubinho);
// Console.WriteLine(solucao.Cross());
// Console.WriteLine(solucao.FirstCorners());
// Console.WriteLine(solucao.CenterEdges());
// Console.WriteLine(solucao.TopCross());
// Console.WriteLine(solucao.TopCorners());
// Console.WriteLine(solucao.PLL1());
// Console.WriteLine(solucao.Minerva());