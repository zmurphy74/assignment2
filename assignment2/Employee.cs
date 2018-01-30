using System;
using System.Xml.Serialization;

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
    [XmlInclude(typeof(CommissionEmployee))]
    [XmlInclude(typeof(HourlyEmployee))]
    [XmlInclude(typeof(SalaryEmployee))]
	public abstract class Employee
	{
	public double rate = 0;
	public double taxrate = .1;
	public double hours = 0;
	public double gross = 0;
    
    public double tax = 0;
	public bool taxed = false;
	public double net = 0;
	internal bool netted = false;
	internal double net_percent = 0;
	internal bool netperc = false;
	
	private int id;

	internal Payroll p = new Payroll();


		public virtual void computeGross()
		{
		gross = rate * hours;
		}

		public virtual void dispGross()
		{
        
            Console.WriteLine("\nYour gross is: " + gross.ToString("C0") + "\n");

		}

		protected internal virtual void computeTax()
		{
			tax = gross * taxrate;
            Console.WriteLine("\nYour taxes are: " + tax.ToString("C0") + "\n");
			taxed = true;
		}

		protected internal virtual void computeNet()
		{
			if (taxed == true)
			{
			net = gross - tax;
            Console.WriteLine("\nYour net is:" + net.ToString("C0") + "\n");
			netted = true;
			}
			else
			{
			Console.WriteLine("\nYou must compute taxes before you can compute net.\n");
			}
		}

		protected internal virtual void computeNetperc()
		{
			if (!taxed)
			{
			Console.WriteLine("\nPlease compute taxes.\n");
			}
			else if (!netted)
			{
			Console.WriteLine("\nPlease compute net.\n");
			}
			else if (taxed && netted)
			{
			net_percent = (net / gross) * 100;
			Console.WriteLine("\nYour net percent is:" + net_percent + "%\n");
			netperc = true;
			}
		}

		protected internal virtual void displayEmployee()
		{
			if (taxed && netted && netperc)
			{
            Console.WriteLine("\nHours: " + hours);
			Console.WriteLine("Rate: " + rate);
			Console.WriteLine("Gross: " + gross.ToString("C0"));
			Console.WriteLine("Net: " + net.ToString("C0"));
			Console.WriteLine("Net%: " + net_percent + "%\n");
			}
			else if (!taxed)
			{
			Console.WriteLine("\nTaxes need to be computed.\n");
			}
			else if (!netted)
			{
			Console.WriteLine("\nNet gross needs to be calculated first.\n");
			}
			else if (!netperc)
			{
			Console.WriteLine("\nNet percent needs to be calculated first.\n");
			}
			else
			{
			Console.WriteLine("\nPerform the calculations first.\n");
			}
		}

		/// <returns> the id </returns>
		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}



	}





}