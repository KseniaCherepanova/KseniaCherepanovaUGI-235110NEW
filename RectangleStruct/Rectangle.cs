using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleStruct
{
    public struct Rectangle
    {
        double width;
        public double Width {
            get => width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Width), "Ширина должна быть положительным числом");
                width = value;
            }
        }

        double height;  
        public double Height {
            get => height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Height), "Высота должна быть положительным числом");
                height = value;
            }
        }

        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);

        public Rectangle(double width, double height) : this()
        {
            Width = width;
            Height = height;

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Ширина должна быть положительным числом");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Высота должна быть положительным числом");
        }

        public override string ToString() => $"Прямоугольник шириной {Width} см и высотой {Height} см";

        public override bool Equals(object obj)
        {
            if (obj is Rectangle rect)
                return Equals(rect);
            else
                throw new ArgumentException("Объект не является прямоугольником", nameof(obj));
        }

        public bool Equals(Rectangle other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override int GetHashCode()
        {
            int hashWidth = Math.Round(Width, 4).GetHashCode();
            int hashHeight = Math.Round(Height, 4).GetHashCode();
            int hash = 17;
            hash = hash * 31 + hashWidth;
            hash = hash * 31 + hashHeight;
            return hash;
        }

        public static Rectangle operator *(double scale, Rectangle rect)
        {
            if (scale <= 0)
                throw new ArgumentOutOfRangeException(nameof(scale), "Коэффициент масштабирования должен быть положительным");
            return new Rectangle(rect.Width * scale, rect.Height * scale);
        }

        public static Rectangle operator *(Rectangle rect, double scale) => scale * rect;

    }
}