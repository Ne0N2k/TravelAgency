using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyLibrary;
using System.IO;

namespace TravelAgencyUnitTest
{
    [TestClass]
    public class TourUnitTest
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var scandinavia = CreateTestCommodity();

            TimeSpan dur = new TimeSpan(10, 0, 0, 0);

            Assert.AreEqual("Скандинавия", scandinavia.Name);
            Assert.AreEqual(234687, scandinavia.Code);
            Assert.AreEqual("Швеция, Норвегия, Дания", scandinavia.Places);
            Assert.AreEqual(TypeOfMovement.SeaTransport, scandinavia.Transport);
            Assert.AreEqual(dur, scandinavia.Duration);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var scandinavia = CreateTestCommodity();
            Assert.AreEqual("Скандинавия 234687", scandinavia.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            TimeSpan dur = new TimeSpan(7, 0, 0, 0);

            var scandinavia = CreateTestCommodity();
            var europe = new Tour("Европа", 312567, "Франция, Бельгия, Германия, Италия", TypeOfMovement.Plane, dur);

            var consoleOut = new[]
            {
                "Скандинавия 234687",
                $"Список названий мест посещения: Швеция, Норвегия, Дания. Тип передвижения: морской транспорт. Продолжительность: 10 дней. Цена: 100000 руб. Дата начала: 12.02.2020. Дата окончания тура: 22.02.2020. Описание: Прекрасный тур по северным столицам.",
                "Европа 312567",
                $"Список названий мест посещения: Франция, Бельгия, Германия, Италия. Тип передвижения: самолёт. Продолжительность: 7 дней. Цена: 150000 руб. Дата начала: 20.02.2020. Дата окончания тура: 27.02.2020. Описание: Замечательный тур по красивейшим местам Европы."
            };

            scandinavia.Price = 100000;
            scandinavia.Begin = DateTime.Parse("12.02.2020");
            scandinavia.End = scandinavia.Begin.AddDays(scandinavia.Duration.Days);
            scandinavia.Description = "Прекрасный тур по северным столицам.";
            europe.Price = 150000;
            europe.Begin = DateTime.Parse("20.02.2020");
            europe.End = europe.Begin.AddDays(europe.Duration.Days);
            europe.Description = "Замечательный тур по красивейшим местам Европы.";

            TextWriter oldOut = Console.Out;
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            scandinavia.PrintInfo();
            europe.PrintInfo();

            Console.SetOut(oldOut);
            var outputArray = output.ToString().Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(4, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        private Tour CreateTestCommodity()
        {
            TimeSpan dur = new TimeSpan(10, 0, 0, 0);
            return new Tour("Скандинавия", 234687, "Швеция, Норвегия, Дания", TypeOfMovement.SeaTransport, dur);
        }
    }
}