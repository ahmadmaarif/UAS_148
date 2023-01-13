using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_148
{
    class Node
    {

        public int id_barang;
        public string nama_barang;
        public string jenis_barang;
        public int harga_barang;
        public Node next;
        public Node prev;
    }
    class list
    {

        Node START;

        public list()
        {
            START = null;
        }
        public void addNode()
        {
            int id_barang;
            string nama_barang;
            string jenis_barang;
            int harga_barang;

            Console.Write("Masukkan ID Barang : ");
            id_barang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Barang: ");
            nama_barang = Console.ReadLine();
            Console.Write("Masukan Jenis Barang: ");
            jenis_barang = Convert.ToString(Console.ReadLine());
            Console.Write("Masukkan Harga Barang: ");
            harga_barang = Convert.ToInt32(Console.ReadLine());

            Node newNode = new Node();
            newNode.id_barang = id_barang;
            newNode.nama_barang = nama_barang;
            newNode.jenis_barang = jenis_barang;
            newNode.harga_barang = harga_barang;

            if (START == null || id_barang == START.id_barang)
            {
                if ((START != null) && (id_barang == START.id_barang))
                {
                    Console.WriteLine("Tidak Diperolehkan Untuk Duplikasi");
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && id_barang >= current.id_barang;
                previous = current, current = current.next)
            {
                if (id_barang == current.id_barang)
                {
                    Console.WriteLine("Tidak Diperolehkan Untuk Duplikasi");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = current;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollkel, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (rollkel != current.harga_barang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void display()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("Data berdasarkan Harga Barang:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.id_barang + "" + currentNode.nama_barang + "" + currentNode.jenis_barang + " " + currentNode.harga_barang + "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            list dl = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("1. Menambahkan Data");
                    Console.WriteLine("2. Mencari Data");
                    Console.WriteLine("3. Menampilkan Data");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\npilihlah(1 - 4): ");
                    Console.WriteLine("================================");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                dl.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (dl.listEmpty() == true)
                                {
                                    Console.WriteLine("Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Masukkan Harga Barang: ");
                                int harga_barang = Convert.ToInt32(Console.ReadLine());
                                if (dl.search(harga_barang, ref prev, ref curr) == false)
                                    Console.WriteLine("Data tidak ada");
                                else
                                {
                                    Console.WriteLine("ID Barang: " + curr.id_barang);
                                    Console.WriteLine("Nama Barang: " + curr.nama_barang);
                                    Console.WriteLine("Jenis Barang: " + curr.jenis_barang);
                                    Console.WriteLine("Harga Barang: " + curr.harga_barang);
                                }
                            }
                            break;
                        case '3':
                            {
                                dl.display();
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Mohon lihat ulang");
                }
            }
        }
    }
}

//2. Saya memilih untuk menggunakan algoritma Double LinkedList saya rasa mudah dalam mengaplikasikan
//dan tentunya dirujuk pada soal  ini yang diminta untuk menambah data, ,mencari data,mengurutkan,dan menampilkan data yang didasari oleh id barang, nama barang, jenis barang, dan harga barang
//3. Yang saya pahami, array digunakan ketika user telah memiliki batasan pada data yang akan diinput sehingga dapat terkontrol,
// sedangkan Linked list berguna untuk menginput data yang tak terhingga.
//4. REAR & FRONT
//5.A. Siblingnya yaitu (41 & 74),(16 & 53),(46 & 55),(63 & 70), (62 & 64).
// B. Pembacaan data tersebut adalah InOrder ( dapat dibaca dengan urutan prioritas data pada sebelah kiri dari induk terlebih dahulu,
//  lalu dilanjut dengan data sebelah kanan dari induk, lalu data dari induk itu sendiri)


