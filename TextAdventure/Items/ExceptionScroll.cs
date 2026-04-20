using System.Collections.Generic;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    public class ExceptionScroll : Item
    {


        public ExceptionScroll() : base("Execption-Schriftrolle")
        {

        }

        public override string[] Use(Room room)
        {
            return new string[]
            {
                "NullReferenceException",
                "StackOverflowException",
                "IndexOutOfRangeException",
                "InvalidOperationException",
                "ArgumentNullException",
                "DivideByZeroException",
                "OutOfMemoryException",
                "TimeoutException",
                "AccessViolationException",
                "NotImplementedException",
                "FormatException",
                "IOException",
                "UnauthorizedAccessException",
                "ArithmeticException",
                "KeyNotFoundException"
            };
        }
    }
}
