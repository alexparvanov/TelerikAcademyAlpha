using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Mia : Driver
    {
        private const string MiaDriverName = "Mia";

        public Mia()
            : base(MiaDriverName, GenderType.Female)
        {
        }
    }
}
