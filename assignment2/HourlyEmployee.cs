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
	public class HourlyEmployee : Employee
	{
		public override void computeGross()
		{
		Console.WriteLine("\nPlease enter hours worked: ");
		hours = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nPlease enter rate: ");
		rate = Convert.ToDouble(Console.ReadLine());

            if (hours <= 40)
			{
			gross = hours * rate;

			}
			else if (hours > 40)
			{
			double leftover = hours - 40;
			gross = (40 * rate) + (leftover * (rate * 1.5f));

			}

		}

	}

}