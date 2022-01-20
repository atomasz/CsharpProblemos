using Problemos;

var random = new Random();
var randomLength = random.Next((int)(5 * Math.Pow(10, 1)));
var chars = "qwertyuioplkjhgfdsazxcvbnm";
var stringChars = new char[randomLength];

for (int i = 0; i < stringChars.Length; i++)
{
    stringChars[i] = chars[random.Next(chars.Length)];
}

var finalString = new String(stringChars);

var test = ShortestPalindromeResult.RandomMusings("aba");
Console.WriteLine(test);



Console.WriteLine($"Random string with length: {randomLength}, value: {finalString}");


var calcResult = Calculator.Calculate("- (3 + (4 + 5))");
var calcResult2 = Calculator.Calculate("(1+(4+5+2)-3)+(6+8)");

Console.WriteLine($"Calc result = {calcResult}, {calcResult2}");