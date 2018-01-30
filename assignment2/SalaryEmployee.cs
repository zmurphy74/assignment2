using System;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
namespace assignment2
{


	/// 
	/// <summary>
	/// @author ztmvf2
	/// </summary>
	[Serializable()]
	public class SalaryEmployee : Employee
	{
		public override void computeGross()
		{

			Console.WriteLine("\nAre you staff or executive? Use an (1) for staff or an (2) for executive: ");
            int selection = Convert.ToInt32(Console.ReadLine());

			if (selection == 1)
			{
			Console.WriteLine("\nAs a staff employee your salary is $50,000.\n");
			gross = 50000;
			}
			else if (selection == 2)
			{
			Console.WriteLine("\nAs an executive employee your salary is $100,000.\n");
			gross = 100000;
			}
			else if (selection != 1 || selection != 2)
			{
			Console.WriteLine("\nPlease enter a number that corresponds to the prompt.\n");
			}

		}

	}

}