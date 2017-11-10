using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public override bool Equals(object obj)
        {
            bool value = false;

            if(obj is Universitario && this == (Universitario)obj)
            {
                value = true;
            }

            return value; 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO NÚMERO: " + this.legajo);
            return sb.ToString();
        }

        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            bool value = false;

            if (!object.ReferenceEquals(pg1, null) && !object.ReferenceEquals(pg2, null))
            {
                if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    value = true;
                }
            }

            return value;
        }

        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        public Universitario() : base()
        {
            
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
