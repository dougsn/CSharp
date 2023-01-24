namespace AppModelo.Models
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno()
        {
            Id = Guid.NewGuid();
        }

    }
}
