namespace Lista_Contatos
{
    public class ContatosClass
    {
        public ContatosClass(string nome, double? telefone, string email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }

        public string nome { get; set; }
        public double? telefone { get; set; }
        public string email {  get; set; }
    }
}
