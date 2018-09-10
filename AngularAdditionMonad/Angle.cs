using System;

namespace AngularAdditionMonad
{
    public struct Angle
    {
        private readonly decimal degrees;

        private Angle(decimal degrees)
        {
            this.degrees = degrees % 360;
            if (this.degrees < 0)
                this.degrees += 360m;
        }

        public static Angle FromDegrees(decimal degrees) => 
            new Angle(degrees);

        public static Angle FromRadians(double radians) =>
            new Angle((decimal)((180D / Math.PI) * radians));

        public Angle Add(Angle other) =>
            new Angle(this.degrees + other.degrees);

        public readonly static Angle Identity = new Angle(0);

        public override bool Equals(object obj) =>
            obj is Angle angle
                ? angle.degrees == this.degrees
                : base.Equals(obj);

        public override int GetHashCode() =>
            this.degrees.GetHashCode();

        public static bool operator ==(Angle x, Angle y) =>
            x.Equals(y);

        public static bool operator !=(Angle x, Angle y) =>
            !x.Equals(y);
    }
}
