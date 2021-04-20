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

        Console.Write("Nome do item: ");
        String nome = Console.ReadLine();
        Console.Write("Descrição: ");
        String descricao = Console.ReadLine();
        Console.Write("Categoria: ");
        String categoria = Console.ReadLine();
        Console.Write("Valor: ");
        Int32 valor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Quantidade no estoque: ");
        Int32 quantidade = Convert.ToInt32(Console.ReadLine());

        Item item = new Item(nome, descricao, categoria, valor);
        this.Estoque.Add(item.Nome, new Tuple<Item, int>(item, quantidade));
        Console.WriteLine("\nO item " + item.Nome + " foi adicionado ao catálogo");

        Menu.EsperarPorTecla();
    }

    public void SalvarEstoque()
    {
        Console.Clear();
        Console.WriteLine("Salvando o estoque no arquivo \'Estoque.json\' na pasta do programa");
        string json = JsonSerializer.Serialize(this.Estoque);
        File.WriteAllText("Estoque.json", json);
        Console.Clear();
        Console.WriteLine("O estoque foi salvo no arquivo \'Estoque.json\' na pasta do programa!");

        Menu.EsperarPorTecla();
    }

    public void CarregarEstoque()
    {
        Console.Clear();
        Console.WriteLine("Carregando o estoque salvo");
        string json = File.ReadAllText("Estoque.json");
        this.Estoque = JsonSerializer.Deserialize<Dictionary<string, Tuple<Item, int>>>(json);
        Console.Clear();
        Console.WriteLine("O estoque foi carregado a partir de um arquivo salvo.");
    }

    public void ImprimirEstoque()
    {
        Console.Clear();
        Console.WriteLine("Lista de itens no estoque:\n");
        foreach (KeyValuePair<string, Tuple<Item, int>> item in this.Estoque)
        {
            Console.WriteLine("Item: " + item.Key);
            Console.WriteLine("Valor: " + item.Value.Item1.Valor + "po");
            Console.WriteLine("Quantidade: " + item.Value.Item2 + " unidades\n");
        }
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }

    public void ImprimirDetalhesItem(string nomeDoItem)
    {
        Console.Clear();
        if (this.ItemExiste(nomeDoItem))
        {
            Item item = this.Estoque[nomeDoItem].Item1;

            Console.WriteLine("Detalhes sobre " + nomeDoItem + '\n');

            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Descrição: " + item.Descricao);
            Console.WriteLine("Categoria: " + item.Categoria);
            Console.WriteLine("Valor: " + item.Valor);
            Console.WriteLine("Quantidade no estoque: " + this.Estoque[nomeDoItem].Item2);
        }
        Menu.EsperarPorTecla();
    }

    public void AdicionarUnidadesItem(string nomeDoItem)
    {
        Console.Clear();
        if (this.ItemExiste(nomeDoItem))
        {
            Console.WriteLine("Adicionar unidades ao item " + nomeDoItem + '\n');
            Console.Write("Unidades a se adicionar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            quantidade += this.Estoque[nomeDoItem].Item2;
            this.Estoque[nomeDoItem] = new Tuple<Item, int>(this.Estoque[nomeDoItem].Item1, quantidade);
            Console.WriteLine("\nNova quantidade: " + this.Estoque[nomeDoItem].Item2);
        }
        Menu.EsperarPorTecla();
    }

    public bool ItemExiste(string nomeDoItem)
    {
        if (this.Estoque.ContainsKey(nomeDoItem)) { return true; }
        else
        {
            Console.WriteLine("Este item não consta no catálogo. Verifique se não houve algum erro de digitação.");
            return false;
        }
    }

    public Item RetornarItem(string nomeDoItem)
    {
        return this.Estoque[nomeDoItem].Item1;
    }

    public Item VenderItem(string nomeDoItem)
    {
        int novaQuantidade = this.Estoque[nomeDoItem].Item2 - 1;
        this.Estoque[nomeDoItem] = new Tuple<Item, int>(this.Estoque[nomeDoItem].Item1, novaQuantidade);
        return this.Estoque[nomeDoItem].Item1;
    }
}