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

//      ---------------------- INPUT DO CUBO 2x2 ----------------------

// for (int i = 0; i < 6; i++)
// {

//     Console.WriteLine("-----------------");
//     Console.WriteLine($"FACE {i+1}");
//     Console.WriteLine("-----------------");

//     byte[] cores = new byte[4];
//     for (int j = 0; j < 4; j++)
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

//     Face2x2 facezinha = new Face2x2(cores);
//     cubomenor.addFace(facezinha, i);

//     Console.Write("\n");
//     foreach (var item in cores)
//     {
//         Console.Write(item);
//     }
//     Console.Write("\n");
// }

cubomenor.translateAlg(" F U2 F U' R U F2 U2 R");
cubomenor.showFace(0);
Solver2x2 solvemenor = new Solver2x2(cubomenor);
Console.WriteLine(solvemenor.BottomLayer());
Console.WriteLine(solvemenor.OrientTop());
Console.WriteLine(solvemenor.PermuteTop());

// cubinho.translateAlg("R'");
// Solver solucao = new Solver(cubinho);
// Console.WriteLine(solucao.Cross());
// Console.WriteLine(solucao.FirstCorners());
// Console.WriteLine(solucao.CenterEdges());
// Console.WriteLine(solucao.TopCross());
// Console.WriteLine(solucao.TopCorners());
// Console.WriteLine(solucao.PLL1());
// Console.WriteLine(solucao.Minerva());