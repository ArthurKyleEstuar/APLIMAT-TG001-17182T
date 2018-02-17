using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs
{
    public class Moveable
    {
        public Vector3 Position;
        public Vector3 Velocity;

        public Moveable()
        {
            this.Position = new Vector3();
            this.Velocity = new Vector3();
        }
    }
}
