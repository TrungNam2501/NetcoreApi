using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGnurt.DataAccess;
using ManGnurt.DataAccess.Class;
using ManGnurt.DataAccess.Struct;

namespace ManGnurt.Consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeerManager = new Employeer_Manager();

            //var result = employeerManager.Employeer_Insert("<asas>", "MR QUÂN", DateTime.Now);

            //switch (result)
            //{
            //    case (int)EmployeerManager_Status.THANH_CONG:
            //        Console.WriteLine("Thêm thành công!");

            //        break;

            //    case (int)EmployeerManager_Status.MA_NHAN_VIEN_KHONG_HOP_LE:
            //        Console.WriteLine("Mã nhân viên không hợp lê!");

            //        break;

            //    case (int)EmployeerManager_Status.TEN_KHONG_HOP_LE:
            //        Console.WriteLine("Tên nhân viên không hợp lê!");

            //        break;
            //}


            //var path = "C:\\Users\\tnamit\\Desktop\\Book1.xlsx";
            //var rs = employeerManager.Employeer_Insert_FromExcelFile(path);
            //Console.WriteLine(rs);


            //var bai6 = new Bai6_DateTime(); 
            //bai6.DateTimeDemo();

            // var function = new Function();
            // var result = function.Phep_Cong(5, 10);
            // Console.WriteLine(result);

            // var result2 = function.Phep_Cong(5.5, 10.5);
            // Console.WriteLine(result2);

            // var result3 = function.Phep_Cong("Hello ", "World!");
            //Console.WriteLine(result3);





            //var emp = new Employeer();
            //emp.EmployeerName = "Mr Quân1234";

            //var car = new Car();
            //car.CarName = "Xe Bus";

            //var function = new Function();

            //var result = function.Phep_Cong<int>(10, 10);
            //Console.WriteLine("Kết quả int: {0}", result);

            //var result2 = function.Phep_Cong<double>(10.5, 10.5);
            //Console.WriteLine("Kết quả double: {0}", result2);

            //var result3 = function.Phep_Cong<string>("Chuoi 1", "Chuoi 2");

            //Console.WriteLine("Kết quả string: {0}", result3);

            //var result4 = function.Phep_Cong<float>(10, 10);
            //Console.WriteLine("Kết quả float: {0}", result4);

            //var result5 = function.Function_DemoStruct<Employeer>(emp);
            //Console.WriteLine("Kết quả Function_DemoStruct: {0}", result5.EmployeerName);

            //var result6 = function.Function_DemoStruct<Car>(car);

            //Console.WriteLine("Kết quả Function_DemoStruct: {0}", result6.CarName);


            //var result7 = new DemoGeneric_WithClass<int>();
            //result7.ThuocTinh = 10;
            //Console.WriteLine("Kết quả DemoGeneric_WithClass: {0}", result7.ThuocTinh);


            //var result8 = new DemoGeneric_WithClass<string>();
            //result8.ThuocTinh = "BE_032025";
            //Console.WriteLine("Kết quả DemoGeneric_WithClass: {0}", result8.ThuocTinh);

            //var result9 = new DemoGeneric_WithClass<Person>();
            //result9.ThuocTinh = new Person
            //{
            //    PersonAddress = "Hà Nội",
            //    PersonName = "MR QUÂN",
            //    PersonPhone = "123"
            //};
            //Console.WriteLine("Kết quả DemoGeneric_WithClass PersonName: {0}", result9.ThuocTinh.PersonName);




            //Dictionary<string, string> _phoneBook = new Dictionary<string, string>()
            //{
            //{"Trump", "0123.456.789" },
            //{"Obama", "0987.654.321" },
            //{"Putin", "0135.246.789" }
            //};


            //Dictionary<int, string> _phoneBookInt = new Dictionary<int, string>()
            //{
            //{1, "0123.456.789" },
            //{2, "0987.654.321" },
            //{3, "0135.246.789" }
            //};


            //foreach (KeyValuePair<string, string> entry in _phoneBook)
            //{
            //    Console.WriteLine($" -> {entry.Key} : {entry.Value}");
            //}

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("BE_032025");
            //arrayList.Add(1.5);
            //arrayList.Add(true);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine("{0}", item);
            //}


            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("Key1", "Value1");
            //hashtable.Add("Key2", "Value2");
            //Console.WriteLine(hashtable["Key1"]);

            //SortedList mySL = new SortedList();
            //mySL.Add("Third", "!");
            //mySL.Add("Second", "World");
            //mySL.Add("First", "Hello");

            //Console.WriteLine(" Count: {0}", mySL.Count);
            //Console.WriteLine(" Capacity: {0}", mySL.Capacity);
            //Console.WriteLine(" get by Keys: {0}", mySL["First"]);


            //Console.WriteLine(" get by Index: ");
            //Console.WriteLine("\t-KEY-\t-VALUE-");
            //for (int i = 0; i < mySL.Count; i++)
            //{
            //    Console.WriteLine("\t{0}:\t{1}",
            //        mySL.GetKey(i),
            //        mySL.GetByIndex(i));
            //}

            //Stack myStack = new Stack();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("!");
            //Console.WriteLine("myStack");
            //Console.WriteLine("\tCount: {0}", myStack.Count);
            //Console.Write("\tValues:");
            //foreach (Object obj in myStack) Console.Write(" {0}", obj);


            //Queue myQ = new Queue();
            //myQ.Enqueue("Hello");
            //myQ.Enqueue("World");
            //myQ.Enqueue("!");
            //Console.WriteLine("myQ");
            //Console.WriteLine("\tCount: {0}", myQ.Count); Console.Write("\tValues:");

            //foreach (Object obj in myQ) Console.Write(" {0}", obj);






            //Lập trình hướng đối tượng OOP - Object Oriented Programming   

            //// đối tượng = new Class();
            //var xeBus  = new DataAccess.Class.MyCar();
            //    xeBus.Id = 1;
            //    xeBus.Brand = "Mercedes";
            //    xeBus.Model = "Sprinter";
            //    xeBus.Color = "White";
            //xeBus.Year = 2020;
            ////xeBus.Display();


            //var xeHoi = new DataAccess.Class.MyCar();
            //xeHoi.Id = 2;
            //xeHoi.Brand = "Toyota";
            //xeHoi.Model = "Camry";
            //xeHoi.Color = "Black";
            //xeHoi.Year = 2021;
            //xeHoi.Display();
            //var xeGanmay = new DataAccess.Class.MyCar();
            //    xeGanmay.Id = 3;
            //    xeGanmay.Brand = "Yamaha";
            //    xeGanmay.Model = "Exciter";
            //    xeGanmay.Color = "Red";
            //    xeGanmay.Year = 2019;  
            //    xeGanmay.Display();



            //Console.WriteLine("Thông tin xe bus:");
            //Console.WriteLine("Id: {0}", xeBus.Id);
            //Console.WriteLine("Brand: {0}", xeBus.Brand);
            //Console.WriteLine("Model: {0}", xeBus.Model);
            //Console.WriteLine("Color: {0}", xeBus.Color);
            //Console.WriteLine("Year: {0}", xeBus.Year);
            //var distance = 100;
            //var time = xeBus.Run(distance);
            //Console.WriteLine("Thời gian chạy {0} km: {1} giờ", distance, time);





            //var nhanVien = new Employeer_Partial();
            //nhanVien.DoWord();  
            //nhanVien.GoToLunch();

            //var conbo = new DataAccess.AbstractClass.Cow();
            //conbo.Name = "Bò sữa";
            //conbo.MakeSound();

            //var conchim = new DataAccess.AbstractClass.Bird();
            //conchim.Name = "Chim sẻ";
            //conchim.MakeSound();


            //var hinhvuong = new DataAccess.AbstractClass.HinhVuong(5);
            //Console.WriteLine("Diện tích hình vuông: {0}", hinhvuong.TinhDienTich());
            //Console.WriteLine("Chu vi hình vuông: {0}", hinhvuong.TinhChuVi());

            //var hinhchunhat = new DataAccess.AbstractClass.HinhChuNhat(4, 6);
            //Console.WriteLine("Diện tích hình chữ nhật: {0}", hinhchunhat.TinhDienTich());
            //Console.WriteLine("Chu vi hình chữ nhật: {0}", hinhchunhat.TinhChuVi());

            //var hinhbinhhanh = new DataAccess.AbstractClass.HinhBinhHanh(4, 6);
            //Console.WriteLine("Diện tích hình bình hành: {0}", hinhbinhhanh.TinhDienTich());
            //Console.WriteLine("Chu vi hình bình hành: {0}", hinhbinhhanh.TinhChuVi());

            //var hinhtron =new DataAccess.AbstractClass.HinhTron(5);
            //Console.WriteLine("Diện tích hình tròn: {0}", hinhtron.TinhDienTich());
            //Console.WriteLine("Chu vi hình tròn: {0}", hinhtron.TinhChuVi());


            //var person = new PersonClass();
            //Console.WriteLine("ID: {0} ", person.GetFullName());



            //var mayDell= new MayTinhDell();
            //mayDell.ChieuDai = 10;
            //mayDell.ChieuRong = 5;
            //mayDell.UpRam();


            //var mayLenovo = new MayTinhLenovo();
            //mayLenovo.ChieuDai = 8;
            //mayLenovo.ChieuRong = 4;
            //mayLenovo.UpRam();
            var a = 10;

            var myKey =System.Configuration.ConfigurationManager.AppSettings["MyKey"]??"";
               if (string.IsNullOrEmpty(myKey))
            {
                return;
            }
               if (a == Convert.ToInt32(myKey))
            {
                Console.WriteLine("a bằng MyKey");
            }

        }

    }
}
