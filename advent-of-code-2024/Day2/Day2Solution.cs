namespace advent_of_code_2024.Day1
{
    internal class Day2Solution
    {
        private List<int> leftList = new();
        private List<int> rightList = new();

        private void ReadData()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Input.txt"));
            foreach (string line in lines)
            {
                string[] lineSplit = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                leftList.Add(Convert.ToInt32(lineSplit[0]));
                rightList.Add(Convert.ToInt32(lineSplit[1]));
            }
        }

        private void SaveResult(int result1, int result2)
        {
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Output1.txt"), result1.ToString());
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Output2.txt"), result2.ToString());
        }
        public void Solution()
        {
            ReadData();
            leftList.Sort();
            rightList.Sort();
            int sumOfDifferences = leftList.Zip(rightList, (a, b) => Math.Abs(a - b)).Sum();
            int similarityScore = leftList.Sum(left => left * rightList.Count(right => right == left));
            SaveResult(sumOfDifferences, similarityScore);
        }
    }
}
