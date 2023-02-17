/*
Given a year, report if it is a leap year.
The tricky thing here is that a leap year in the Gregorian calendar occurs:
    on every year that is evenly divisible by 4
        except every year that is evenly divisible by 100
            unless the year is also evenly divisible by 400
            
The DateTime class in C# provides a built-in [IsLeapYear](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.isleapyear 
which you should pretend doesn't exist for the purposes of implementing this exercise.
*/

namespace Exercisim;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        return (year % 4) switch
        {
            0 when year % 100 == 0 && year % 400 == 0 => true,
            0 when year % 100 == 0 => false,
            0 when year % 100 != 0 => true,
            _ => false
        };
    }
}