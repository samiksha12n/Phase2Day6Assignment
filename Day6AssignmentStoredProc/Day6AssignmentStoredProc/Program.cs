using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Day6AssignmentStoredProc
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader reader;
        public static string conStr = "server=DESKTOP-OBBRFUM\\MSSQLSERVER01;database=Day6Assignment;trusted_connection=true;";

        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1.Insert into Products table\n2.Delete from Products table\n3.Update into Products table\n4.Select from Products Table based on PId\n5.Select all record from Producta table");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand
                                {
                                    CommandText = "usp_iProducts",
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                Console.WriteLine("Enter Product Id");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Product Name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter Product price");
                                float price = float.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Product quantity");
                                int qty = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Manufacturing date");
                                DateTime mfgdate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Expiry date");
                                DateTime expdate = DateTime.Parse(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@price", price);
                                cmd.Parameters.AddWithValue("@qty", qty);
                                cmd.Parameters.AddWithValue("@mfgdate", mfgdate);
                                cmd.Parameters.AddWithValue("@expdate", expdate);
                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("Record Inserted!!! ");
                                }
                            }

                            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand
                                {
                                    CommandText = "usp_dProducts",
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                Console.WriteLine("Enter Product Id");
                                int id = int.Parse(Console.ReadLine());

                                cmd.Parameters.AddWithValue("@id", id);

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("Record Deleted!!! ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!! " + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand
                                {
                                    CommandText = "usp_sProducts",
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                Console.WriteLine("Enter Product Id to update Product Details");
                                int id = int.Parse(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", id);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {

                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Enter Product Name");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Enter Product price");
                                        float price = float.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Product quantity");
                                        int qty = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Manufacturing date");
                                        DateTime mfgdate = DateTime.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Expiry date");
                                        DateTime expdate = DateTime.Parse(Console.ReadLine());
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@price", price);
                                        cmd.Parameters.AddWithValue("@qty", qty);
                                        cmd.Parameters.AddWithValue("@mfgdate", mfgdate);
                                        cmd.Parameters.AddWithValue("@expdate", expdate);
                                        con.Open();
                                        int noe = cmd.ExecuteNonQuery();
                                        if (noe > 0)
                                        {
                                            Console.WriteLine("Record Updated!!! ");
                                        }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine($"No Such Product {id} exist");
                                }

                            }
                            
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!! " + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand
                                {
                                    CommandText = "usp_sProducts",
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                Console.WriteLine("Enter Product Id to find out Product Details");
                                int id = int.Parse(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", id);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    Console.WriteLine("Record Found Details as follows \n");
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Product ID: \t" + reader["PId"]);
                                        Console.WriteLine("Product Name: \t" + reader["PName"]);
                                        Console.WriteLine("Product Price: \t" + reader["Price"]);
                                        Console.WriteLine("Product Quantity: \t" + reader["Quantity"]);
                                        Console.WriteLine("Product Manufacturing date\t" + reader["MfgDate"]);
                                        Console.WriteLine("Product Exp Date:\t" + reader["Expdate"]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No Such Product {id} exist");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!! " + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 5:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "select * from Products"

                                };
                                con.Open();
                                reader = cmd.ExecuteReader();
                                Console.WriteLine("ID \t Product Name \t Price \t Quantity\t Mfg Date\t Exp Date");
                                while (reader.Read())
                                {
                                    Console.Write(reader[0] + "\t ");
                                    Console.Write(reader[1] + "\t \t");
                                    Console.Write(reader[2] + "\t \t");
                                    Console.Write(reader[3] + "\t \t");
                                    Console.Write(reader[4] + "\t\t");
                                    Console.Write(reader[5] + "\t\t");
                                    Console.WriteLine("\n");

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }

                }
                Console.WriteLine("Do you wanna continue press ....y");
                choice = Console.ReadLine();
            } while (choice == "y");
        }
    }
}
