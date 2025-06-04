using RectangleStruct;
namespace RectangeStruct.UnitTests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var rect = new Rectangle(2.5, 4.0);
            Assert.That(rect.Width, Is.EqualTo(2.5));
            Assert.That(rect.Height, Is.EqualTo(4.0));
        } 

        [TestCase(2.5, 4.0)]
        [TestCase(1.0, 1.0)]
        [TestCase(10.5, 7.3)]
        public void CorrectAreaPerimeter(double width, double height)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.Area, Is.EqualTo(width * height));
            Assert.That(rect.Perimeter, Is.EqualTo(2 * (width + height)));
        }

        [Test]
        public void ExpectedString()
        {
            var rect = new Rectangle(2.3451, 1.002);
            string expected = "Прямоугольник шириной 2,3451 см и высотой 1,002 см";
            Assert.That(rect.ToString(), Is.EqualTo(expected));
        }

        [TestCase(2.5, 4.0)]
        [TestCase(1.0, 1.0)]
        [TestCase(10.5, 7.3)]
        public void EqualsTwoRectangles(double w1, double h1)
        {
            var rect1 = new Rectangle(w1, h1);
            var rect2 = new Rectangle(w1, h1);
            var rect3 = new Rectangle(w1 + 0.0000005, h1 - 0.0000005); 

            Assert.That(rect1.Equals(rect2), Is.True);
            Assert.That(rect1.Equals(rect3), Is.False);

            var rectDifferent = new Rectangle(w1 + 0.01, h1);
            Assert.That(rect1.Equals(rectDifferent), Is.False);
        }

        [Test]
        public void EqualsWrongArgument()
        {
            var rect = new Rectangle(2, 3);
            object obj = "not a rectangle";

            Assert.That(() => rect.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeSameForEqualRectangles()
        {
            var r1 = new Rectangle(3.14, 2.71);
            var r2 = new Rectangle(3.14 + 1e-7, 2.71 - 1e-7);

            Assert.That(r1.GetHashCode(), Is.EqualTo(r2.GetHashCode()));

            var r3 = new Rectangle(3.15, 2.71);

            Assert.That(r1.GetHashCode(), Is.Not.EqualTo(r3.GetHashCode()));
        }

        [Test]
        public void ScaleOperatorMultipliesDimensions()
        {
            var rect = new Rectangle(2, 3);
            double scaleFactor = 2.5;

            var scaledRect = scaleFactor * rect;

            Assert.That(scaledRect.Width, Is.EqualTo(rect.Width * scaleFactor));
            Assert.That(scaledRect.Height, Is.EqualTo(rect.Height * scaleFactor));
        }

        [Test]
        public void ScaleOperatorNegativeOrZero()
        {
            var rect = new Rectangle(2, 3);

            Assert.That(() => -1 * rect, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => 0 * rect, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}