using System;

namespace Start2GFT.Filmes
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilmes();
                        break;
                    case "3":
                        AtualizarFilmes();
                        break;
                    case "4":
                        ExcluirFilmes();
                        break;
                    case "5":
                        VisualizarFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Essa opção não existe!");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarFilmes()
            {
                Console.WriteLine("Filmes:");
			    var lista = repositorio.Lista();
			    if (lista.Count == 0)
			    {
				    Console.WriteLine("Nenhuma filme cadastrado.");
				    return;
			    }
			    foreach (var filme in lista)
		    	{
                    var excluido = filme.retornaExcluido();
				    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			    }
                Console.WriteLine();
            }

            private static void InserirFilmes()
            {
                Console.WriteLine("Inserir novo filme");
			    foreach (int i in Enum.GetValues(typeof(Genero)))
			    {
		    	    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
		        }
                Console.WriteLine();
			    Console.Write("Digite o gênero entre as opções acima: ");
			    int entradaGenero = int.Parse(Console.ReadLine());

			    Console.Write("Digite o Título do Filme: ");
			    string entradaTitulo = Console.ReadLine();

			    Console.Write("Digite o Ano do Filme: ");
			    int entradaAno = int.Parse(Console.ReadLine());

			    Console.Write("Digite a Descrição do Filme: ");
			    string entradaDescricao = Console.ReadLine();

			    Filme novoFilme = new Filme(id: repositorio.ProximoId(),
			    							genero: (Genero)entradaGenero,
			    							titulo: entradaTitulo,
			    							ano: entradaAno,
			    							descricao: entradaDescricao);

			    repositorio.Insere(novoFilme);
            }

            private static void AtualizarFilmes()
            {
                ListarFilmes();
                Console.WriteLine();
                Console.Write("Digite o id do Filme: ");
			    int indiceFilme = int.Parse(Console.ReadLine());
			    foreach (int i in Enum.GetValues(typeof(Genero)))
			    {
			    	Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			    }
                Console.WriteLine();
			    Console.Write("Digite o gênero entre as opções acima: ");
			    int entradaGenero = int.Parse(Console.ReadLine());

    			Console.Write("Digite o Título do Filme: ");
		    	string entradaTitulo = Console.ReadLine();

			    Console.Write("Digite o Ano de Início do Filme: ");
			    int entradaAno = int.Parse(Console.ReadLine());

			    Console.Write("Digite a Descrição do Filme: ");
			    string entradaDescricao = Console.ReadLine();

			    Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			    repositorio.Atualiza(indiceFilme, atualizaFilme);
            }

            private static void ExcluirFilmes()
            {
                ListarFilmes();
                Console.WriteLine();
                Console.Write("Digite o id do Filme: ");
			    int indiceFilme = int.Parse(Console.ReadLine());
			    repositorio.Exclui(indiceFilme);
            }

            private static void VisualizarFilmes()
            {
                ListarFilmes();
                Console.WriteLine();
                Console.Write("Digite o id do Filme: ");
			    int indiceFilme = int.Parse(Console.ReadLine());
			    var filme = repositorio.RetornaPorId(indiceFilme);
			    Console.WriteLine(filme);
            }

            private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Filmes a seu dispor!");
                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine("1 - Listar filmes: ");
                Console.WriteLine("2 - Inserir novo filme: ");
                Console.WriteLine("3 - Atualizar filme: ");
                Console.WriteLine("4 - Excluir filme: ");
                Console.WriteLine("5 - Visualizar filme: ");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();
                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        
    }
}
