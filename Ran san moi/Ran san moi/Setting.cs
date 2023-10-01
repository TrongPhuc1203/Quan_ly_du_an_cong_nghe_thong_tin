using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ran_san_moi
{
    class Settings
    {
        // Gáng Chiều rộng cho Con rắn và Thức ăn
        public static int Width { get; set; }
        // Gáng Chiều cao cho Con rắn và Thức ăn
        public static int Height { get; set; }
        // Hướng duy chuyển
        public static string directions;
        public Settings()
        {
            Width = 15;
            Height = 15;
            directions = "left";
        }
    }
}
