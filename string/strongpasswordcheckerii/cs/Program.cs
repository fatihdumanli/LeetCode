//https://leetcode.com/problems/strong-password-checker-ii/

var password = "IloveLe3tcode!";
var result = StrongPasswordCheckerII(password);
Console.WriteLine(result);

bool StrongPasswordCheckerII(string password)
{
    var requirements = new bool[5];
    const int LENGTH = 0;
    const int LOWERCASE = 1;
    const int UPPERCASE = 2;
    const int DIGIT = 3;
    const int SPECIAL = 4;

    var specialCharacters = new HashSet<char>()
    {
        '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '"'  
    };

    if(password.Length < 8)
        return false;

    requirements[LENGTH] = true;

    char prevBuffer = '\0';

    for(int i = 0; i < password.Length; i++)
    {
        var asciiVal = password[i];

        if(asciiVal == prevBuffer)
            return false;

        prevBuffer = asciiVal;

        // At least 1 lowercase character
        if(asciiVal >= 'a' && asciiVal <= 'z')
        {
            requirements[LOWERCASE] = true;
            continue;
        }
        
        // At least 1 uppercase character
        if(asciiVal >= 'A' && asciiVal <= 'Z')
        {
            requirements[UPPERCASE] = true;
            continue;
        }

        // At least 1 special character
        if(specialCharacters.Contains(asciiVal))
        {
            requirements[SPECIAL] = true;
            continue;
        }

        // At least 1 digit
        if(asciiVal >= '0' && asciiVal <= '9')
        {
            requirements[DIGIT] = true;
            continue;
        }

    }

    return !requirements.Contains(false);
}