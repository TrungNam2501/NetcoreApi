using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    public class MyCar
    {
        //Thuộc tính
        // get lấy giá trị troing thuộc tính, set gán giá trị cho thuộc tính
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        //Phương thức khởi tạo tham số
        public MyCar(int id, string brand, string model , int year, string color)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
        }
        public MyCar() { }
        // phương thức hiển thị thông tin xe
        public void Display()
        {
            Console.WriteLine($@"Thông tin xe:
- ID: {Id}
- Brand: {Brand}
- Model: {Model}
- Year: {Year}
- Color: {Color}");
        }
        public int Run(int distance)
        {
            Console.WriteLine($"The car is running for {distance} kilometers.");
            return distance;
        }

    }
}
