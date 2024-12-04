// Screen Sound

string MensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
string LogoDoScreenSound = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";//fsymbols.com/pt/geradores

//List<string> ListaDasBandas = new List<string> { "U2", "The Beatles", "Eva" };

Dictionary<string,List<int>> BandasRegistradas = new Dictionary<string,List<int>>();
BandasRegistradas.Add("Linkin Park", new List<int>{ 10, 8, 6 });
BandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogoDoProjeto() // void é uma função na qual nao espera-se um retorno.
{
    Console.WriteLine(LogoDoScreenSound);//Console.WriteLine é para se exibir o conteúdo, como se fosse o print.
    Console.WriteLine(MensagemDeBoasVindas);
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos+"\n");

}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda."); // O \n é para pular uma linha
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a media de uma banda.");
    Console.WriteLine("Digite 0 para sair");

    Console.WriteLine("\n Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!; // Para digitar a opção (Como se fosse o input) / oSinal de exclamação diz que nao é aceito valor nulo.
    int OpcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); // Parse converte o tipo de informação

    switch (OpcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarTodasAsBandas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaDeUmaBanda();
            break;
        case 0:
            Console.WriteLine("\nVoce escolheu a opção " + OpcaoEscolhidaNumerica+" Até mais! :)");
            break;
        default:
            Console.WriteLine("\nOpção inválida");
            break;
    }

    void RegistrarBanda()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Registro de bandas");
        
        Console.Write("\nDigite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;
        //ListaDasBandas.Add(nomeDaBanda);
        BandasRegistradas.Add(nomeDaBanda,new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirLogoDoProjeto();
        ExibirOpcoesDoMenu();
    };

    void MostrarTodasAsBandas()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Exibindo todas as bandas registradas!");

        //for (int i = 0; i < BandasRegistradas.Count; i++)
        //{
        //    Console.WriteLine($"Banda: {BandasRegistradas[i]}");
        //}

        //foreach (string banda in ListaDasBandas)
        foreach (string banda in BandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nPressione uma tecla para voltar ao menu principal!");
        Console.ReadKey();
        Console.Clear();
        ExibirLogoDoProjeto();
        ExibirOpcoesDoMenu();
    }

    void AvaliarUmaBanda()
    {
        //Digite qual banda deseja avaliar
        // Se existir banda, atribua a nota
        //se não, volte ao menu principal

        Console.Clear();
        ExibirTituloDaOpcao("Avaliar Banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que deseja atribuir a banda{nomeDaBanda}?  ");
            int nota = int.Parse(Console.ReadLine()!);
            BandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirLogoDoProjeto();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para retornar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirLogoDoProjeto();
            ExibirOpcoesDoMenu();
        }


    }
    void ExibirMediaDeUmaBanda()
    {
        //Digite a banda que deseja exibir a media
        //Se existir a banda calcular a media
        //Exibir a media da banda na tela
        
        Console.Clear();
        ExibirTituloDaOpcao("Exibir media de uma banda.");
        
        Console.Write("Digite a banda que deseja saber a média: ");
        string nomeBanda = Console.ReadLine()!;

        if (BandasRegistradas.ContainsKey(nomeBanda))
        {
            List<int> notasDaBanda = BandasRegistradas[nomeBanda];
            Console.WriteLine($"\nA média da banda{nomeBanda} é {notasDaBanda.Average()}!");
            Console.WriteLine("Digite uma tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirLogoDoProjeto();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"\n A banda {nomeBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirLogoDoProjeto();
            ExibirOpcoesDoMenu();
        }
    }
}

ExibirLogoDoProjeto();
ExibirOpcoesDoMenu();