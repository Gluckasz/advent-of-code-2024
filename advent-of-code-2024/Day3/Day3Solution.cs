using System.Text;
using System.Text.RegularExpressions;

namespace advent_of_code_2024
{
    internal class Day3Solution
    {
        public void Solution()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Day3", "Input.txt"));
            string pattern = @"mul\(\d{1,3},\d{1,3}\)$";
            string pattern2 = @"do\(\)$";
            string pattern3 = @"don\'t\(\)$";
            int result1 = 0;
            int result2 = 0;
            bool enabled = true;
            foreach (var line in lines)
            {
                var sb = new StringBuilder();
                foreach (var character in line)
                {

                    if (character == ')')
                    {
                        sb.Append(character);
                        string s = sb.ToString();
                        if (Regex.IsMatch(s, pattern))
                        {
                            int multiplicationValue = Convert.ToInt32(s.Substring(4, s.IndexOf(',') - 4))
                                * Convert.ToInt32(s.Substring(s.IndexOf(',') + 1, s.IndexOf(')') - s.IndexOf(',') - 1));
                            result1 += multiplicationValue;
                            if (enabled)
                                result2 += multiplicationValue;
                        }
                        else if (Regex.IsMatch(s, pattern2))
                        {
                            enabled = true;
                        }
                        else if (Regex.IsMatch(s, pattern3))
                        {
                            enabled = false;
                        }
                        else
                        {
                            sb = new StringBuilder();
                        }
                    }
                    else if (character == 'm' || character == 'd')
                    {
                        sb = new StringBuilder();
                    }
                    sb.Append(character);
                }
            }
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day3", "Output1.txt"), result1.ToString());
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day3", "Output2.txt"), result2.ToString());
        }
    }
}
