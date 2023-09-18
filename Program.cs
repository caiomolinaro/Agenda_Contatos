//falta criar o editar contatos

using Lista_Contatos;

List<ContatosClass> listaContatos;

listaContatos = new List<ContatosClass>();

bool condicao = true;

do
{
    Console.WriteLine("Digite 1 para adicionar um novo contato, Digite 2 para visualizar todos os contatos, Digite 3 para sair");
    string opcao = Console.ReadLine();

    double? telefone = null;
    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite o Nome do contato:");
            string nome = Console.ReadLine();

            try
            {
                Console.WriteLine("Digite o Nº de telefone do contato:");
                telefone = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Digite um numero de telefone valido (formato: 111122222)");
                Console.WriteLine(ex.Message);
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Digite um numero de telefone valido (formato: 111122222)");
                Console.WriteLine(ex.Message);
                break;
            }
            Console.WriteLine("Digite o email do contato:");
            string email = Console.ReadLine();

            listaContatos.Add(new ContatosClass(nome, telefone, email));

            Console.Clear();
            Console.WriteLine("Contado adicionado com sucesso!!"); 
            break;

        case "2":            
            exibirContatos(listaContatos);

            Console.WriteLine("Deseja apagar algum contato? Digite S(im) ou N(ão)");
            string opcaoContato = Console.ReadLine().ToLower();

            if (opcaoContato == "s")
            {
                try
                {
                    Console.WriteLine("Digite o numero do contato que deseja apagar:");
                    int numContato = Convert.ToInt32(Console.ReadLine());
                    listaContatos.Remove(listaContatos[numContato]);
                    Console.Clear();
                    Console.WriteLine("Contato removido com sucesso");
                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Nº do contato não existe");
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Nº do contato não existe");
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Nº do contato não existe");
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            if (opcao == "n")
            {
                Console.Clear();
                break;
            }
            Console.Clear();
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

        Console.WriteLine($"Nº {listaContatos.IndexOf(listaC)} | Nome: {listaC.nome}, Telefone: {listaC.telefone}, email: {listaC.email}");
    }
}