namespace Permutation.Models
{
    public class PermutationGenerator
    {
        public static List<string> GeneratePermutationsWithRepetition(string input, int length)
        {
            List<string> permutations = new List<string>();
            GeneratePermutationsHelper(input.ToCharArray(), new char[length], 0, permutations);

            return permutations;
        }

        private static void GeneratePermutationsHelper(char[] input, char[] output, int currentIndex, List<string> permutations)
        {
            if (currentIndex == output.Length)
            {
                permutations.Add(new string(output));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                output[currentIndex] = input[i];
                GeneratePermutationsHelper(input, output, currentIndex + 1, permutations);
            }
        }
    }
}
