namespace School.Recursion
{
    public class Task4
    {
        public static bool IsPalindrome(string word)
        {
            word = word.Trim().ToLower();

            return IsPalindrome(word, 0 , word.Length - 1);
        }

        public static bool IsPalindrome(string word, int left, int right)
        {
            if (left >= right)
            {
                return true;
            }

            if (word[left] != word[right])
            {
                return false;
            }

            return IsPalindrome(word, ++left, --right);
        }
    }
}
