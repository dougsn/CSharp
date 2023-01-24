using Abstract_Figuras.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Figuras.Entities {
    internal class Circle : Shape {

        public double Raius { get; set; }

        public Circle(Color color, double raius) : base(color) {
            this.Raius = raius;
        }

        public override double Area() {
            return Math.PI * Raius * Raius;
        }
    }
}
