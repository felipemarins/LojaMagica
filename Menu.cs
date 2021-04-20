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
        ContinuarMenu = true;
        Opcoes = opcoes;
        Selecao = 0;
        TextoDeCima = textoAcima;
    }

    public void IniciarMenuPadrao()
    {
        while (ContinuarMenu != false)
        {
            AtualizarMenu();
            PegarTecla();
        }
        if (Selecao == Opcoes.Count - 1)
            Selecao = 0;
        else
            Selecao++;
    }

    public void AtualizarMenu()
    {
        Console.Clear();
        int i = 0;
        Console.WriteLine(TextoDeCima);
        foreach (string opcao in Opcoes)
        {
            if (i == Selecao)
            {
                DestacarSelecao();
            }

            Console.WriteLine(opcao);

            if (i == Selecao)
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
            SairMenu();
        else if (tecla.Key == ConsoleKey.DownArrow && Selecao + 1 < Opcoes.Count)
            Selecao++;
        else if (tecla.Key == ConsoleKey.UpArrow && Selecao - 1 >= 0)
            Selecao--;
    }

    public void SairMenu()
    {
        ContinuarMenu = false;
    }

    public void DestacarSelecao()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public static void EsperarPorTecla()
    {
        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
}