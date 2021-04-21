using System;
using System.Collections.Generic;

public class Menu
{
	public int Selecao;

	public string TextoDeCima;

	public List<string> Opcoes = new List<string>();

	public bool ContinuarMenu;

	public Menu(string textoAcima, List<string> opcoes)
	{
		this.ContinuarMenu = true;
		this.Opcoes = opcoes;
		this.Selecao = 0;
		this.TextoDeCima = textoAcima;
	}

	public void IniciarMenuPadrao()
	{
		while (this.ContinuarMenu != false)
		{
			this.AtualizarMenu();
			this.PegarTecla();
		}
		if (this.Selecao == this.Opcoes.Count - 1)
			this.Selecao = 0;
		else
			this.Selecao++;
	}

	public void AtualizarMenu()
	{
		Console.Clear();
		int i = 0;
		Console.WriteLine(this.TextoDeCima);
		foreach (string opcao in this.Opcoes)
		{
			if (i == this.Selecao)
			{
				this.DestacarSelecao();
			}

			Console.WriteLine(opcao);

			if (i == this.Selecao)
			{
				Console.ResetColor();
			}

			i++;
		}
	}

	public void PegarTecla()
	{
		ConsoleKeyInfo tecla = new ConsoleKeyInfo();
		tecla = Console.ReadKey();
		if (tecla.Key == ConsoleKey.Enter)
			this.SairMenu();
		else if (tecla.Key == ConsoleKey.DownArrow && this.Selecao + 1 < this.Opcoes.Count)
			this.Selecao++;
		else if (tecla.Key == ConsoleKey.UpArrow && this.Selecao - 1 >= 0)
			this.Selecao--;
	}

	public void SairMenu()
	{
		this.ContinuarMenu = false;
	}

	public void DestacarSelecao()
	{
		Console.ForegroundColor = ConsoleColor.Black;
		Console.BackgroundColor = ConsoleColor.White;
	}

	public static void EsperarPorTecla()
	{
		Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
		Console.ReadKey();
	}
}