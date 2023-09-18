//falta editar contatos

using Lista_Contatos;

List<ContatosClass> listaContatos;

listaContatos = new List<ContatosClass>();

bool condicao = true;

do
{
    Console.WriteLine("Digite 1 para adicionar um novo contato, Digite 2 para visualizar todos os contatos, Digite 3 para sair");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite o nome:");
            string nome = Console.ReadLine();

            try
            {
                Console.WriteLine("Digite o telefone:");
                int telefone = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite um numero de telefone valido (formato: 111122222)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite um numero de telefone valido (formato: 111122222)");
            }

            Console.WriteLine("Digite o email:");
            string email = Console.ReadLine();

            listaContatos.Add(new ContatosClass(nome, telefone, email));

            Console.Clear();
            Console.WriteLine("Contado adicionado com sucesso!!"); 
            break;

        case "2":            
            exibirContatos(listaContatos);

            Console.WriteLine("Deseja apagar algum contato? Digite S ou N");
            string opcaoContato = Console.ReadLine().ToLower();

            if (opcaoContato == "s")
            {
                try
                {
                    Console.WriteLine("Digite o numero do contato que deseja apagar:");
                    int numContato = Convert.ToInt32(Console.ReadLine());
                    listaContatos.Remove(listaContatos[numContato]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Clear();
                Console.WriteLine("Contato removido com sucesso");
                break;
            }
            else
                break;

        case "3":
            condicao = false;
            break;

        default:
            Console.WriteLine("Digitou algo errado");
            break;
    }
} while(condicao == true);

static void exibirContatos(List<ContatosClass> listaContatos)
{
    listaContatos.Sort(delegate (ContatosClass x, ContatosClass y)
    {
        if (x.nome == null && y.nome == null) return 0;
        else if (x.nome == null) return -1;
        else if (y.nome == null) return 1;
        else return x.nome.CompareTo(y.nome);
    });
    foreach (var listaC in listaContatos)
    {

        Console.WriteLine($"Nº {listaContatos.IndexOf(listaC)} Nome: {listaC.nome}, Telefone: {listaC.telefone}, email: {listaC.email}");
    }
}