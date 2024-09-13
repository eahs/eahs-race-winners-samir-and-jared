using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaceWinners.Models;

namespace RaceWinners;

public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService();

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync();

        for (int i = 0; i < data.Count; i++)
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks);
            
            Console.WriteLine($"{data[i].Name} - [{ranks}]");
        }

        Console.WriteLine();
        PrintWinner(data); // Prints the winning class in the race
	}

	// Prints the winning class in the race
    static void PrintWinner(List<Group> data)
    {
	    // Averages for each class
	    int avrgRankA = 0;
	    int avrgRankB = 0;
	    int avrgRankC = 0;
	    int avrgRankD = 0;

		// Goes through every class
		for (int i = 0; i < data.Count; i++)
	    {
		    var ranks = data[i].Ranks; // Ranks for class i

			// Goes through all the ranks of a class and adds them up 
		    for (int j = 0; j < ranks.Count; j++)
		    {
			    switch (i)
			    {
				    case 0:
					    avrgRankA += ranks[j];
						break;
				    case 1:
					    avrgRankB += ranks[j];
						break;
				    case 2:
					    avrgRankC += ranks[j];
						break;
				    case 3:
					    avrgRankD += ranks[j];
						break;
			    }
		    }

			// Divides the sum of ranks by the amount of students to get the average
		    switch (i)
		    {
			    case 0:
				    avrgRankA /= ranks.Count;
					break;
			    case 1:
				    avrgRankB /= ranks.Count;
					break;
			    case 2:
				    avrgRankC /= ranks.Count;
					break;
			    case 3:
				    avrgRankD /= ranks.Count;
					break;
		    }
	    }

		// Determines the lowest rank to determine the winning class
	    int winner = Math.Min(Math.Min(avrgRankA, avrgRankB), Math.Min(avrgRankC, avrgRankD));

		// Prints out the winning class
	    if (winner == avrgRankA) Console.WriteLine("Winning class is class A.");
	    else if (winner == avrgRankB) Console.WriteLine("Winning class is class B.");
	    else if (winner == avrgRankC) Console.WriteLine("Winning class is class C.");
	    else if (winner == avrgRankD) Console.WriteLine("Winning class is class D.");
	}
}