using H3_Tests___Application.GUI.Interfaces;
using H3_Tests___Application.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.GUI.Views.Home
{
    internal class HomeView : IViewable
    {
        public IViewable Show()
        {
            ViewComponents.DisplayViewHeader("Hello world");
            Console.ReadKey();

            return null;
        }
    }
}
