using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal abstract class MyObject
  {
    protected float x, y;
    public Point DrawLocation
    {
      get
      {
        return new Point((int)x, (int)y);
      }
    }
    public Bitmap ObjImg = new Bitmap(1, 1);

  }
}
