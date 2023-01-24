using Abstract_Figuras.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Figuras.Entities {
    internal abstract class Shape {

        public Color color { get; set; }

        public Shape(Color color) {
            this.color = color;
        }

        public abstract double Area();

    }
}
