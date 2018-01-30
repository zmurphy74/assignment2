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
	public class CommissionEmployee : Employee
	{


	public override void computeGross()
	{
		Console.WriteLine("\nPlease enter the number of items sold: ");
		double items = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nPlease enter the unit price of item sold: ");
		double price = Convert.ToDouble(Console.ReadLine());
        gross = (items * price) / 2;
	}

	}

}