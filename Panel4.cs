using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class Panel4 : ChoosingPanel
  {
    public Panel4(int width, int height)
    {
      this.width = width;
      this.height = height;
      Size size = new(559, 171);
      ObjImg = new Bitmap(Sprites.PlayerChoice4, size);
      x = (float)width / 2 - (float)ObjImg.Width/2;
      y = (float)height / 2 - (float)ObjImg.Height/2;
      FiguresCoordinates = new()
      {
        new Point((int)x + 39, (int)y + 25) ,
        new Point((int)x + 39 + 120, (int)y + 25),
        new Point((int)x + 39 + 240, (int)y + 25),
        new Point((int)x + 39 + 360, (int)y + 25),
      };
    }
  }
}
