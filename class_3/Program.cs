Point point = new(1, 11);
point.ShowData();

Counter counter = new(0, 100);
counter.decrement();
counter.increment();
int getCurrent = counter.GetCurrent;
Console.WriteLine(getCurrent);

Fraction fraction1 = new(5, 10);
Fraction fraction2 = new(2, 6);
fraction1 = fraction2.Multiply(fraction1);
fraction1.Simplify();
fraction1.Show();

class Point
{
    int _x;
    int _y;

    public Point()
    {
        _x = 0;
        _y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X
    {
        get { return _x; }
        set
        {
            if (value < 10 && value > 0)
            {
                _x = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("value must be 0<x<10");
            }
        }
    }
    public int Y
    {
        get { return _y; }
        set
        {
            if (value < 20 && value > 10)
            {
                _y = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("value must be 10<y<20");
            }
        }
    }
    public void ShowData()
    {
        Console.WriteLine($"x:{_x}\ny:{_y}");
    }
}

class Counter
{
    int _min;
    int _max;
    int _currentValue;
    public Counter(int min, int max)
    {
        _min = min;
        _max = max;
        _currentValue = min;
    }

    public void increment()
    {
        if (_currentValue < _max)
            _currentValue++;
        else
        {
            Console.WriteLine("maximal qiymet aldi, sifirlandi");
            _currentValue = _min;
        }
    }

    public void decrement()
    {
        if (_currentValue > _min)
            _currentValue--;
        else
            Console.WriteLine("minimal qiymetdir, deyismedi");
    }

    public int GetCurrent { get { return _currentValue; } }
}

class Fraction
{
    int _numerator;
    int _denominator;
    public Fraction(int num, int don)
    {
        _numerator = num;
        if (don != 0)
        {
            _denominator = don;
        }
        else { throw new DivideByZeroException("Mexrec 0 ola bilmez"); }
    }

    public void Show()
    {
        if (_numerator == 0)
            Console.WriteLine(_numerator);
        else if (_denominator != 1)
        {
            Console.WriteLine(_numerator);
            Console.WriteLine("--");
            Console.WriteLine(_denominator);
        }
        else
            Console.WriteLine(_numerator);
    }

    public void Simplify()
    {
        int num = _denominator;
        do
        {
            if (_numerator % num == 0 && _numerator >= num)
            {
                _numerator = _numerator / num;
                _denominator = _denominator / num;
            }
            num--;
        } while (num != 0);
    }

    public Fraction Multiply(Fraction other)
    {
        _numerator = _numerator * other._numerator;
        _denominator = _denominator * other._denominator;
        return this;
    }

    public Fraction Add(Fraction other)
    {
        int mexrec = 0;
        int suret = 0;
        if (_denominator != other._denominator)
        {

            if (_denominator % other._denominator == 0)
            {
                mexrec = _denominator;
                suret = (mexrec / _denominator) * _numerator + (mexrec / other._denominator) * other._numerator;
            }
            else if (other._denominator % _denominator == 0)
            {
                mexrec = other._denominator;
                suret = (mexrec / _denominator) * _numerator + (mexrec / other._denominator) * other._numerator;
            }
            else
            {
                mexrec = _denominator * other._denominator;
                suret = _denominator * other._numerator + other._denominator * _numerator;
            }

        }
        else
        {
            suret = _numerator + other._numerator;
            mexrec = _denominator;
        }
        _numerator = suret;
        _denominator = mexrec;
        return this;
    }

    public Fraction Minus(Fraction other)
    {
        int mexrec = 0;
        int suret = 0;
        if (_denominator != other._denominator)
        {

            if (_denominator % other._denominator == 0)
            {
                mexrec = _denominator;
                suret = (mexrec / _denominator) * _numerator - (mexrec / other._denominator) * other._numerator;
            }
            else if (other._denominator % _denominator == 0)
            {
                mexrec = other._denominator;
                suret = (mexrec / _denominator) * _numerator - (mexrec / other._denominator) * other._numerator;
            }
            else
            {
                mexrec = _denominator * other._denominator;
                suret = _denominator * other._numerator - other._denominator * _numerator;
            }

        }
        else
        {
            suret = _numerator - other._numerator;
            mexrec = _denominator;
        }
        _numerator = suret;
        _denominator = mexrec;
        return this;
    }

    public Fraction Divide(Fraction other)
    {
        _numerator = other._numerator / _numerator;
        _denominator = other._denominator / _denominator;
        return this;
    }
}





































