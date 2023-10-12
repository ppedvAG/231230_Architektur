// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


var s1 = new Schrank.Builder()
                    .SetBöden(3)
                    .SetTüren(4)
                    .SetFarbe("rot")
                    .Create();


Schrank.Builder schreiner = new Schrank.Builder()
                    .SetBöden(3)
                    .SetTüren(4)
                    .SetFarbe("rot");

Schrank s2 = schreiner.SetFarbe("blau").Create();

Schrank s3 = schreiner.Create();