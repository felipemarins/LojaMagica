using System;
using System.Collections.Generic;

namespace LojaMagica
{
	class Program
	{
		static void Main(string[] args)
		{
			Loja loja = new Loja(false);
			bool sair = false;
			do
			{
				Menu menuInicial = new Menu("Selecione se você é um cliente ou um administrador.\n",
					new List<string> { "Sou um cliente", "Sou um adminstrador", "Sair" });
				menuInicial.IniciarMenuPadrao();
				if (menuInicial.Selecao == 0) { sair = true; }
				else if (menuInicial.Selecao == 1)
				{
					loja = new Loja(true);
					Console.Clear();
					Console.Write("Digite seu nome: ");
					String nome = Console.ReadLine();
					Console.Write("Quantas peças de ouro você tem? ");
					Int32 ouro = Convert.ToInt32(Console.ReadLine());

					Personagem personagemAtual = new Personagem(nome, ouro);

					do
					{
						Menu menuPersonagem = new Menu("Bem-vindo, " + nome + '\n',
							new List<string> { "Ver catálogo", "Ver status de " + personagemAtual.Nome,
							"Ver inventário de " + personagemAtual.Nome, "Comprar item", "Sair" });
						menuPersonagem.IniciarMenuPadrao();
						if (menuPersonagem.Selecao == 0) { sair = true; }
						else if (menuPersonagem.Selecao == 1) { loja.ImprimirEstoque(); }
						else if (menuPersonagem.Selecao == 2) { personagemAtual.ImprimirStatus(); }
						else if (menuPersonagem.Selecao == 3) { personagemAtual.ImprimirInventario(); }
						else if (menuPersonagem.Selecao == 4)
						{
							Console.Clear();
							Console.Write("Digite o nome do item: ");
							string nomeDoItem = Console.ReadLine();
							if (loja.ItemExiste(nomeDoItem))
							{
								Console.Write("Quantas unidades? ");
								int quantidade = Convert.ToInt32(Console.ReadLine());

								loja = personagemAtual.ComprarItem(nomeDoItem, quantidade, loja);
							}
							else
							{
								Menu.EsperarPorTecla();
							}
						}
					} while (sair != true);
					sair = false;
				}
				else if (menuInicial.Selecao == 2)
				{
					do
					{
						Menu menuAdministrador = new Menu("Bem-vindo, administrador!\n",
							new List<string> { "Adicionar um novo item ao catálogo", "Salvar estoque", "Carregar estoque",
							"Adicionar unidades a um item", "Listar items no estoque", "Ver detalhes de um item", "Voltar" });
						menuAdministrador.IniciarMenuPadrao();
						if (menuAdministrador.Selecao == 0) { sair = true; }
						else if (menuAdministrador.Selecao == 1) { loja.AdicionarItem(); }
						else if (menuAdministrador.Selecao == 2) { loja.SalvarEstoque(); }
						else if (menuAdministrador.Selecao == 3) { loja.CarregarEstoque(); }
						else if (menuAdministrador.Selecao == 4)
						{
							Console.Clear();
							Console.Write("Nome do item: ");
							string nomeDoItem = Console.ReadLine();
							loja.AdicionarUnidadesItem(nomeDoItem);
						}
						else if (menuAdministrador.Selecao == 5) { loja.ImprimirEstoque(); }
						else if (menuAdministrador.Selecao == 6)
						{
							Console.Clear();
							Console.Write("Nome do item: ");
							string nomeDoItem = Console.ReadLine();
							loja.ImprimirDetalhesItem(nomeDoItem);
						}
					} while (sair != true);
					sair = false;
				}
			} while (sair != true);
		}
	}
}
