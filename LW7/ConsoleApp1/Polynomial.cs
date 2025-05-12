using System;

namespace PolynomialClass
{
    public class Polynomial
    {
        private int a, b, c;

        public Polynomial(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Polynomial() : this(0, 0, 0) { }

        public int A
        {
            get => a;
            set => a = value;
        }

        public int B
        {
            get => b;
            set => b = value;
        }

        public int C
        {
            get => c;
            set => c = value;
        }

        public override string ToString() => $"Polynomial: {a}x + {b}y + {c}z";

        public int this[int index]
        {
            get => index switch
            {
                0 => a,
                1 => b,
                2 => c,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (index)
                {
                    case 0: a = value; 
                        break;
                    case 1: b = value; 
                        break;
                    case 2: c = value; 
                        break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2) =>
            new Polynomial(p1.a + p2.a, p1.b + p2.b, p1.c + p2.c);
        public static Polynomial operator -(Polynomial p1, Polynomial p2) =>
            new Polynomial(p1.a - p2.a, p1.b - p2.b, p1.c - p2.c);

        public static Polynomial operator *(Polynomial p, int k) =>
            new Polynomial(p.a * k, p.b * k, p.c * k);
        public static Polynomial operator /(Polynomial p, int k)
        {
            if (k == 0)
                throw new DivideByZeroException("Division by zero is not allowed");
            if (p.a % k != 0 || p.b % k != 0 || p.c % k != 0)
                throw new ArgumentException("Division would result in non-integer coefficients");
            return new Polynomial(p.a / k, p.b / k, p.c / k);
        }

        public static Polynomial operator ++(Polynomial p) =>
            new Polynomial(p.a + 1, p.b + 1, p.c + 1);
        public static Polynomial operator --(Polynomial p) =>
            new Polynomial(p.a - 1, p.b - 1, p.c - 1);

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.a == p2.a && p1.b == p2.b && p1.c == p2.c;
        }
        public static bool operator !=(Polynomial p1, Polynomial p2) => !(p1 == p2);

        public static bool operator true(Polynomial p) => p.a != 0 || p.b != 0 || p.c != 0;
        public static bool operator false(Polynomial p) => p.a == 0 && p.b == 0 && p.c == 0;

        public static explicit operator int(Polynomial p) => p.a;
        public static explicit operator Polynomial(int a) => new Polynomial(a, 0, 0);
    }
}