using H3_Tests___Application.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.GUI.Views
{
    internal class ErrorView : IViewable
    {
        public string ErrorMessage { get; set; }
        public IViewable ReturnView { get; set; }

        public ErrorView(string errorMessage, IViewable returnView)
        {
            ErrorMessage = errorMessage;
            ReturnView = returnView;
        }

        public IViewable Show()
        {
            Console.Clear();
            Console.WriteLine(ErrorMessage);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return ReturnView;
        }
    }
}
