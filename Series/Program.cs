using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeRepositorio repfilme = new FilmeRepositorio();
		static string opcaoInicial { get; set; }

        static void Main(string[] args)
        {
			opcaoInicial = ObterOpcaoInicial();
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
					case "V":
					    opcaoInicial = ObterOpcaoInicial();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			if(opcaoInicial == "1")
			{
				repositorio.Exclui(indiceSerie);
			}
			else if(opcaoInicial == "2")
			{
				repfilme.Exclui(indiceSerie);
			}
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			if(opcaoInicial == "1")
			{
				var serie = repositorio.RetornaPorId(indiceSerie);
				Console.WriteLine(serie);
			}
			else if(opcaoInicial == "2")
			{

				var filme = repfilme.RetornaPorId(indiceSerie);
				Console.WriteLine(filme);
			}

		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a idade recomendada: ");
			int entradaIdade = int.Parse(Console.ReadLine());

			Console.Write("Digite o ator principal: ");
			string entradaAtor = Console.ReadLine();

			if (opcaoInicial == "1")
			{
				Serie atualizaSerie = new Serie(id: indiceSerie,
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											idade: entradaIdade,
											ator: entradaAtor,
											descricao: entradaDescricao);

				repositorio.Atualiza(indiceSerie, atualizaSerie);
			}
			else if (opcaoInicial == "2")
			{
				Filme atualizaSerie = new Filme(id: indiceSerie,
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											idade: entradaIdade,
											ator: entradaAtor,
											descricao: entradaDescricao);

				repfilme.Atualiza(indiceSerie, atualizaSerie);
			}
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar");

			if(opcaoInicial == "1")
			{
				var lista = repositorio.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("");
					Console.WriteLine("Cadastro de serie Inexistente!");
					return;
				}

				foreach (var serie in lista)
				{
					var excluido = serie.retornaExcluido();
					
					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
			}
			else if(opcaoInicial == "2")
			{
				var listafilme = repfilme.Lista();

				if (listafilme.Count == 0)
				{
					Console.WriteLine("Cadastro de filme Inexistente!");
					return;
				}

				foreach (var serie in listafilme)
				{
					var excluido = serie.retornaExcluido();
					
					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Novo Cadastro:");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a idade recomendada: ");
			int entradaIdade = int.Parse(Console.ReadLine());

			Console.Write("Digite o ator principal: ");
			string entradaAtor = Console.ReadLine();

			if (opcaoInicial == "1")
			{
				Serie novaSerie = new Serie(id: repositorio.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											idade: entradaIdade,
											ator: entradaAtor,
											descricao: entradaDescricao);

				repositorio.Insere(novaSerie);
			}
			else if (opcaoInicial == "2")
			{
				Filme novoFilme = new Filme(id: repfilme.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											idade: entradaIdade,
											ator: entradaAtor,
											descricao: entradaDescricao);

				repfilme.Insere(novoFilme);
			}
		}

		private static string ObterOpcaoInicial()
		{
			Console.WriteLine();
			Console.WriteLine("Séries e Filmes a seu dispor!!!");
			Console.WriteLine();
			Console.WriteLine("Digite 1 para Series ou 2 para Filmes:");

			string opcaoIni = Console.ReadLine();
			return opcaoIni;
		}

        private static string ObterOpcaoUsuario()
		{
			string opcaoUsuario;

			switch (opcaoInicial)
			{
				case "1":

					Console.WriteLine();
					Console.WriteLine("Séries a seu dispor!!!");
					Console.WriteLine();
					Console.WriteLine("Informe a opção desejada:");

					Console.WriteLine("1- Listar séries");
					Console.WriteLine("2- Inserir nova série");
					Console.WriteLine("3- Atualizar série");
					Console.WriteLine("4- Excluir série");
					Console.WriteLine("5- Visualizar série");
					Console.WriteLine("C- Limpar Tela");
					Console.WriteLine("V- Menu Inicial");
					Console.WriteLine("X- Sair");
					Console.WriteLine();

					opcaoUsuario = Console.ReadLine().ToUpper();
					Console.WriteLine();
					break;

				case "2":

					Console.WriteLine();
					Console.WriteLine("Filmes a seu dispor!!!");
					Console.WriteLine();
					Console.WriteLine("Informe a opção desejada:");

					Console.WriteLine("1- Listar filmes");
					Console.WriteLine("2- Inserir novo filme");
					Console.WriteLine("3- Atualizar filme");
					Console.WriteLine("4- Excluir filme");
					Console.WriteLine("5- Visualizar filme");
					Console.WriteLine("C- Limpar Tela");
					Console.WriteLine("V- Menu Inicial");
					Console.WriteLine("X- Sair");
					Console.WriteLine();

					opcaoUsuario = Console.ReadLine().ToUpper();
					Console.WriteLine();
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}

			return opcaoUsuario;

		}
    }
}

