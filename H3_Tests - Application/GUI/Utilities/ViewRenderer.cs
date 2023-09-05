using H3_Tests___Application.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.GUI.Utilities
{
    /// <summary>
    /// Displays views in the console.
    /// </summary>
    internal static class ViewRenderer
    {
        /// <summary>
        /// Renders views to console window. Can enter a view nest if one view returns another view
        /// </summary>
        /// <param name="viewable">The view to render</param>
        public static void RenderView(IViewable viewable)
        {
            // Loop views and display them until view nest returns null
            do
            {
                viewable = viewable.Show(); // returns a new view, null if view nest is complete
            } while (viewable != null);
        }
    }
}
