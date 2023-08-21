using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal abstract class ChoosingPanel : MyObject
  {
    public int width, height;
    public List<Point> FiguresCoordinates;
  }
}
