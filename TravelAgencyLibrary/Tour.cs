using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyLibrary
{
    public class Tour
    {
        public string Name;
        public readonly int Code;
        public string Places;
        public TypeOfMovement Transport;
        public TimeSpan Duration;
        public double Price;
        public DateTime Begin;
        public DateTime End;
        public string Description;

        public Tour(string name, int code, string places, TypeOfMovement transport, TimeSpan duration)
        {
            Name = name;
            Code = code;
            Places = places;
            Duration = duration;
            Transport = transport;
        }

        public override string ToString()
        {
            return $"{Name} {Code}";

        }

        public void PrintInfo()
        {
            Console.WriteLine(this);

            var transport = "";
            switch (Transport)
            {
                case TypeOfMovement.Plane:
                    transport = "самолёт";
                    break;
                case TypeOfMovement.Train:
                    transport = "поезд";
                    break;
                case TypeOfMovement.Car:
                    transport = "автомобиль";
                    break;
                case TypeOfMovement.SeaTransport:
                    transport = "морской транспорт";
                    break;
                case TypeOfMovement.RiverTransport:
                    transport = "речной транспорт";
                    break;
            }

            Console.WriteLine($"Список названий мест посещения: {Places}. Тип передвижения: {transport}. Продолжительность: {Duration.ToString("%d")} дней. Цена: {Price} руб. Дата начала: {Begin.ToShortDateString()}. Дата окончания тура: {End.ToShortDateString()}. Описание: {Description}");
        }
    }
}