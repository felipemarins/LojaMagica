using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

public class Loja
{
    public Dictionary<string, Tuple<Item, int>> Estoque = new Dictionary<string, Tuple<Item, int>>();

    public void AdicionarItem()
    {
        Console.Clear();
        Console.WriteLine("Adicionar um novo item ao catálogo\n");
        Item item = new Item();

        Console.Write("Nome do item: ");
        item.Nome = Console.ReadLine();
        Console.Write("Descrição: ");
        item.Descricao = Console.ReadLine();
        Console.Write("Categoria: ");
        item.Categoria = Console.ReadLine();
        Console.Write("Valor: ");
        item.Valor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Quantidade no estoque: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        Estoque.Add(item.Nome, new Tuple<Item, int>(item, quantidade));
        Console.WriteLine("\nO item " + item.Nome + " foi adicionado ao catálogo");

        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    public void SalvarEstoque()
    {
        Console.Clear();
        Console.WriteLine("Salvando o estoque no arquivo \'Estoque.json\' na pasta do programa");
        string json = JsonSerializer.Serialize(Estoque);
        File.WriteAllText("Estoque.json", json);
        Console.Clear();
        Console.WriteLine("O estoque foi salvo no arquivo \'Estoque.json\' na pasta do programa!");

        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    public void CarregarEstoque()
    {
        Console.Clear();
        Console.WriteLine("Carregando o estoque salvo");
        string json = File.ReadAllText("Estoque.json");
        Estoque = JsonSerializer.Deserialize<Dictionary<string, Tuple<Item, int>>>(json);
        Console.Clear();
        Console.WriteLine("O estoque foi carregado a partir de um arquivo salvo.");
    }
    public void ImprimirEstoque()
    {
        Console.Clear();
        Console.WriteLine("Lista de itens no estoque:\n");
        foreach (KeyValuePair<string, Tuple<Item, int>> item in Estoque)
        {
            Console.WriteLine("Item: " + item.Key);
            Console.WriteLine("Quantidade: " + item.Value.Item2 + " unidades\n");
        }
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    public void ImprimirDetalhesItem(string nomeDoItem)
    {
        Console.Clear();
        if (ItemExiste(nomeDoItem))
        {
            Item item = Estoque[nomeDoItem].Item1;

            Console.WriteLine("Detalhes sobre " + nomeDoItem + '\n');

            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Descrição: " + item.Descricao);
            Console.WriteLine("Categoria: " + item.Categoria);
            Console.WriteLine("Valor: " + item.Valor);
            Console.WriteLine("Quantidade no estoque: " + Estoque[nomeDoItem].Item2);
        }
        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    public void AdicionarUnidadesItem(string nomeDoItem)
    {
        Console.Clear();
        if (ItemExiste(nomeDoItem))
        {
            Console.WriteLine("Adicionar unidades ao item " + nomeDoItem + '\n');
            Console.Write("Unidades a se adicionar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            quantidade += Estoque[nomeDoItem].Item2;
            Estoque[nomeDoItem] = new Tuple<Item, int>(Estoque[nomeDoItem].Item1, quantidade);
            Console.WriteLine("\nNova quantidade: " + Estoque[nomeDoItem].Item2);

            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
            Console.ReadKey();
        }
    }
    public bool ItemExiste(string nomeDoItem)
    {
        if (Estoque.ContainsKey(nomeDoItem)) { return true; }
        else
        {
            Console.WriteLine("Este item não consta no catálogo. Verifique se não houve algum erro de digitação.");
            return false;
        }
    }
    public Item ObterItem(string nomeDoItem, int quantidade)
    {
        int novaQuantidade = Estoque[nomeDoItem].Item2 - 1;
        Estoque[nomeDoItem] = new Tuple<Item, int>(Estoque[nomeDoItem].Item1, novaQuantidade);
        return Estoque[nomeDoItem].Item1;
    }
}