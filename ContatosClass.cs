namespace Lista_Contatos
{
    public class ContatosClass
    {
        public ContatosClass(string nome, int telefone, string email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }

        public string nome { get; set; }
        public int telefone { get; set; }
        public string email {  get; set; }
    }
}
