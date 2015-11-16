namespace OOBootCamp
{
    public enum Unit
    {
        Meter = 1000,
        CentiMeter = 10,
        MilliMeter = 1
    }

    public class Length
    {
        public Length(float number, Unit unit)
        {
            Number = number;
            Unit = unit;
        }
        public float Number { get; set; }
        public Unit Unit { get; set; }
        public float ToUniversalLength()
        {
            return (int)Unit * Number;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is Length == false) return false;
            return ToUniversalLength() ==  (obj as Length).ToUniversalLength();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
