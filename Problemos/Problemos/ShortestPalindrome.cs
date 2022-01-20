namespace Problemos;

public static class ShortestPalindromeResult
{
    public static string RandomMusings(string s)
    {
        if (string.IsNullOrWhiteSpace(s) || s.Length == 1)
            return s;
        
        var originalStringLength = s.Length;
        var maxLengthPally = originalStringLength * 2;
        var result = new char?[maxLengthPally];

        if (result == null)
            return s;

        //prepop
        for (var i = 0; i < s.Length; i++)
        {
            result[maxLengthPally - i - 1] = s[originalStringLength - i - 1];
        }

        var wow = result[(originalStringLength)..maxLengthPally];
        var isPally = CheckIsPaladrome(wow);

        if (isPally)
            return new string(Array.ConvertAll(wow, x => x ?? char.MinValue)) ?? string.Empty;

        for (var i = 0; i < originalStringLength; i++)
        {
            // Shift non null values
            char? next = result[originalStringLength - 1];
            var inner = 0;
            while (next != null)
            {
                var current = next;
                inner++;
                next = result[originalStringLength - 1 - inner];
                result[originalStringLength - 1 - inner] = current;
                
            }
            result[originalStringLength - 1] = result[maxLengthPally - i - 1];
            var potentialResult = result[(originalStringLength - i - 1)..maxLengthPally];
            isPally = CheckIsPaladrome(potentialResult);
            if (isPally)
                return new string(Array.ConvertAll(potentialResult, x => x ?? char.MinValue)) ?? string.Empty;

        }

        return new string(Array.ConvertAll(result, x => x ?? char.MinValue)) ?? string.Empty;
    }

    private static bool CheckIsPaladrome(char?[] val)
    {
        if (val == null || val.Length == 0) return true;

        var lengthy = val.Length;
        var halfWay = lengthy / 2;

        var pally = true;
        for (var i = 0; i < halfWay; i++)
        {
            if (val[i] == val[lengthy - i - 1])
                continue;

            return false;
        }

        return pally;
    }


}
