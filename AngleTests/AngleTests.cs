using AngularAdditionMonad;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Tests
{
    public class AngleTests
    {
        // ToDo
        //public static Gen<Angle> AngleHelper()
        //{

        //}

        [Property(QuietOnSuccess = true)]
        public void AddIsAssociative(Angle x, Angle y, Angle z)
        {
            Assert.Equal(
                x.Add(y).Add(z),
                x.Add(y.Add(z)));
        }

        [Property(QuietOnSuccess = true)]
        public void AddHasIdentity(Angle x)
        {
            Assert.Equal(x, Angle.Identity.Add(x));
            Assert.Equal(x, x.Add(Angle.Identity));
        }
    }
}
