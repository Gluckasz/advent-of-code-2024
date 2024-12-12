namespace advent_of_code_2024
{
    internal class Day2Solution
    {
        private bool IsSafe(List<int> report)
        {
            bool isIncreasing = report[0] <= report[1];
            for (int i = 0; i < report.Count - 1; i++)
            {
                int diff = Math.Abs(report[i] - report[i + 1]);
                if (diff == 0 || diff > 3 || (isIncreasing && report[i] > report[i + 1]) || (!isIncreasing && report[i] < report[i + 1]))
                    return false;
            }
            return true;
        }
        private void SaveResult(int result1, int result2)
        {
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Output1.txt"), result1.ToString());
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Output2.txt"), result2.ToString());
        }
        public void Solution()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Day2", "Input.txt"));
            int safeReports = lines.Count(line =>
            {
                var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                return IsSafe(report);
            });

            int safeReportsWithToleration = lines.Count(line =>
            {
                var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafe(report))
                    return true;

                for (int i = 0; i < report.Count; i++)
                {
                    var modifiedReport = report.Where((_, index) => index != i).ToList();
                    if (IsSafe(modifiedReport))
                        return true;
                }

                return false;
            });

            SaveResult(safeReports, safeReportsWithToleration);
        }
    }
}
