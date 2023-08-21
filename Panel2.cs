using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class Panel2 : ChoosingPanel
  {
    public Panel2(int width, int height)
    {
      this.width = width;
      this.height = height;
      Size size = new(319, 171);
      ObjImg = new Bitmap(Sprites.PlayerChoice2, size);
      x = (float)width / 2 - (float)ObjImg.Width / 2;
      y = (float)height / 2 - (float)ObjImg.Height / 2;
      FiguresCoordinates = new() { new Point((int)x + 39, (int)y + 25) , 
        new Point((int)x + 39 + 120, (int)y + 25) };
    }
  }
}
