using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class LetiSpaghetti : Driver
    {
        private const string LetiSpaghettiDriverName = "Leti Spaghetti";

        public LetiSpaghetti()
            : base(LetiSpaghettiDriverName, GenderType.Female)
        {
        }
    }
}
