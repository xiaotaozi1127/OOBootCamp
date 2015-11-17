using OOBootCamp;
using Xunit;

namespace TestClass.ComparerFacts
{
    public class ComparerFacts
    {
        [Fact]
        public void should_get_equal_when_compare_two_lengths_if_they_are_equal()
        {            
            var lengthA = 1;
            var lengthB = 1;
            
            Assert.True(lengthA == lengthB);                
        }

        [Fact]
        public void should_get_unequal_when_compare_two_lengths_if_they_are_not_equal()
        {           
            var lengthA = 1;
            var lengthB = 2;
            
            Assert.False(lengthA == lengthB);
        }

        [Fact]
        public void should_get_equal_when_compare_two_lengths_with_same_unit_and_same_length_number()
        {           
            var lengthA = new Length(1, Unit.Meter);
            var lengthB = new Length(1, Unit.Meter);

            Assert.True(lengthA.Equals(lengthB));
        }

        [Fact]
        public void should_get_unequal_when_compare_two_lengths_with_same_unit_and_different_length_number()
        {
            var lengthA = new Length(2, Unit.Meter);
            var lengthB = new Length(1, Unit.Meter);

            Assert.False(lengthA.Equals(lengthB));
        }

        [Fact]
        public void should_return_equal_when_compare_one_meter_length_with_one_hundred_centimete_length()
        {
            var lengthA = new Length(1, Unit.Meter);
            var lengthB = new Length(100, Unit.CentiMeter);
            Assert.True(lengthA.Equals(lengthB));
        }

        [Fact]
        public void should_return_equal_when_compare_one_meter_length_with_one_thousand_millimeter_length()
        {
            var lengthA = new Length(1, Unit.Meter);
            var lengthB = new Length(1000, Unit.MilliMeter);

            Assert.True(lengthA.Equals(lengthB));
        }

        [Fact]
        public void should_get_equal_when_compare_one_centimeter_length_with_ten_millimeter_length()
        {
            var lengthA = new Length(1, Unit.CentiMeter);
            var lengthB = new Length(10, Unit.MilliMeter);
            Assert.True(lengthA.Equals(lengthB));
        }

        [Fact]
        public void should_get_unequal_when_compare_one_centimeter_length_with_one_hundred_millimeter_length()
        {
            var lengthA = new Length(1, Unit.CentiMeter);
            var lengthB = new Length(100, Unit.MilliMeter);
            Assert.False(lengthA.Equals(lengthB));
        }
    }
}
