using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_DatabaseProject
{
    internal class Program9
    {
        static void Main(string[] args)
        {
            // Ado.net = C#'ta sql yapılarının kullanılabilmesine olanak sağlayan çerçeve.

            Console.WriteLine("***** C# Veri Tabanlı Ürün-Kategori Bilgi Gistemi *****");
            Console.WriteLine();
            Console.WriteLine();

            string tableNumber;
            Console.WriteLine("--------------------------");
            Console.WriteLine("1-Kategoriler");
            Console.WriteLine("2-Ürünler");
            Console.WriteLine("3-Siparişler");
            Console.WriteLine("4- Çıkış Yap");


            Console.Write("Lütfen getirmek istediğiniz tablo numarasını giriniz: ");
            tableNumber = Console.ReadLine();
            Console.WriteLine("--------------------------");

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S85SQS0\\SQLEXPRESS;initial catalog=EgitimKampiDb; integrated security=true");
            connection.Open();

            SqlCommand command = new SqlCommand("Select * From TblCategory", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);  // C#'taki kodlar ile Sql tarafı arasında köprü görevi görür.

            DataTable dataTable = new DataTable(); // datatable = ramde bir alan tutmaya yarar.

            adapter.Fill(dataTable); // ramde tutulan alanı adapter ile doldurur.

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine();
            }

            connection.Close();

            Console.Read();
        }
    }
}
