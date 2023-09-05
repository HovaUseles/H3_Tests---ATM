using H3_Tests___Application.GUI.Interfaces;
using H3_Tests___Application.GUI.Utilities;
using H3_Tests___Application.GUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.GUI.Controllers
{
    internal static class HomeController
    {
        public static IViewable Index()
        {
            return new HomeView();
        }
    }
}
