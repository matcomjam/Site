namespace CodeFirstDatabase
{
    public class Restriction
    {
        public int Id { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int MaximumMessages { get; set; }
        public int NumberOfNodes { get; set; }
        public int SizeOfMessages { get; set; }
    }
}