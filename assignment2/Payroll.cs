using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
namespace assignment2
{


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static assignment1.Employee.sc;

	/// 
	/// <summary>
	/// @author ztmvf2
	/// </summary>
	[Serializable]
	public class Payroll
	{
		internal int counter = 0;
		internal int shenanigans;
		internal int derp = -1;
		internal bool alreadyExecuted = false;
		List<Employee> earray = new List<Employee>();

		public static void Main(string[] args)
		{
		Payroll pr = new Payroll();
		pr.menu();
		}

		public virtual void menu()
		{
		Console.WriteLine("\n1. Populate Employees \n2. Select Employee \n3. Save Employees \n4. Load Employees \n5. Exit ");
		int d = Convert.ToInt32(Console.ReadLine());
            switch (d)
				{
					case (1):
					{
						//Populate
						if (!alreadyExecuted)
						{
						populate();
						menu();
						}
							else
							{
							Console.WriteLine("\nEmployees already populated, would you like to add to the existing employees? (Y) or (N)\n");
							string ch = Convert.ToString(Console.ReadLine());
                            if (ch.Equals("y", StringComparison.CurrentCultureIgnoreCase))
								{
								//shenanigans = earray.size();
								//counter = earray.size();
								populate();
								menu();
								}
								else
								{
								menu();
								}
							}
						break;
					}
					case 2:
					{
						//Select
						//select();
						pickEmp();
						break;
					}
					case 3:
					{
					//Save
						if (!alreadyExecuted)
						{
						Console.WriteLine("\nThere is nothing to save.\n");
						menu();
						}
						else
						{
                            try
                            {
                                if (alreadyExecuted)
                                {
                                    XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                                    //FileStream writer = new FileStream("payroll.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    TextWriter writer = new StreamWriter("payroll.xml");
                                    
                                    serializer.Serialize(writer, earray);
                                    writer.Flush();
                                    writer.Close();
                                    alreadyExecuted = true;
                                }
                                else
                                {
                                    Console.WriteLine("There are no accounts to save!");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.InnerException);
                            }

                        }

						break;
					}
					case 4:
					{
                        //Load 
                        try
                        {
                            XmlSerializer deserializer = new XmlSerializer(typeof(List<Employee>));
                            //FileStream rereader = new FileStream("bank.xml", FileMode.Open, FileAccess.ReadWrite);
                            StreamReader sr = new StreamReader("payroll.xml");
                            earray = (List<Employee>)deserializer.Deserialize(sr);
                            sr.Close();
                            alreadyExecuted = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            menu();
						}
						
						loadedmenu();
						break;
					}
					case 5:
					{
						Environment.Exit(0);
					}
						goto default;
					default:
					{
						Console.WriteLine("\nEnter a number that corresponds to the menu.\n");
						menu();
					}
				break;
				}
		}
		public virtual void populate()
		{
				for (int i = counter; i <= earray.Count; i++)
				{
						Console.WriteLine("\nPlease enter (C)Commission, (S)Salary, (H)Hourly, or (D) to quit: ");

						string input = Convert.ToString(Console.ReadLine());


                if (input.Equals("C", StringComparison.CurrentCultureIgnoreCase))
				{
								Console.WriteLine("Enter your ID#:");
								int id = Convert.ToInt32(Console.ReadLine());
                                earray.Insert(i, new CommissionEmployee());
								//System.out.println("\nYour ID# is: " + id + "\n");
								earray[i].Id = id;
								earray[i].computeGross();

								counter++;

				}
							else if (input.Equals("S", StringComparison.CurrentCultureIgnoreCase))
							{
								Console.WriteLine("Enter your ID#:");
								int id = Convert.ToInt32(Console.ReadLine());
                                earray.Insert(i, new SalaryEmployee());
								//System.out.println("\nYour ID# is: " + i + "\n");
								earray[i].Id = id;
								earray[i].computeGross();
								counter++;

							}
							else if (input.Equals("H", StringComparison.CurrentCultureIgnoreCase))
							{
								Console.WriteLine("Enter your ID#:");
								int id = Convert.ToInt32(Console.ReadLine());

                                earray.Insert(i, new HourlyEmployee());
								//System.out.println("\nYour ID# is: " + i +"\n");
								earray[i].Id = id;
								earray[i].computeGross();
								counter++;
							}
							else if (input.Equals("D", StringComparison.CurrentCultureIgnoreCase))
							{
							alreadyExecuted = true;
							menu();
							}
							else if (!"H".Equals(input, StringComparison.CurrentCultureIgnoreCase) || !"S".Equals(input, StringComparison.CurrentCultureIgnoreCase) || !"C".Equals(input, StringComparison.CurrentCultureIgnoreCase) || !"D".Equals(input, StringComparison.CurrentCultureIgnoreCase))
							{
							Console.WriteLine("Enter a letter that corresponds to the options.");
							i--;
							}
				}
		}
		//public virtual void select()
		//{
		//		Console.WriteLine("\nPlease enter your ID#: ");
		//		int id = Convert.ToInt32(Console.ReadLine());

  //                  if (id > 0 && earray.Count >= id)
		//			{
		//				Console.WriteLine("\nThat ID does not exist.\n");
		//				menu();
		//			}
		//			else
		//			{
                
		//				earray[id];

		//				shenanigans = id;

		//				topmenu();
		//			}

		//}
		public virtual void topmenu()
		{
				Console.WriteLine("\n1) Calculate Gross Pay\n2) Calculate Tax\n3) Calculate Net Pay\n4) Calculate Net Percent\n5) Display Employee\n6) Exit ");
				int @in = Convert.ToInt32(Console.ReadLine());

                    switch (@in)
					{
					case 1:
					earray[derp].dispGross();
					topmenu();
					break;
					case 2:
					earray[derp].computeTax();
					topmenu();
					break;
					case 3:
					earray[derp].computeNet();
					topmenu();
					break;
					case 4:
					earray[derp].computeNetperc();
					topmenu();
					break;
					case 5:
					earray[derp].displayEmployee();
					topmenu();
					break;
					case 6:
					menu();
					break;

					default:
					Console.WriteLine("\nEnter a number that corelates to the menu.\n");
				break;
					}
		}
		public virtual void loadedmenu()
		{
				Console.WriteLine("\nWould you like to add accounts to this file? (Y) or (N)\n");
				string ch = Convert.ToString(Console.ReadLine());
            counter = earray.Count;
				shenanigans = earray.Count;
					if (ch.Equals("y", StringComparison.CurrentCultureIgnoreCase))
					{
						populate();
					}
					else if (ch.Equals("n", StringComparison.CurrentCultureIgnoreCase))
					{
						menu();
					}
					else
					{
						Console.WriteLine("Enter a proper input.");
					}


		}
		public virtual void pickEmp()
		{


			Console.WriteLine("Enter your ID#:");
			int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < earray.Count; i++)
			{

				if (earray[i].Id == id)
				{
				derp = i;
				topmenu();
				}
	//            else
	//            {
	//            System.out.println("Your ID was not found.");
	//            }

			}
			if (derp == -1)
			{
			Console.WriteLine("ID is not found.");
			menu();
			}
			menu();
		}

	}


}