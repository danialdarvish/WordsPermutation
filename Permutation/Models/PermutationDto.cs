namespace Permutation.Models
{
    public class PermutationDto
    {
        public string Text { get; set; }
        public byte Number { get; set; }
        public bool IsPersian { get; set; }
        public int AllCount { get; set; }
        public List<string> Words { get; set; } = new List<string>();
    }
}
